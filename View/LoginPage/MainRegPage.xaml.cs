using Final_project_TANOR.Core;
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
using TANOR_project.View.InfoPage;

namespace TANOR_project.View.LoginPage
{
    /// <summary>
    /// Логика взаимодействия для MainRegPage.xaml
    /// </summary>
    public partial class MainRegPage : Page
    {
        public MainRegPage()
        {
            InitializeComponent();
        }

        private async void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TbRegPassword.Password != TbRegPasswordConfirm.Password)
            {
                MessageBox.Show("Проверьте пароли!");
                return;
            }

            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(TbUserName.Text) || string.IsNullOrEmpty(TbRegPassword.Password) || string.IsNullOrEmpty(TbRegPasswordConfirm.Password) || string.IsNullOrEmpty(TbPhoneUser.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (FrameNavigate.DB.Users.Count(u => u.Login == TbLogin.Text) > 0)
                {
                    MessageBox.Show("Данный моб. номер уже зарегистрирован!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                FrameNavigate.DB.Users.Add(new Model.User
                {
                    Login = TbLogin.Text,
                    UserName = TbUserName.Text,
                    Password = TbRegPassword.Password,
                    PhoneNumber = TbPhoneUser.Text.ToString(),
                    RoleID = 2
                });
                try
                {
                    await FrameNavigate.DB.SaveChangesAsync();
                    MessageBox.Show("Учетная запись создана!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameNavigate.FrameObject.Navigate(new MainLoginPage());
                }
                catch 
                {
                    MessageBox.Show("Введите номер телефона без символов!");
                }
            }
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void GoToLoginPage_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainLoginPage());
        }


    }
}
