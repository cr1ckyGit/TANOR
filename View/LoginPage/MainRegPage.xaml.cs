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

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            
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
