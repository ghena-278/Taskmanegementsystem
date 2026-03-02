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
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Page
    {
        User1 u;
        TaskManagementEntities1 b = new TaskManagementEntities1();
        public ViewTasks(string name)
        {
            InitializeComponent();
            namel.Content = name;
            Load();


        }
        public void Load()
        {
            datagrid1.ItemsSource = b.Tasks.Where(x => x.Status == "Pending" || x.Status == "In Progress").ToList();
            datagrid2.ItemsSource = b.Tasks.Where(x => x.Status == "Completed").ToList();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(textinput.Text);
            Task task = b.Tasks.FirstOrDefault(x => x.TaskID == id);
            if (task == null)
            {
                MessageBox.Show("error");
                return;
            }
            task.Status = combo.Text;
            b.SaveChanges();
            Load();
        }
    }
}
