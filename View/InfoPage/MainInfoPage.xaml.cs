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
using TANOR_project.View.LoginPage;

namespace TANOR_project.View.InfoPage
{
    /// <summary>
    /// Логика взаимодействия для MainInfoPage.xaml
    /// </summary>
    public partial class MainInfoPage : Page
    {
        public MainInfoPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutUsBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new HowToStartPage());
        }

        private void DictionaryBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new DictionaryPage());
        }

        private void PersOfficeBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainRegPage());
        }
    }
}
