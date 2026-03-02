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

namespace Taskmanegementsystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = name.Text;
            string password = pass.Password;
            if (username == "" || password == "")
            {
                MessageBox.Show("Email or Password are Required");
                return;
            }
            using (TaskManagementEntities1 h = new TaskManagementEntities1())
            {
                User1 ss = h.User1.FirstOrDefault(x => x.Name == username && x.Password == password) ;
                if (ss != null)
                {
                    MessageBox.Show("Login Successfully");
                   
                    if (ss.Role == "Manager")
                    {
                        this.NavigationService.Navigate(new UserManagement());
                    }
                    else if (ss.Role == "Employee")
                    {
                        this.NavigationService.Navigate(new ViewTasks(ss.Name));
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password");
                }
            }
        }
    }
}
