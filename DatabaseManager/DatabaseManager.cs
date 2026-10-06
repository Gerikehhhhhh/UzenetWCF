using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace UzenetWCF.DatabaseManager
{
    public class DatabaseManager
    {
        private string connection_string =
            "Server = localhost;" +
            "Database = uzenetkuldo" +
            "User = root;" +
            "Password = ;";

        public MySqlConnection CreateConnection()
        {
            MySqlConnection connection = new MySqlConnection(connection_string);

            return connection;
        }
    }
}