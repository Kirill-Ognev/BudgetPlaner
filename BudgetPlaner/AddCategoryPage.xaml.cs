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

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace BudgetPlaner
{
    public sealed partial class AddCategoryPage : UserControl
    {
        List<Category> categories;
        public AddCategoryPage()
        {
            this.InitializeComponent();
            this.Loaded += CategoryPageLoaded;
        }

        private void CategoryPageLoaded(object sender, RoutedEventArgs e)
        {
            using (DBase db = new DBase())
            {
                categories = db.Categories.ToList();
            }
            CategoryList.ItemsSource = categories;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category { Name = boxCategory.Text };

            using (DBase db = new DBase())
            {    
                db.Categories.Add(category);
                db.SaveChanges();
                CategoryList.ItemsSource = db.Categories.ToList();
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryList.SelectedItem != null)
            {
                Category company = CategoryList.SelectedItem as Category;
                if (company != null)
                {
                    using (DBase db = new DBase())
                    {
                        db.Categories.Remove(company);
                        db.SaveChanges();
                        CategoryList.ItemsSource = db.Categories.ToList();
                    }
                }
            }
        }
    }

}
