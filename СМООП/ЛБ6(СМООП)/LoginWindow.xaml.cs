using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ6_СМООП_
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Windows;
    using System.Windows.Controls;

    public partial class LoginWindow : Window
    {
        private static readonly string UsersFile = "users.json";
        private List<User> _users = new List<User>();

        public LoginWindow()
        {
            InitializeComponent();
            LoadUsers();
            UpdateUserCount();
        }

        private void LoadUsers()
        {
            if (File.Exists(UsersFile))
            {
                string json = File.ReadAllText(UsersFile);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
        }

        private void SaveUsers()
        {
            string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(UsersFile, json);
            UpdateUserCount();
        }

        private void UpdateUserCount()
        {
            UserCountTextBlock.Text = $"Користувачів: {_users.Count}";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ShowError("Заповніть всі поля!");
                return;
            }

            User user = _users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                MessageBox.Show($"Вітаємо, {user.FullName}!\nУспішний вхід.", "Успіх",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ShowError("Неправильний логін або пароль!");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(this);
            registerWindow.ShowDialog();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            SaveUsers();
        }

        private void ShowError(string message)
        {
            ErrorTextBlock.Text = message;
        }
    }

}
