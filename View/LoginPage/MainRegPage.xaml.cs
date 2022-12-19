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
            if (string.IsNullOrEmpty(TbUserName.Text) || string.IsNullOrEmpty(TbRegPassword.Password) || string.IsNullOrEmpty(RegPasswordDoubleUser.Password) || string.IsNullOrEmpty(TbPhoneUser.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (FrameNavigate.DB.Users.Count(u => u.Login == TbUserName.Text) > 0)
                {
                    MessageBox.Show("Пользователь с такими инициалами уже зарегистрирован!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                FrameNavigate.DB.Users.Add(new Model.User
                {
                    Login = TbUserName.Text,
                    Password = TbRegPassword.Password,
                    Phone = TbPhoneUser.Text,
                    RoleID = 2
                });

                await FrameNavigate.DB.SaveChangesAsync();
                MessageBox.Show("Учетная запись создана!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameNavigate.FrameObject.Navigate(new MainLoginPage());
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
