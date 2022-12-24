using Final_project_TANOR.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TANOR_project.Core;
using static System.Net.Mime.MediaTypeNames;

namespace TANOR_project.View.UserPage
{
    /// <summary>
    /// Логика взаимодействия для UserCreateOrder.xaml
    /// </summary>
    public partial class UserCreateOrder : Page
    {
        public UserCreateOrder()
        {
            InitializeComponent();
        }
        private byte [] array_images;

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainUserPage());
        }

        private async void BtnSendOrder_Click(object sender, RoutedEventArgs e)
        {
            int IDUser = (from u in FrameNavigate.DB.Users where u.Login == Transfer.Login select u.UserID).FirstOrDefault();
            if (FrameNavigate.DB.Orders.Count(u => u.UserID == IDUser) > 0)
            {
                MessageBox.Show("У вас уже есть активная заявка!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                FrameNavigate.DB.Orders.Add(new Model.Order
                {
                    UserID = IDUser,
                    OrderDescription = TbDescription.Text,
                    OrderImage = array_images,
                    Status = false,
                    ConfirmedOrderStatus = false,
                });
                await FrameNavigate.DB.SaveChangesAsync();
                MessageBox.Show("Заказ отправлен");
            }
            catch
            {
                MessageBox.Show("Заполните полностью заявку суки");
            }

        }
        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                byte[] image_bytes = File.ReadAllBytes(openFileDialog.FileName);
                array_images = image_bytes;
                TbImageAdded.Text = openFileDialog.SafeFileName;
            }
            catch
            {
                MessageBox.Show("Выберите фотографию суки");
            }
        }
    }
}
