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
using TANOR_project.Model;
using TANOR_project.View;
using TANOR_project.View.AdminPage.AdminControls;
using TANOR_project.View.InfoPage;
using TANOR_project.View.LawyerPage.LawyerControls;

namespace TANOR_project.LawyerPage
{
    /// <summary>
    /// Логика взаимодействия для MainLawyerPage.xaml
    /// </summary>
    public partial class MainLawyerPage : Page
    {
        public MainLawyerPage()
        {
            InitializeComponent();
            var Order_array = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            List<Order> result = new List<Order>();

            foreach (var item in Order_array)
            {
                if (item.Status == true)
                {
                    if (item.ConfirmedOrderStatus == false)
                        result.Add(item);
                }
            }
            DataOrdersInfo.ItemsSource = result;
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainInfoPage());
        }

        private void BtnGetFullOrder_Click(object sender, RoutedEventArgs e)
        {
            Transfer.idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            Grid123.Children.Clear();
            Grid123.Children.Add(new LawyerFullOrderDesctiptionUC());
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            int idOrder = (DataOrdersInfo.SelectedItem as Order).OrderID;
            Transfer.idOrder = idOrder;
            Order order = (from u in FrameNavigate.DB.Orders where u.OrderID == idOrder select u).FirstOrDefault();
            order.ConfirmedOrderStatus = true;
            FrameNavigate.DB.SaveChanges();

            var Order_array = FrameNavigate.DB.Orders.OrderBy(u => u.OrderID).ToList();
            List<Order> result = new List<Order>();

            foreach (var item in Order_array)
            {
                if (item.ConfirmedOrderStatus == false)
                {
                    result.Add(item);
                }
            }
            DataOrdersInfo.ItemsSource = result;

        }
    }
}
