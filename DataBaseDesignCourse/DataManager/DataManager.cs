using System;
using System.Collections.Generic;
using System.Text;
using DataBaseDesignCourse.Entitys;
using System.Data.SqlClient;

namespace DataBaseDesignCourse
{

    class DataManager
    {
        private SqlConnection connection;
        private string connectionstring;
        static private DataManager instance;

 

        private DataManager()
        {
            //connection the data base from here
            connectionstring = "Data Source=CHINA-2A781551C;Initial Catalog=PublicSafety;Integrated Security=True";
            connection = new SqlConnection(connectionstring);
        }

        static public DataManager createInstance()
        {
            //singleton design pattern
            if (instance == null)
            {
                instance = new DataManager();                
            }
            return instance;
        }

        public Entity FindbyPrimaryKey(string type, object primarykey)
        {
            Type table = Type.GetType(type);
            object o = System.Activator.CreateInstance(table);
            Entity theentity = (Entity)o;

            string sql = "select * from " + theentity.getTableName() +
             " where " + theentity.getPrimaryKeyName() + " = ";

            if (theentity.getPrimaryKeyType())
            {
                Int32 pk = (Int32)primarykey;
                try
                {
                    sql += pk.ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                string pk = (string)primarykey;
                try
                {
                    sql += "'" + pk.ToString() + "'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    theentity.fillData(reader);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return theentity;
        }

        public bool Merge(Entity e)
        {
            try
            {
                string sql = "update " + e.getTableName() + " set ";
                sql += e.getMergeSQL();
                sql += " where " + e.getPrimaryKeyName() + " = " + e.getPrimaryKey();

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Persist(Entity e)
        {
            try
            {
                string sql = "insert into " + e.getTableName() + " values";
                sql += "(" + e.getPersistSQL() + ")";
           
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
