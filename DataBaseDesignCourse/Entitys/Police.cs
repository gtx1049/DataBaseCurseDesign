using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace DataBaseDesignCourse.Entitys
{
    class Police : Entity
    {
        private int policeID;
        private string policetype;
        private string area;
        private string withagun;
        private int salary;
        private string ID;


        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Police";
        }

        public override bool getPrimaryKeyType()
        {
            return true;
        }

        public override string getTableName()
        {
            return "police";
        }

        public override string getPrimaryKeyName()
        {
            return "policeID";
        }

        public override string getPrimaryKey()
        {
            return policeID.ToString();
        }

        public override string getForeignKeyName()
        {
            return "ID";
        }

        public override void fillData(SqlDataReader reader)
        {
            policeID = (int)reader.GetValue(0);
            policetype = (string)reader.GetValue(1);
            if (reader[2].GetType() != typeof(DBNull))
            {
                area = reader[2].ToString();
            }
            else
            {
                area = null;
            }
            withagun = (string)reader.GetValue(3);
            salary = (int)reader.GetValue(4);
            ID = (string)reader.GetValue(5);
        }

        public override string getMergeSQL()
        {
            string sql = "";

            //sql += ("policeID=" + policeID + ",");
            sql += ("policetype=" + "'" + policetype + "' ,");
            if (area != null)
            {
                sql += ("area=" + "'" + area + "' ,");
            }
            sql += ("withagun=" + "'" + withagun + "' ,");
            sql += ("salary=" + salary + ",");
            sql += ("ID=" + "'" + ID + "'");
            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";

            //sql += "'" + policeID + "' ,";
            sql += "'" + policetype + "' ,";
            if (area == null)
            {
                sql += "null,";
            }
            else
            {
                sql += "'"  + area + "' ,";
            }
            sql += "'" + withagun + "' ,";
            sql += "'" + salary + "' ,";
            sql += "'" + ID + "'";
            return sql;
        }

        /***********************************/
        /* there are Set / Get functions   */
        /***********************************/

        public int PKpoliceID
        {
            set
            {
                policeID = value;
            }
            get
            {
                return policeID;
            }
        }
        public string Policetype
        {
            set
            {
                policetype = value;
            }
            get
            {
                return policetype;
            }
        }
        public string Area
        {
            set
            {
                area = value;
            }
            get
            {
                return area;
            }
        }
        public string Withagun
        {
            set
            {
                withagun = value;
            }
            get
            {
                return withagun;
            }
        }
        public int Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return salary;
            }
        }
        public string PKID
        {
            set
            {
                ID = value;
            }
            get
            {
                return ID;
            }
        }
    }
}
