using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Text.RegularExpressions;


// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace BudgetPlaner
{
    public sealed partial class AddPage : UserControl 
    {
        List<Type> types;
        List<Category> categories;
        //List<Operation> operations;
        public AddPage()
        {
            this.InitializeComponent();
            this.Loaded += AddPageLoaded;
        }
       
        private void AddPageLoaded(object sender, RoutedEventArgs e)
        {
            using(var bas = new DBase())
            {
                types = bas.Types.ToList();
                categories = bas.Categories.ToList();
            }
            TypeList.ItemsSource = types;
            CategoryList.ItemsSource = categories;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            Type type = TypeList.SelectedItem as Type;
            if (type == null) return;


            Category category = CategoryList.SelectedItem as Category;
            if (category == null) return;



            Operation operation = new Operation
            {
                Type = type,
                Summa = Int32.Parse(boxSumma.Text),
                Category = category,
                Coment = boxComent.Text
            };

            using (DBase db = new DBase())
            {
                db.Types.Attach(type);
                db.Categories.Attach(category);
                db.Operations.Add(operation);
                db.SaveChanges();

            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            using (DBase db = new DBase())
            {
                CategoryList.ItemsSource = db.Categories.ToList();
            }
        }
        private void boxSumma_TextChanged(object sender, TextChangedEventArgs e)
        {
            boxSumma.Text = Regex.Replace(boxSumma.Text, @"[^0-9+-,]+", "");
        }
    }
}
