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

namespace LoginApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
            {
                txtEmail.Focus();
            }

            private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                {
                    textEmail.Visibility = Visibility.Collapsed;
                }
                else
                {
                    textEmail.Visibility = Visibility.Visible;
                }
            }

            private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
            {
                txtPassword.Focus();
            }

            private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
                {
                    textPassword.Visibility = Visibility.Collapsed;
                }
                else
                {
                    textPassword.Visibility = Visibility.Visible;
                }
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Password))
                {
                    // Perform login logic here
                    MessageBox.Show("Login successful!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            private void Border_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }

            private void Image_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Application.Current.Shutdown();
            }
        }
    }
