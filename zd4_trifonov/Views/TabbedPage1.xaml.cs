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
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1(string lastName)
        {
            InitializeComponent();
            
            TypePicker.SelectedIndex = 0; // По умолчанию аннуитетный
            Title = $"Привет, {lastName}"; // Выводим переданную фамилию в шапку страницы
        }

        // Обновление значения процентов при движении ползунка
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            RateLabel.Text = $"{Math.Round(e.NewValue)}%";
        }

        // Логика скрытия поля ежемесячного платежа для дифференцированного вида
        private void OnTypePickerChanged(object sender, EventArgs e)
        {
            MonthPayLabel.IsVisible = (TypePicker.SelectedIndex == 0);
        }

        // Математика расчета кредита при нажатии на кнопку
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AmountEntry.Text) || string.IsNullOrEmpty(PeriodEntry.Text))
            {
                DisplayAlert("Ошибка", "Заполните все поля кредита", "ОК");
                return;
            }

            double amount = Convert.ToDouble(AmountEntry.Text);
            int months = Convert.ToInt32(PeriodEntry.Text);
            double annualRate = Math.Round(RateSlider.Value);

            if (TypePicker.SelectedIndex == 0) // Аннуитетный расчет
            {
                double monthlyRate = annualRate / 12 / 100;
                double monthlyPayment = amount * (monthlyRate * Math.Pow(1 + monthlyRate, months)) / (Math.Pow(1 + monthlyRate, months) - 1);
                double totalSum = monthlyPayment * months;
                double overpayment = totalSum - amount;

                MonthPayLabel.Text = $"Ежемесячный платеж: {monthlyPayment:F2} руб.";
                TotalPayLabel.Text = $"Общая сумма: {totalSum:F2} руб.";
                OverpayLabel.Text = $"Переплата: {overpayment:F2} руб.";
            }
            else // Дифференцированный расчет
            {
                double overpayment = (amount * (months + 1) * (annualRate / 100) / 2) / 12;
                double totalSum = amount + overpayment;

                TotalPayLabel.Text = $"Общая сумма: {totalSum:F2} руб.";
                OverpayLabel.Text = $"Переплата: {overpayment:F2} руб.";
            }
        }
    }
}