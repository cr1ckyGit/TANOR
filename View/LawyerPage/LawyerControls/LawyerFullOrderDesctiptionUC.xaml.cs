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
using TANOR_project.View.AdminPage;

namespace TANOR_project.View.LawyerPage.LawyerControls
{
    /// <summary>
    /// Логика взаимодействия для LawyerFullOrderDesctiptionUC.xaml
    /// </summary>
    public partial class LawyerFullOrderDesctiptionUC : UserControl
    {
        public LawyerFullOrderDesctiptionUC()
        {
            InitializeComponent();
            ListFullOrder.ItemsSource = FrameNavigate.DB.Orders.Where(u => u.OrderID == Transfer.idOrder).ToList();
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainLawyerPage());
        }
    }
}
