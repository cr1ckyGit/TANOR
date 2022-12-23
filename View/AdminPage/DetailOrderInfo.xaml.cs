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
using TANOR_project.Model;
using TANOR_project.View.InfoPage;

namespace TANOR_project.View.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для DetailOrderInfo.xaml
    /// </summary>
    public partial class DetailOrderInfo : Page
    {
        public DetailOrderInfo()
        {
            InitializeComponent();
            DataOrdersInfo.ItemsSource = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            DataOrdersInfo.ItemsSource = FrameNavigate.DB.Orders.OrderBy(u => u.UserID).ToList();
            DataOrdersInfo.ItemsSource = FrameNavigate.DB.Orders.OrderBy(u => u.OrderDescription).ToList();
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            var result = MessageBox.Show("Отменить заявку?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.OrderID == idOrder select u).SingleOrDefault();
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                DataOrdersInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.UserID).ToList();
            }
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
