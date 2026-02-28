using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR8BOGDANOV.classes.common
{
    public class DBConnection
    {
        public static readonly string Path = @"D:\!АВИК\3курс\ПРОГРАММИРОВАНИЕ\для отчета программирование\пр8\pr8_2-master\gobdanov_db.accdb";

        public static OleDbConnection Connection()
        {
            // Создаём соединение
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            // Открываем соединение
            oleDbConnection.Open();

            return oleDbConnection;
        }

        // <summary> Выполнение запросов
        public static OleDbDataReader Query(string Query, OleDbConnection Connection)
        {
            // Создаём команду и выполняем её
            return new OleDbCommand(Query, Connection).ExecuteReader();
        }

        // <summary> Закрытие соединения
        public static void CloseConnection(OleDbConnection Connection)
        {
            // Закрываем подключение к БД
            Connection.Close();
        }
    }
}
