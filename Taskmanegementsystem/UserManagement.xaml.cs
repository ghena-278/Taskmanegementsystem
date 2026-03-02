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
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        User1 user;
        public UserManagement()
        {
            InitializeComponent();
            Load();
        }
        public UserManagement(User1 u)
        {
            
            InitializeComponent();
            this.user = u;
            Load();
        }
        public void Load()
        {
            using (TaskManagementEntities1 y = new TaskManagementEntities1())
            {
                var ts=y.Tasks.ToList();
                datagridss.ItemsSource = ts;
            }
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            using(TaskManagementEntities1 y=new TaskManagementEntities1())
            {
                Task t = new Task()
                {
                   TaskID= int.Parse(idtextbox.Text),
                   Title= titletextbox.Text,
                   Description=discriptiontextbox.Text,
                   Status=statuescombo.Text,
                   username=nametextbox.Text,
                };
                y.Tasks.Add(t);
                y.SaveChanges();
                MessageBox.Show("Added Successfully");
                Load();
            }
        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Task selected = datagridss.SelectedItem as Task;
            using (TaskManagementEntities1 y = new TaskManagementEntities1())
            {
                var s = y.Tasks.Where(x => x.TaskID == selected.TaskID).FirstOrDefault();
                if(s != null)
                {
                    //s.TaskID=int.Parse(idtextbox.Text);
                    s.Title=titletextbox.Text;
                    s.Description=discriptiontextbox.Text;
                    s.Status=statuescombo.Text;
                    s.username=nametextbox.Text;
                    y.SaveChanges();
                    MessageBox.Show("Updated Successfully");
                    Load();
                }
                if (selected == null)
                {
                    MessageBox.Show("Please select task");
                }
            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Task de = datagridss.SelectedItem as Task;
            using (TaskManagementEntities1 y = new TaskManagementEntities1())
            {
                var d = y.Tasks.Where(x => x.TaskID == de.TaskID).FirstOrDefault();
                if (d != null)
                {
                    y.Tasks.Remove(d);
                    y.SaveChanges();
                    MessageBox.Show("Deleted Successfully");
                    Load();
                }
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var keyword= titletextbox.Text;
            using(TaskManagementEntities1 l  = new TaskManagementEntities1())
            {
                var result=l.Tasks.Where(x=>x.Title== keyword).ToList();
                l.SaveChanges();
                MessageBox.Show("Searched result :");
                datagridss.ItemsSource = result;
            }
            
        }
    }
}
