using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysData
{
    public class DatabaseComunication
    {
        MySqlConnection conn;
        MySqlDataReader reader;
        string connStr;

        public DatabaseComunication()
        {
             connStr = "Server=studmysql01.fhict.local;Uid=dbi476237;Database=dbi476237;Pwd=root;";
           //connStr = "Server=DESKTOP-G7473BL; Port=3306; Database=TournamentData; Uid=root; Pwd=root; SslMode=Preferred;";
            //connStr = "Server=DESKTOP-41OPBTP; Port=3306; Database=TournamentData; Uid=root; Pwd=root; SslMode=Preferred;";
        }
        //works for edditing deleting and adding
        public void SendQueryWithNoResult(string query, Dictionary<string, dynamic> info)
        {

            conn = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            foreach (var item in info)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            reader = cmd.ExecuteReader();
            conn.Close();
            reader.Close();
        }
        //works for retreving all kinds of data
        //TODO: find a better way to do this
        public List<T> Get<T>(string query, Dictionary<string, dynamic> info)
        {

            conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();

            List<T> items = new List<T>(); 


            foreach (var item in info)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            reader = cmd.ExecuteReader();
            dt.Load(reader);

            foreach (DataRow dr in dt.Rows)
            {
                items.Add(GetItem<T>(dr));
            }
            reader.Close();
            conn.Close();
            return items;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (var item in temp.GetProperties())
                {
                    if (item.Name == column.ColumnName)
                        try
                        {
                            item.SetValue(obj, dr[column.ColumnName], null);
                        }
                        catch (ArgumentException)
                        {
                          item.SetValue(obj, dr[column.ColumnName].ToString(), null);
                        }
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}
