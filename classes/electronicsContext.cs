using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR8.classes;
using PR8BOGDANOV.interfaces;
using Shop_Oshchepkov.Classes;
using PR8BOGDANOV.classes.common;

namespace PR8BOGDANOV.classes
{
    public class electronicsContext : Electronics, IContext
    {
        // <summary> Пустой конструктор
        public electronicsContext() { }

        // <summary> Конструктор
        public electronicsContext(int Id, string Name, int Price, int BatteryCapacity, int Speed, int IdShop) : base(Name, Price, BatteryCapacity, Speed, IdShop)
        {
            this.Id = Id;
        }

        // <summary> Получение всех товаров
        public List<object> All()
        {
            // Получаем все товара из БД
            List<object> allShop = new ShopContext().All();
            // Создаём новый список
            List<object> allElectronics = new List<object>();
            // Открываем соединение
            OleDbConnection connection = DBConnection.Connection();
            // Получаем детские вещи
            OleDbDataReader electronicsData = DBConnection.Query("SELECT * FROM [Электроника]", connection);
            // Читаем данные
            while (electronicsData.Read())
            {
                // Ищем товар по коду
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).Id == electronicsData.GetInt32(3)) as ShopContext;
                // Создаём новый экземпляр детских вещей
                electronicsContext newElectronics = new electronicsContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,//цена
                    electronicsData.GetInt32(1),
                    electronicsData.GetInt32(2),
                    electronicsData.GetInt32(3)
                );
                // Добавляем в список
                allElectronics.Add(newElectronics);
            }
            // Закрываем соединение
            DBConnection.CloseConnection(connection);
            // Возвращаем
            return allElectronics;
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
