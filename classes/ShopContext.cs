    
using System.Collections.Generic;
using System.Data.OleDb;
using PR8.classes;
using PR8BOGDANOV.interfaces;
using PR8;
namespace Shop_Oshchepkov.Classes
{
    public class ShopContext : Shop, IContext
    {
        public ShopContext() { }

        // <summary> Конструктор
        // </summary>
        public ShopContext(int Id, string Name, int Price) : base(Id, Name, Price) { }

        // <summary> Метод получения всего товара из БД
        // </summary>
        public List<object> All()
        {
            List<object> allShop = new List<object>();

            OleDbConnection connection = PR8BOGDANOV.classes.common.DBConnection.Connection();
            OleDbDataReader shopData = PR8BOGDANOV.classes.common.DBConnection.Query("SELECT * FROM [Товары]", connection);

            while (shopData.Read())
            {
                ShopContext newShop = new ShopContext(
                    shopData.GetInt32(0),
                    shopData.GetString(1),
                    shopData.GetInt32(2)
                );
                allShop.Add(newShop);
            }

            PR8BOGDANOV.classes.common.DBConnection.CloseConnection(connection);

            return allShop;
        }

        // <summary> Метод удаления товара
        // </summary>
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        // <summary> Метод добавления и обновления
        // </summary>
        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
