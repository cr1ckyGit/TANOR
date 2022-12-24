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

namespace TANOR_project.View.AdminPage.AdminControls
{
    /// <summary>
    /// Логика взаимодействия для AdminFullOrderDescriptionUC.xaml
    /// </summary>
    public partial class AdminFullOrderDescriptionUC : UserControl
    {
        public AdminFullOrderDescriptionUC()
        {
            InitializeComponent();
            ListFullOrder.ItemsSource = FrameNavigate.DB.Orders.Where(u => u.OrderID == Transfer.idOrder).ToList();
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new DetailOrderInfo());
        }
    }
}
