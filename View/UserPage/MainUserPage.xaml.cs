using Final_project_TANOR.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using TANOR_project.Core;
using TANOR_project.Model;
using TANOR_project.View.InfoPage;

namespace TANOR_project.View.UserPage
{
    /// <summary>
    /// Логика взаимодействия для MainUserPage.xaml
    /// </summary>
    public partial class MainUserPage : Page
    {
        public MainUserPage()
        {
            InitializeComponent();
            List<Order> Order = (from u in FrameNavigate.DB.Orders where u.UserID == Transfer.idUser select u).ToList();
            var result = MessageBox.Show($"Ваш заказ №{Transfer.idOrder} выполнен!",
                                        "Системное сообщение",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);

        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new UserCreateOrder());
        }
    }
}
