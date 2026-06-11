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
        public TabbedPage1()
        {
            InitializeComponent();

            //
            //Выбираем аннуитетный платеж по умолчанию при старте
            TypePicker.SelectedIndex = 0;
        }

        // Логика ползунка процентной ставки
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            RateLabel.Text = $"{Math.Round(e.NewValue)}%";
        }

        // Прячем или показываем ежемесячный платеж в зависимости от вида платежа
        private void OnTypePickerChanged(object sender, EventArgs e)
        {
            if (TypePicker.SelectedIndex == 0) // Аннуитетный
            {
                MonthPayLabel.IsVisible = true;
            }
            else // Дифференцированный
            {
                MonthPayLabel.IsVisible = false;
            }
        }

        // Логика главной кнопки "Рассчитать"
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrEmpty(AmountEntry.Text) || string.IsNullOrEmpty(PeriodEntry.Text))
            {
                DisplayAlert("Ошибка", "Заполните все поля кредита", "ОК");
                return;
            }

            // Конвертируем текст из полей в числа
            double amount = Convert.ToDouble(AmountEntry.Text);
            int months = Convert.ToInt32(PeriodEntry.Text);
            double annualRate = Math.Round(RateSlider.Value);

            if (TypePicker.SelectedIndex == 0) // Расчет аннуитетного платежа
            {
                double monthlyRate = annualRate / 12 / 100;
                double monthlyPayment = amount * (monthlyRate * Math.Pow(1 + monthlyRate, months)) / (Math.Pow(1 + monthlyRate, months) - 1);
                double totalSum = monthlyPayment * months;
                double overpayment = totalSum - amount;

                // Выводим результаты
                MonthPayLabel.Text = $"Ежемесячный платеж: {monthlyPayment:F2} руб.";
                TotalPayLabel.Text = $"Общая сумма: {totalSum:F2} руб.";
                OverpayLabel.Text = $"Переплата: {overpayment:F2} руб.";
            }
            else // Расчет дифференцированного платежа
            {
                double overpayment = (amount * (months + 1) * (annualRate / 100) / 2) / 12;
                double totalSum = amount + overpayment;

                // Выводим только общую сумму и переплату
                TotalPayLabel.Text = $"Общая сумма: {totalSum:F2} руб.";
                OverpayLabel.Text = $"Переплата: {overpayment:F2} руб.";
            }
        }
    }
}