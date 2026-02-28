using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_Oshchepkov.Classes;
using PR8BOGDANOV.classes.common;
using PR8.classes;
using PR8;
using PR8BOGDANOV.interfaces;

namespace PR8BOGDANOV.classes
{
    public class sportContext : Sport, IContext
    {
        // <summary> Пустой конструктор
        public sportContext() { }

        // <summary> Конструктор
        public sportContext(int Id, string Name, int Price, string Size, int IdShop) : base(Name, Price, Size, IdShop)
        {
            this.Id = Id;
        }

        // <summary> Получение всех товаров
        public List<object> All()
        {
            // Получаем все товара из БД
            List<object> allShop = new ShopContext().All();
            // Создаём новый список
            List<object> allSports = new List<object>();
            // Открываем соединение
            OleDbConnection connection = DBConnection.Connection();
            // Получаем детские вещи
            OleDbDataReader sportsData = DBConnection.Query("SELECT * FROM [Спорт]", connection);
            // Читаем данные
            while (sportsData.Read())
            {
                // Ищем товар по коду
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).Id == sportsData.GetInt32(2)) as ShopContext;
                // Создаём новый экземпляр детских вещей
                sportContext newSport = new sportContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,//цена
                    sportsData.GetString(1),
                    sportsData.GetInt32(2)
                );
                // Добавляем в список
                allSports.Add(newSport);
            }
            // Закрываем соединение
            DBConnection.CloseConnection(connection);
            // Возвращаем
            return allSports;
        }

        // <summary> Метод удаления товара
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        // <summary> Метод добавления и обновления
        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
