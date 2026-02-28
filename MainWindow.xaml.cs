using System.Windows;
using Shop_Oshchepkov.Classes;
using PR8BOGDANOV.elements;
using System.Windows.Documents;
using System.Collections.Generic;

namespace PR8BOGDANOV
{
    public partial class MainWindow : Window
    {
        List<object> AllItems = new classes.ChildrenContext().All();
        List<object> AllItems2 = new classes.electronicsContext().All();
        List<object> AllItems3 = new classes.sportContext().All();
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
        }

        private void LoadItems()
        {
            List<object> items = AllItems;

            foreach (var item in items)
            {
                Item itemControl = new Item(item);
                parent.Children.Add(itemControl);
            }

            items = AllItems2;

            foreach (var item in items)
            {
                Item itemControl = new Item(item);
                parent.Children.Add(itemControl);
            }

            items = AllItems3;

            foreach (var item in items)
            {
                Item itemControl = new Item(item);
                parent.Children.Add(itemControl);
            }
        }
    }
}