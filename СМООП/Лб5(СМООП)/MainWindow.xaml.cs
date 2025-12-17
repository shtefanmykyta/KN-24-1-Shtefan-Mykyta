using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Лб5_СМООП_
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    //Завдання 1
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private double _memoryValue = 0;
        private string _pendingOp = null;
        private bool _resetInput = false;
        private bool _isMemoryActive = false;

        public MainWindow()
        {
            InitializeComponent();
            CurrentTextBox.Text = "0";
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string digit = button.Content.ToString();

            if (_resetInput || CurrentTextBox.Text == "0")
            {
                CurrentTextBox.Text = digit;
                _resetInput = false;
            }
            else
            {
                CurrentTextBox.Text += digit;
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (!CurrentTextBox.Text.Contains(separator))
            {
                CurrentTextBox.Text += separator;
            }
        }

        private void OpButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string op = button.Tag.ToString();

            if (double.TryParse(CurrentTextBox.Text, out _currentValue))
            {
                if (_pendingOp != null)
                {
                    _memoryValue = Calculate(_memoryValue, _currentValue, _pendingOp);
                    CurrentTextBox.Text = _memoryValue.ToString("F8").TrimEnd('0').TrimEnd(',');
                    HistoryTextBox.Text = $"{_memoryValue} {op}";
                }
                else
                {
                    _memoryValue = _currentValue;
                    HistoryTextBox.Text = $"{_memoryValue} {op}";
                }

                _pendingOp = op;
                _resetInput = true;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pendingOp != null && double.TryParse(CurrentTextBox.Text, out _currentValue))
            {
                _memoryValue = Calculate(_memoryValue, _currentValue, _pendingOp);
                CurrentTextBox.Text = _memoryValue.ToString("F8").TrimEnd('0').TrimEnd(',');
                HistoryTextBox.Text = "";
                _pendingOp = null;
                _resetInput = true;
            }
        }

        private double Calculate(double left, double right, string op)
        {
            return op switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => right != 0 ? left / right : 0,
                _ => right
            };
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Text = "0";
            _resetInput = true;
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTextBox.Text = "0";
            HistoryTextBox.Text = "";
            _currentValue = 0;
            _memoryValue = 0;
            _pendingOp = null;
            _resetInput = true;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTextBox.Text.Length > 1)
                CurrentTextBox.Text = CurrentTextBox.Text[..^1];
            else
                CurrentTextBox.Text = "0";
        }

        private void MemoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string operation = button.Tag.ToString();

            if (double.TryParse(CurrentTextBox.Text, out double value))
            {
                switch (operation)
                {
                    case "MC":
                        _memoryValue = 0;
                        _isMemoryActive = false;
                        break;
                    case "MR":
                        CurrentTextBox.Text = _memoryValue.ToString();
                        _resetInput = true;
                        break;
                    case "MS":
                        _memoryValue = value;
                        _isMemoryActive = true;
                        break;
                    case "M+":
                        _memoryValue += value;
                        _isMemoryActive = true;
                        break;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0: case Key.NumPad0: DigitButton_Click(null, null); break;
                case Key.D1: case Key.NumPad1: DigitButton_Click(null, null); break;
                // ... другие цифры аналогично
                case Key.OemComma: case Key.Decimal: DotButton_Click(null, null); break;
                case Key.Enter: EqualsButton_Click(null, null); break;
                case Key.Back: BackspaceButton_Click(null, null); break;
            }
        }
    }

    //Завдання 2
    public partial class BestOilWindow : Window
    {
        private double _dayTotal = 0;

        public class FuelType
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public override string ToString() => Name;
        }

        public BestOilWindow()
        {
            InitializeComponent();
            InitializeFuelTypes();
        }

        private void InitializeFuelTypes()
        {
            FuelComboBox.ItemsSource = new[]
            {
            new FuelType { Name = "A-95", Price = 55.50 },
            new FuelType { Name = "A-92", Price = 53.20 },
            new FuelType { Name = "Diesel", Price = 58.80 },
            new FuelType { Name = "Газ", Price = 32.50 }
        };
            FuelComboBox.SelectedIndex = 0;
        }

        private void FuelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelComboBox.SelectedItem is FuelType fuel)
            {
                FuelPriceTextBlock.Text = $"{fuel.Price:F2} грн/л";
            }
        }

        private void RadioLiters_Checked(object sender, RoutedEventArgs e)
        {
            LitersTextBox.IsEnabled = true;
            MoneyTextBox.IsEnabled = false;
            MoneyTextBox.Text = "0";
        }

        private void RadioMoney_Checked(object sender, RoutedEventArgs e)
        {
            LitersTextBox.IsEnabled = false;
            MoneyTextBox.IsEnabled = true;
            LitersTextBox.Text = "0";
        }

        private double CalculateFuelSum()
        {
            if (FuelComboBox.SelectedItem is not FuelType fuel) return 0;

            double price = fuel.Price;

            if (RadioLiters.IsChecked == true &&
                double.TryParse(LitersTextBox.Text, out double liters) && liters > 0)
            {
                return liters * price;
            }

            if (RadioMoney.IsChecked == true &&
                double.TryParse(MoneyTextBox.Text, out double money) && money > 0)
            {
                double liters = money / price;
                FuelResultTextBox.Text = $"{liters:F2} л";
                return money;
            }

            return 0;
        }

        private double CalculateCafeSum()
        {
            double sum = 0;

            if (HotDogCheckBox.IsChecked == true &&
                double.TryParse(HotDogQtyTextBox.Text, out double q1) &&
                double.TryParse(HotDogPriceTextBox.Text, out double p1))
            {
                sum += q1 * p1;
            }

            if (CoffeeCheckBox.IsChecked == true &&
                double.TryParse(CoffeeQtyTextBox.Text, out double q2) &&
                double.TryParse(CoffeePriceTextBox.Text, out double p2))
            {
                sum += q2 * p2;
            }

            if (SandwichCheckBox.IsChecked == true &&
                double.TryParse(SandwichQtyTextBox.Text, out double q3) &&
                double.TryParse(SandwichPriceTextBox.Text, out double p3))
            {
                sum += q3 * p3;
            }

            return sum;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double fuelSum = CalculateFuelSum();
            double cafeSum = CalculateCafeSum();
            double total = fuelSum + cafeSum;

            FuelSumTextBox.Text = $"{fuelSum:F2} грн";
            CafeSumTextBox.Text = $"{cafeSum:F2} грн";
            TotalSumTextBox.Text = $"{total:F2} грн";

            _dayTotal += total;
            DayTotalTextBlock.Text = $"Виручка за день: {_dayTotal:F2} грн";
        }

        private void NewClientButton_Click(object sender, RoutedEventArgs e)
        {
            LitersTextBox.Text = "0";
            MoneyTextBox.Text = "0";
            FuelResultTextBox.Text = "0.00 грн";
            FuelSumTextBox.Text = "0.00 грн";
            CafeSumTextBox.Text = "0.00 грн";
            TotalSumTextBox.Text = "0.00 грн";

            HotDogQtyTextBox.Text = "0";
            CoffeeQtyTextBox.Text = "0";
            SandwichQtyTextBox.Text = "0";

            foreach (CheckBox cb in new[] { HotDogCheckBox, CoffeeCheckBox, SandwichCheckBox })
                cb.IsChecked = false;

            RadioLiters.IsChecked = true;
        }
    }

}
