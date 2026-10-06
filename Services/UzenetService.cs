using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UzenetWCF.Models;
using MySql.Data.MySqlClient;
using UzenetWCF.DatabaseManager;

namespace UzenetWCF.Services
{
    public class UzenetService
    {
        public List<Uzenet> Read()
        {
            using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
            {
                try
                {
                    conn.Open();
                    List<Uzenet> result = new List<Uzenet>();
                    string sql = "SELECT * FROM uzenet;";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Uzenet uj_uzenet = new Uzenet();
                        uj_uzenet.Id = reader.GetInt32("Id");
                        uj_uzenet.Szoveg = reader.GetString("Uzenet");
                        uj_uzenet.KuldesiIdo = reader.GetDateTime("KuldesiIdo");
                        uj_uzenet.Uzenettipus = reader.GetString("UzenetTipus");
                        uj_uzenet.Telefon = reader.GetString("Telefon");
                        uj_uzenet.Email = reader.GetString("Email");
                        result.Add(uj_uzenet);
                    }

                    conn.Close();

                    return result;
                }
                catch (Exception ex)
                {
                    return new List<Uzenet>() { new Uzenet() { Szoveg = ex.Message} };
                }
            }
        }

        public string Create(Uzenet uzenet)
        {
            try
            {
                using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
                {
                    string sql = "INSERT INTO uzenet (szoveg, küldesiido, uzenettipus, telefon, email) VALUES (@szoveg, @kuldesiido, @uzenettipus, @telefon, @email);";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@szoveg", uzenet.Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesiido", uzenet.KuldesiIdo);
                    cmd.Parameters.AddWithValue("@uzenettipus", uzenet.Uzenettipus);
                    cmd.Parameters.AddWithValue("@telefon", uzenet.Telefon);
                    cmd.Parameters.AddWithValue("@email", uzenet.Email);

                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres beszúrás!";
                    }
                    else
                    {
                        return "Sikertelen beszúrás!";
                    }
                }
            }

            catch (Exception ex)
            {
                return "Hiba történt az adatok beszúrása során: " + ex.Message;
            }
        }

        public string Update(Uzenet uzenet)
        {
            try
            {
                using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
                {
                    string sql = "UPDATE uzenet SET szoveg = @szoveg, kuldesiido = @kuldesiido, uzenettipus = @uzenettipus, telefon = @telefon, email = @email WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@szoveg", uzenet.Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesiido", uzenet.KuldesiIdo);
                    cmd.Parameters.AddWithValue("@uzenettipus", uzenet.Uzenettipus);
                    cmd.Parameters.AddWithValue("@telefon", uzenet.Telefon);
                    cmd.Parameters.AddWithValue("@email", uzenet.Email);
                    cmd.Parameters.AddWithValue("@id", uzenet.Id);

                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres módosítás!";
                    }
                    else
                    {
                        return "Sikertelen módosítás!";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok szerkesztése során: " + ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
                {
                    string sql = "DELETE FROM uzenet WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);

                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres beszúrás!";
                    }
                    else
                    {
                        return "Sikertelen beszúrás!";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba az adatok törlése során: " + ex.Message;
            }
        }
    }
}