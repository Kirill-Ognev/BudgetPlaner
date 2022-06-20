using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;


// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace BudgetPlaner
{
    public sealed partial class AddTypeControl : UserControl
    {
        
       
        public AddTypeControl()
        {
            this.InitializeComponent();
            this.Loaded += AddTypePageLoaded;
        }

        

        private void AddTypePageLoaded(object sender, RoutedEventArgs e)
        {
          
            using (var db = new DBase())
            {
                TypesList.ItemsSource = db.Types.ToList();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new DBase())
            {
                Type type = new Type { Name = boxType.Text };
                db.Types.Add(type);
                db.SaveChanges();
                TypesList.ItemsSource = db.Types.ToList();
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (TypesList.SelectedItem != null)
            {
                Type company = TypesList.SelectedItem as Type;
                if (company != null)
                {
                    using (DBase db = new DBase())
                    {
                        db.Types.Remove(company);
                        db.SaveChanges();
                        TypesList.ItemsSource = db.Types.ToList();
                    }
                }
            }
        }
    }
}
