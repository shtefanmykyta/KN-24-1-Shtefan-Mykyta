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

namespace ЛБ4_СМООП_
{
        public partial class MainWindow : Window
        {
            private int gameStep = 0;

            public MainWindow()
            {
                InitializeComponent();
            }

            // Завдання 1
            private void HelloButton_Click(object sender, RoutedEventArgs e) => Task1Label.Content = "Привіт!";
            private void ByeButton_Click(object sender, RoutedEventArgs e) => Task1Label.Content = "До побачення!";

            // Завдання 2
            private void HideTextBlock_Click(object sender, RoutedEventArgs e) => Task2TextBlock.Visibility = Visibility.Collapsed;
            private void ShowTextBlock_Click(object sender, RoutedEventArgs e) => Task2TextBlock.Visibility = Visibility.Visible;

            // Завдання 3
            private void HideTextBox_Click(object sender, RoutedEventArgs e) => Task3TextBox.Visibility = Visibility.Collapsed;
            private void ShowTextBox_Click(object sender, RoutedEventArgs e) => Task3TextBox.Visibility = Visibility.Visible;
            private void ClearTextBox_Click(object sender, RoutedEventArgs e) => Task3TextBox.Text = "";

            // Завдання 4
            private void GameButton_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
                gameStep++;

                switch (gameStep)
                {
                    case 1: GameBtn1.Visibility = Visibility.Collapsed; GameStatus.Text = "Схована 1. Натисніть 2."; break;
                    case 2: GameBtn2.Visibility = Visibility.Collapsed; GameStatus.Text = "Схована 2. Натисніть 3."; break;
                    case 3: GameBtn3.Visibility = Visibility.Collapsed; GameStatus.Text = "Схована 3. Натисніть 4."; break;
                    case 4: GameBtn4.Visibility = Visibility.Collapsed; GameStatus.Text = "Схована 4. Натисніть 5."; break;
                    case 5:
                        GameBtn5.Visibility = Visibility.Collapsed;
                        GameStatus.Text = "🎉 ПЕРЕМОГА! F5 для перезапуску.";
                        gameStep = 0;
                        break;
                }
            }

            // Завдання 5
            private void ConvertButton_Click(object sender, RoutedEventArgs e)
            {
                if (double.TryParse(PoundsTextBox.Text, out double pounds))
                    KgTextBox.Text = (pounds * 0.45359237).ToString("F3");
                else
                    MessageBox.Show("Введіть число!");
            }

            // Завдання 6
            private void ColorButton_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
                MessageBox.Show($"Натиснуто: {btn.Content}");
            }
        }

}
