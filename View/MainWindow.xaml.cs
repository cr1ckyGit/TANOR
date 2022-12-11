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
using System.Windows.Shapes;
using TANOR_project.View;
using TANOR_project.View.InfoPage;
using TANOR_project.View.LoginPage;

namespace TANOR_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameNavigate.FrameObject = MainWindowFrame;
            MainWindowFrame.Navigate(new MainInfoPage());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ServicesBtn_Click(object sender, RoutedEventArgs e)
        {

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
