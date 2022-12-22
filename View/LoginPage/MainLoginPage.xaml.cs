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
using TANOR_project.Core;
using TANOR_project.LawyerPage;
using TANOR_project.Model;
using TANOR_project.View.AdminPage;
using TANOR_project.View.InfoPage;
using TANOR_project.View.UserPage;

namespace TANOR_project.View.LoginPage
{
    /// <summary>
    /// Логика взаимодействия для MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = FrameNavigate.DB.Users.FirstOrDefault(u => u.Login == TbLogin.Text && u.Password == PsbPassword.Password);
                if (userModel == null)
                {
                        MessageBox.Show("Ошибка данных",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    switch (userModel.RoleID)
                    {
                        case 1:
                            FrameNavigate.FrameObject.Navigate(new DetailOrderInfo());
                            break;
                        case 2:
                            FrameNavigate.FrameObject.Navigate(new MainUserPage());
                            break;
                        case 3:
                            FrameNavigate.FrameObject.Navigate(new MainLawyerPage());
                            break;
                    }
                    Transfer.Login = userModel.Login.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Системная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
