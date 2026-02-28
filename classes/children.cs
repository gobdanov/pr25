using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR8BOGDANOV.interfaces;
using Shop_Oshchepkov.Classes;
using PR8BOGDANOV.classes.common;

namespace PR8BOGDANOV.classes
{
    public class ChildrenContext : Children, IContext
    {
        // <summary> Пустой конструктор
        public ChildrenContext() { }

        // <summary> Конструктор
        public ChildrenContext(int Id, string Name, int Price, int Age, int IdShop) : base(Name, Price, Age, IdShop)
        {
            this.Id = Id;
        }

        // <summary> Получение всех детских товаров
        public List<object> All()
        {
            // Получаем все товара из БД
            List<object> allShop = new ShopContext().All();
            // Создаём новый список
            List<object> allChildren = new List<object>();
            // Открываем соединение
            OleDbConnection connection = DBConnection.Connection();
            // Получаем детские вещи
            OleDbDataReader childrenData = DBConnection.Query("SELECT * FROM [Детские вещи]", connection);
            // Читаем данные
            while (childrenData.Read())
            {
                // Ищем товар по коду
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).Id == childrenData.GetInt32(2)) as ShopContext;
                // Создаём новый экземпляр детских вещей
                ChildrenContext newChildren = new ChildrenContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,//цена
                    childrenData.GetInt32(1),//возраст
                    childrenData.GetInt32(2)
                );
                // Добавляем в список
                allChildren.Add(newChildren);
            }
            // Закрываем соединение
            DBConnection.CloseConnection(connection);
            // Возвращаем
            return allChildren;
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
