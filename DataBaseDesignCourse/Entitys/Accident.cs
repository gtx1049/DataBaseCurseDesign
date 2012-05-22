using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseDesignCourse.Entitys
{
    class Accident : Entity
    {
        private int accidentID;
        private string address;
        private DateTime time; 
        private string accientcontent;
        private string type;
        private string carID;

        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Accident";
        }

        public override bool getPrimaryKeyType()
        {
            return true;
        }

        public override string getTableName()
        {
            return "accident";
        }

        public override string getPrimaryKeyName()
        {
            return "accidentID";
        }

        public override string getPrimaryKey()
        {
            return accidentID.ToString();
        }

        public override string getForeignKeyName()
        {
            return "carID";
        }

        public override void fillData(SqlDataReader reader)
        {
            accidentID = (int)reader.GetValue(0);
            address = (string)reader.GetValue(1);
            time = (DateTime)reader.GetValue(2);
            accientcontent = (string)reader.GetValue(3);
            type = (string)reader.GetValue(4);
            carID = (string)reader.GetValue(5);
        }

        public override string getMergeSQL()
        {
            string sql = "";
 
            sql += ("address=" + "'" + address + "' ,");
            sql += ("time=" + "'" + time.ToString() + "' ,");
            sql += ("accidentcontent=" + "'" + accientcontent + "' ,");
            sql += ("type=" + "'" + type + "' ,");
            sql += ("carID=" + "'" + carID + "'");

            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";

            sql += "'" + address + "',";
            sql += "'" + time.ToString() + "',";
            sql += "'" + accientcontent + "',";
            sql += "'" + type + "',";
            sql += "'" + carID + "'";
           
            return sql;
        }

        public int AccidentID
        {
            set
            {
                accidentID = value;
            }
            get
            {
                return accidentID;
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

        public string Time
        {
            set
            {
                time = Convert.ToDateTime(value);
            }
            get
            {
                return time.ToShortDateString();
            }
        }
        public string Accidentcontent
        {
            set
            {
                accientcontent = value;
            }
            get
            {
                return accientcontent;
            }
        }

        public string Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }

        public string CarID
        {
            set
            {
                carID = value;
            }
            get
            {
                return carID;
            }
        }


    }
}
