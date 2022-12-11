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

        }
    }
}
