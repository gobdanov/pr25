using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR8.classes
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int Speed { get; set; }
        public int IdShop { get; set; }
        public Electronics() { }
        public Electronics(string Name, int Price, int BatteryCapacity, int Speed, int IdShop) : base(IdShop, Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.Speed = Speed;
        }
    }
}