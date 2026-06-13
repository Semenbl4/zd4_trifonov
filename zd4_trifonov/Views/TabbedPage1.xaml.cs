using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_trifonov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.CarouselPage
    {
        public TabbedPage1(string lastName)
        {
            InitializeComponent();
            TypePicker.SelectedIndex = 0;

            // Выводим фамилию в заголовок калькулятора
            WelcomeLabel.Text = $"Привет, {lastName}";
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            RateLabel.Text = $"{Math.Round(e.NewValue)}%";
        }

        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AmountEntry.Text) || string.IsNullOrEmpty(PeriodEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "ОК");
                return;
            }

            double amount = Convert.ToDouble(AmountEntry.Text);
            int months = Convert.ToInt32(PeriodEntry.Text);
            double annualRate = Math.Round(RateSlider.Value);
            string selectedType = TypePicker.SelectedItem?.ToString() ?? "Аннуитетный";

            double monthlyPayment = 0;
            double totalSum = 0;
            double overpayment = 0;

            if (selectedType == "Аннуитетный")
            {
                double monthlyRate = annualRate / 12 / 100;
                if (monthlyRate > 0)
                {
                    monthlyPayment = amount * (monthlyRate * Math.Pow(1 + monthlyRate, months)) / (Math.Pow(1 + monthlyRate, months) - 1);
                }
                else { monthlyPayment = amount / months; }
                totalSum = monthlyPayment * months;
                overpayment = totalSum - amount;
            }
            else
            {
                overpayment = (amount * (months + 1) * (annualRate / 100) / 2) / 12;
                totalSum = amount + overpayment;
                double mainDebtPayment = amount / months;
                double firstMonthInterest = amount * (annualRate / 100) / 12;
                monthlyPayment = mainDebtPayment + firstMonthInterest;
            }

            double maxSliderValue = RateSlider.Maximum;

            // Переход на 3-й экран результатов
            await Navigation.PushAsync(new ResultPage(selectedType, maxSliderValue, monthlyPayment, totalSum, overpayment));
        }
    }
}