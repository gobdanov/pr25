
using PR8;
using System.Diagnostics;
using System.Windows.Controls;
using System.Xml.Linq;
public class Children : Shop
{
    public int Age { get; set; }
    public int IdShop { get; set; }
    public Children() { }
    public Children(string Name, int Price, int Age, int IdShop) : base(IdShop, Name, Price) 
    {
        this.Age = Age;
        this.IdShop = IdShop;
    }
}