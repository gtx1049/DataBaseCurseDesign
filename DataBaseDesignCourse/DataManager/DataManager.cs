using System;
using System.Collections.Generic;
using System.Text;
using DataBaseDesignCourse.Entitys;
using System.Data.SqlClient;
using System.Data;
using DataBaseDesignCourse.GlobalFunc;

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
            if (connection == null)
            {
                System.Windows.MessageBox.Show("连接数据库失败", "提示", System.Windows.MessageBoxButton.OK);
            }
        }

        //You can get the instance of the DataManager
        static public DataManager createInstance()
        {
            //singleton design pattern
            if (instance == null)
            {
                instance = new DataManager();                
            }
            return instance;
        }

        //Find an entity through the primary key
        public Entity FindbyPrimaryKey(string type, object primarykey)
        {
            Type table = Type.GetType(type);
            object o = System.Activator.CreateInstance(table);
            Entity theentity = (Entity)o;

            string sql = "select * from " + theentity.getTableName() +
             " where " + theentity.getPrimaryKeyName() + " = ";

            if (theentity.getPrimaryKeyType())
            {
                Int32 pk = Convert.ToInt32(primarykey);
                try
                {
                    sql += pk.ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        theentity.fillData(reader);
                    }
                    else
                    {
                        return null;
                    }
                    reader.Close();
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
                string pk = primarykey.ToString();
                try
                {
                    sql += "'" + pk.ToString() + "'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        theentity.fillData(reader);
                    }
                    else
                    {
                        return null;
                    }
                    reader.Close();
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

        //You can write your sql of one table and get it
        public List<Entity> exeReadSQL(string type, string condition)
        {
            Type table = Type.GetType(type);
            Entity theentity = (Entity)System.Activator.CreateInstance(table);

            string sql = "select * from " + theentity.getTableName() + " where ";

            sql += condition;

            List<Entity> list = new List<Entity>();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    object o = System.Activator.CreateInstance(table);
                    Entity e = (Entity)o;
                    e.fillData(reader);
                    list.Add(e);
                }

                reader.Close();
                return list;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        //You can write your own sql and store the data through override Process class
        public bool exeProcessSQL(Process pro)
        {
            try
            {
                string sql = pro.getSQL();
                if (sql == "*")
                {
                    return false;
                }
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                pro.dealReader(reader);
                reader.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        //You can write your own sql about save and update
        public bool persistSQL(string sql)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery() ;
                return true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        //Get all entity in one table
        public List<Entity> FindAll(string type)
        {
            Type table = Type.GetType(type);
            Entity theentity = (Entity)System.Activator.CreateInstance(table);

            string sql = "select * from " + theentity.getTableName();

            List<Entity> list = new List<Entity>();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    object o = System.Activator.CreateInstance(table);
                    Entity e = (Entity)o;
                    e.fillData(reader);
                    list.Add(e);
                }
                
                reader.Close();
                return list;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }
            
        }

        //Find out the relating entity to one you choose, 1st arg is the choose one, 2nd arg is the target
        public List<Entity> FindOneToMany(Entity keytable, string target)
        {
            Type table = Type.GetType(target);
            Entity theentity = (Entity)System.Activator.CreateInstance(table);

            if (theentity.getForeignKeyName() == "*")
            {
                return null;
            }

            string sql = "select * from " + theentity.getTableName() + " where ";
            sql += theentity.getForeignKeyName() + "=" + keytable.getPrimaryKey();

            List<Entity> list = new List<Entity>();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    object o = System.Activator.CreateInstance(table);
                    Entity e = (Entity)o;
                    e.fillData(reader);
                    list.Add(e);
                }

                reader.Close();
                return list;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        //Find out one to one relation
        public Entity FindOneToOne(Entity keytable, string target)
        {
            Type table = Type.GetType(target);
            object o = System.Activator.CreateInstance(table);
            Entity theentity = (Entity)o;

            if (theentity.getForeignKeyName() == "*")
            {
                return null;
            }

            string sql = "select * from " + theentity.getTableName() + " where ";
            sql += theentity.getForeignKeyName() + "=" + keytable.getPrimaryKey();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    theentity.fillData(reader);
                    reader.Close();
                    return theentity;
                }
                else
                {
                    return null;
                }                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        //Find out the many to many relation
        public List<Entity> FindManyToMany(Entity e, string target, string relation)
        {
            Type table = Type.GetType(target);
            object o = System.Activator.CreateInstance(table);
            Entity theentity = (Entity)o;

            string sql = "select " + theentity.getPrimaryKeyName() + " from " + relation;
            sql += " where " + e.getPrimaryKeyName() + " = " + e.getPrimaryKey();

            List<Entity> list = new List<Entity>();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                List<object> pk = new List<object>();

                while(reader.Read())
                {
                    object tempvalue = reader.GetValue(0);
                    pk.Add(tempvalue);
                }
                reader.Close();

                for (int i = 0; i < pk.Count; i++)
                {
                    string onesql = "select * from " + theentity.getTableName() +
                                    " where " + theentity.getPrimaryKeyName() + " = ";

                    if (!theentity.getPrimaryKeyType())
                    {
                        onesql += "'" + pk[i].ToString() + "'";
                    }
                    else
                    {
                        onesql += pk[i].ToString();
                    }
                    
                    SqlCommand onecmd = new SqlCommand(onesql, connection);
                    SqlDataReader onereader = onecmd.ExecuteReader();
                    if (onereader.Read())
                    {
                        object theo = System.Activator.CreateInstance(table);
                        Entity thee = (Entity)theo;
                        thee.fillData(onereader);
                        list.Add(thee);
                    }
                    onereader.Close();
                }

                    //reader();
                return list;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                connection.Close();
                
            }
        }

        //Save many to many relation
        public bool PersistManyToManyRelation(Entity first, Entity second, string table)
        {
            string sql = "insert into " + table + " values ";
            sql += ("(" + first.getPrimaryKey() + "," + second.getPrimaryKey() + ")");
            try
            {
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

        //Update one entity
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

        //Save one entity in database
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

        //Delete one entity from database
        public bool Delete(Entity e)
        {
            string sql = "delete from " + e.getTableName() +
                         " where " + e.getPrimaryKeyName() + " = ";
            sql += e.getPrimaryKey();
            try
            {
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

        //return dataview to create a report
        public DataTable getDataTable(string selectcmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = null;

            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(selectcmd, connection);
                adapter.Fill(dt);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                connection.Close();
                
            }
            finally
            {
                connection.Close();
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }


            return dt;
        }
    }
}
