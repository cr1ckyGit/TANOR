using Final_project_TANOR.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            var Order_array = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            List<Order> result = new List<Order>();
            
            foreach (var item in Order_array)
            {
                if (item.Status == false)
                {
                    result.Add(item);
                }
            }
            DataOrdersInfo.ItemsSource = result;

        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            int idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            Order order = (from u in FrameNavigate.DB.Orders where u.OrderID == idOrder select u).FirstOrDefault();
            order.Status = true;
            FrameNavigate.DB.SaveChanges();

            var Order_array = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            List<Order> result = new List<Order>();

            foreach (var item in Order_array)
            {
                if (item.Status == false)
                {
                    result.Add(item);
                }
            }
            DataOrdersInfo.ItemsSource = result;


        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            int idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            var questionResult = MessageBox.Show("Отменить заявку?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            if (questionResult == MessageBoxResult.Yes)
            {
                Order order = (from u in FrameNavigate.DB.Orders where u.OrderID == idOrder select u).SingleOrDefault();
                FrameNavigate.DB.Orders.Remove(order);
                FrameNavigate.DB.SaveChanges();
                DataOrdersInfo.ItemsSource = FrameNavigate.DB.Users.OrderBy(u => u.UserID).ToList();
            }

            var Order_array = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            List<Order> result = new List<Order>();

            foreach (var item in Order_array)
            {
                if (item.Status == false)
                {
                    result.Add(item);
                }
            }
            DataOrdersInfo.ItemsSource = result;
        }

        private void BtnGetFullOrder_Click(object sender, RoutedEventArgs e)
        {
            Transfer.idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            Grid123.Children.Clear();
            Grid123.Children.Add(new FullOrderDescriptionUserControl());
        }


    }
}
