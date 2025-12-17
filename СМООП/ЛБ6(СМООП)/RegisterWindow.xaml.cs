using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ6_СМООП_
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public partial class RegisterWindow : Window
    {
        private readonly LoginWindow _parentWindow;

        public RegisterWindow(LoginWindow parent)
        {
            InitializeComponent();
            _parentWindow = parent;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string fullName = FullNameTextBox.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullName))
            {
                ShowError("Заповніть всі поля!");
                return;
            }

            if (password != confirmPassword)
            {
                ShowError("Паролі не співпадають!");
                return;
            }

            if (password.Length < 6)
            {
                ShowError("Пароль повинен містити щонайменше 6 символів!");
                return;
            }

            if (_parentWindow._users.Any(u => u.Login == login))
            {
                ShowError("Користувач з таким логіном вже існує!");
                return;
            }

            User newUser = new User(login, password, fullName);
            _parentWindow.AddUser(newUser);

            MessageBox.Show("Реєстрація успішна!", "Успіх",
                           MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowError(string message)
        {
            ErrorTextBlock.Text = message;
        }
    }

}
