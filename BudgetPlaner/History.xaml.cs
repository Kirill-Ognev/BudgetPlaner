using Microsoft.EntityFrameworkCore;
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
    public sealed partial class History : UserControl
    {
       public History()
        {
            this.InitializeComponent();
            this.Loaded += History_Loaded;
        }

       
      

        private void History_Loaded(object sender, RoutedEventArgs e)
        {
             int balanse = 0;
            using (DBase db = new DBase())
            {
                operationList.ItemsSource = db.Operations.ToList();
                int len = db.Operations.ToList().Count;
                
                foreach(Operation operation in db.Operations)
                {
                    if(operation.Typeid == 2)
                    {
                        balanse += Convert.ToInt32(operation.Summa);
                        Budget.Text = "Ваш текущий баланс:  " + balanse;
                    }
                    else
                    {
                        balanse -= Convert.ToInt32(operation.Summa);
                        Budget.Text = "Ваш текущий баланс:  " + balanse;
                    }
                }
                if (operationList.ItemsSource != null)
                {

                    operationList.ItemsSource = db.Operations.Include(x => x.Type).ToList();
                    operationList.ItemsSource = db.Operations.Include(x => x.Category).ToList();

                }
            }

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (operationList.SelectedItem != null)
            {
                if (operationList.SelectedItem is Operation company)
                {
                    using (DBase db = new DBase())
                    {
                        db.Operations.Remove(company);
                        db.SaveChanges();
                        operationList.ItemsSource = db.Operations.ToList();
                    }
                }
            }
        }

       

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            int balanse = 0;
            using (DBase db = new DBase())
            {
                operationList.ItemsSource = db.Operations.ToList();
                if (operationList.ItemsSource != null)
                {

                    operationList.ItemsSource = db.Operations.Include(x => x.Type).ToList();
                    operationList.ItemsSource = db.Operations.Include(x => x.Category).ToList();
                }
                foreach (Operation operation in db.Operations)
                {
                    if (operation.Typeid == 2)
                    {
                        balanse += Convert.ToInt32(operation.Summa);
                        Budget.Text = "Ваш текущий баланс:  " + balanse;
                    }
                    else
                    {
                        balanse -= Convert.ToInt32(operation.Summa);
                        Budget.Text = "Ваш текущий баланс:  " + balanse;
                    }
                }
            }
            


        }

            
            

             
        
    }
}
