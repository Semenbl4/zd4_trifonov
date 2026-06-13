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
    public partial class ResultPage : ContentPage
    {
        public ResultPage(string selectedType, double maxSliderValue, double monthPay, double totalSum, double overpay)
        {
            InitializeComponent();

            TypeLabel.Text = $"Выбранный вид платежа: {selectedType}";
            MaxSliderLabel.Text = $"Максимальное значение слайдера: {maxSliderValue}%";

            // Выводим расчеты кредита
            if (selectedType == "Аннуитетный")
            {
                MonthPayLabel.Text = $"Ежемесячный платеж: {monthPay:F2} руб.";
            }
            else
            {
                MonthPayLabel.Text = $"Первый платеж (макс.): {monthPay:F2} руб.";
            }
            TotalPayLabel.Text = $"Общая сумма выплат: {totalSum:F2} руб.";
            OverpayLabel.Text = $"Переплата по кредиту: {overpay:F2} руб.";

            
            if (selectedType == "Аннуитетный")
            {
                DescriptionLabel.Text = "Расшифровка: Погашение происходит равными суммами каждый месяц. В начале срока большая часть денег идет на оплату процентов.";
            }
            else
            {
                DescriptionLabel.Text = "Расшифровка: Сумма основного долга делится равными долями, а проценты начисляются на остаток. Платежи уменьшаются к концу срока.";
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}