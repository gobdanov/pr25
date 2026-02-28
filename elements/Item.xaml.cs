using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using PR8;
using PR8.classes;

namespace PR8BOGDANOV.elements
{
    public partial class Item : UserControl
    {
        public Item(object Item)
        {
            InitializeComponent();
            Shop ShopData = Item as Shop;
            tb_Name.Content = ShopData.Name;
            tb_Price.Content = "Цена: " + ShopData.Price;

            if (Item is Children)
            {
                Children ChildrenData = Item as Children;
                tb_Characteristic.Content = "Возраст: " + ChildrenData.Age;
            }
            else if (Item is Sport)
            {
                Sport SportData = Item as Sport;
                tb_Characteristic.Content = "Размер: " + SportData.Size;
            }
            else if (Item is Electronics)
            {
                Electronics ElectronicsData = Item as Electronics;
                tb_Characteristic.Content = $"Аккумулятор: {ElectronicsData.BatteryCapacity}mAh, Скорость: {ElectronicsData.Speed}км/ч";
            }
        }
    }
}