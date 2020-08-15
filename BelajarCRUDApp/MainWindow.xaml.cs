using BelajarCRUDApp.Context;
using BelajarCRUDApp.Model;
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

namespace BelajarCRUDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext context = new MyContext();
        
        private void CRUD()
        {
            List<Supplier> suppliers = context.Suppliers.ToList();
            dataGrid.ItemsSource = suppliers;
            buttonDelete.IsEnabled = false;
            textId.Visibility = Visibility.Visible;
            textId.IsEnabled = false;
            Welcome.Visibility = Visibility.Hidden;
            label.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            dataGrid.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Visible;
            textName.Visibility = Visibility.Visible;
        }

        private void Hello()
        {
            buttonDelete.IsEnabled = false;
            textId.Visibility = Visibility.Hidden;
            Welcome.Visibility = Visibility.Visible;
            label.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
            textName.Visibility = Visibility.Hidden;
        }

        public MainWindow()
        {
            InitializeComponent();

            List<Supplier> suppliers = context.Suppliers.ToList();

            dataGrid.ItemsSource = suppliers;
            buttonDelete.IsEnabled = false;
            Hello();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                

            }

            else if (!string.IsNullOrWhiteSpace(textId.Text))
            {
                var obj = context.Suppliers.Find(Convert.ToInt16(textId.Text));
                obj.Name = textName.Text;
                context.SaveChanges();
                MessageBox.Show("Has Been Updated");
                textId.Text = "";
                textName.Text = "";
                dataGrid.ItemsSource = context.Suppliers.ToList();
            }

            else
            {
                textName.IsEnabled = true;
                var input = new Supplier(textName.Text);
                context.Suppliers.Add(input);
                context.SaveChanges();
                MessageBox.Show("Has Been inserted");
                textName.Text = "";
                dataGrid.ItemsSource = context.Suppliers.ToList();
            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Supplier supplier = (Supplier)dataGrid.SelectedItem;
                textName.Text = supplier.Name;
                int? Id = supplier.Id;
                textId.Text = Convert.ToString(Id);
                buttonDelete.IsEnabled = true;
            }
            
            catch (Exception)
            {
                textId.Text = "";
                textName.Text = "";
            }
            
            
        }

        private void TextId_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            int? Id = Convert.ToInt16(textId.Text);
            var obj = context.Suppliers.Find(Id);
            MessageBoxResult result = MessageBox.Show("This cannot be undone","Warning" , MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    context.Suppliers.Remove(obj);
                    MessageBox.Show(obj.Name + " Has been deleted");
                    context.SaveChanges();
                    
                    dataGrid.ItemsSource = context.Suppliers.ToList();
                    break;
                case MessageBoxResult.No:
                    break;
                
            }
            
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Hello();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CRUD();

        }
    }
}
