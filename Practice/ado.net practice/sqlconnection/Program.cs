using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;


//using MySql.Data.MySqlClient;
using MySqlConnector;
class Program
{
    static void Main()
    {
        //string connStr = "Server=localhost;Port=3306;Database=my_db1;Uid=root;Pwd=Sayan@2005;";
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connected successfully!");

                //-----Learning Command and reader-------
                //string query = "SELECT * FROM users";
                //using (MySqlCommand cmd = new MySqlCommand(query, conn))

                //using (MySqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        Console.WriteLine($"{reader["id"]} - {reader["username"]}");
                //    }
                //}

                //------Learning async data reader-------
                //using (MySqlDataReader reader = await cmd.ExecuteReaderAsync()) // need static "async" void Main() to work
                //{
                //    while(await reader.ReadAsync())
                //    { ... }
                //}
                //---------------------------------------

                //------Learning data adapter------------
                //DataTable dt = new DataTable();
                //string query = "Select * from users where id % @num = 0";
                //using (MySqlCommand cmd = new MySqlCommand(query, conn))
                //{
                //    cmd.Parameters.AddWithValue("@num", 2);
                //    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                //    {

                //        adapter.Fill(dt);
                //    }
                //}

                //foreach (DataRow row in dt.Rows)
                //{
                //    Console.WriteLine($"{row["id"]} - {row["username"]}");
                //}

                DataTable dt = new DataTable();
                string query = "Select * from users where id % @num = 0";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@num", 2);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {

                        adapter.Fill(dt);

                        // --- UPDATE --- Modify data locally in memory
                        //if (dt.Rows.Count > 0)
                        //{
                        //    dt.Rows[0]["username"] = "shivam"; // Modify existing row
                        //}

                        //        //// --- CREATE --- Add a new row locally
                        //        //DataRow newRow = dt.NewRow();
                        //        //newRow["username"] = "new_user";
                        //        //dt.Rows.Add(newRow);
                        //        //adapter.Update(dt);

                        // --- DELETE --- delete a row
                        DataRow[] foundRows = dt.Select("Select * from users");
                        foreach (DataRow row in dt.Rows)
                        {
                            row.Delete();
                        }
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    Console.WriteLine($"{row["id"]} - {row["username"]}");
                        //}
                        Console.WriteLine(dt.Rows.Count);
                        // All the rows with even id which has username new_user has been deleted!
                        adapter.Update(dt);
                        Console.WriteLine(dt.Rows.Count);
                    }
                    //}
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    Console.WriteLine($"{row["id"]} - {row["username"]}");
                    //}

                    //---------------------------------------
                    //insert
                    //string query1 = "insert into users (username) values (@somename)";
                    //using MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    ////
                    //cmd1.Parameters.AddWithValue("@somename", "bob"); 
                    //int rowsAffected = cmd1.ExecuteNonQuery();
                    ////
                    //DataTable dt1 = new DataTable();
                    //using MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                    //// also adapter only needs connection
                    //using MySqlCommandBuilder builder1 = new MySqlCommandBuilder(adapter1);
                    //adapter1.Fill(dt1);
                    //DataRow row1 = dt.NewRow();
                    //row1["username"] = "John";
                    //dt.Rows.Add(row1);

                }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}