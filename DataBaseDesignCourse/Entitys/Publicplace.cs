using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace DataBaseDesignCourse.Entitys
{
    class Publicplace : Entity
    {
        private int placeID;
        private string address;
        private int spending;
        private string introduction;
         static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Publicplace";
        }

        public override bool getPrimaryKeyType()
        {
            return true;
        }

        public override string getTableName()
        {
            return "publicplace";
        }

        public override string getPrimaryKeyName()
        {
            return "placeID";
        }

        public override string getPrimaryKey()
        {
            return "'" + placeID + "'";
        }

        public override string getForeignKeyName()
        {
            return "*";
        }

        //you must override this function so that you can fill the object
        public override void fillData(SqlDataReader reader)
        {
            placeID = (int)reader.GetValue(0);
            address = (string)reader.GetValue(1);
            introduction = (string)reader.GetValue(2);
            spending = (int)reader.GetValue(3);
        }
          

        public override string getMergeSQL()
        {
            string sql = "";
            //sql += ("placeID=" + "'" + placeID + "' ,");
            sql += ("address=" + "'" + address + "' ,");
            sql += ("introduction=" + "'" + introduction + "' ,");
            sql += ("spending=" + "'" + spending + "' ");
            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";
            //sql += "'" + placeID + "',";
            sql += "'" + address + "',";
            sql += "'" + introduction + "',";
            sql += "'" + spending + "'";   
            return sql;
        }
        /***********************************/
        /* there are Set / Get functions   */
        /***********************************/
        public int PlaceID
        {
            set
            {
                placeID = value;
            }
            get
            {
                return placeID;
            }
        }
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        public string Introduction
        {
            set
            {
                introduction = value;
            }
            get
            {
                return introduction;
            }
        }
        public int Spending
        {
            set
            {
                spending = value;
            }
            get
            {
                return spending;
            }
        }
    }
}
