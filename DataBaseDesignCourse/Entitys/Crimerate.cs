using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataBaseDesignCourse.Entitys
{
    class Crimerate : Entity
    {
        private string area;
        private int crimerate;
        private int accidentrate;


        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Crimerate";
        }

        public override bool getPrimaryKeyType()
        {
            return false;
        }

        public override string getTableName()
        {
            return "crimerate";
        }

        public override string getPrimaryKeyName()
        {
            return "area";
        }

        public override string getPrimaryKey()
        {
            return "'" + area + "'";
        }

        public override string getForeignKeyName()
        {
            return "*";
        }

        public override void fillData(SqlDataReader reader)
        {
            area = (string)reader.GetValue(0);
            crimerate = (int)reader.GetValue(1);
            accidentrate = (int)reader.GetValue(2);
        }
        public override string getMergeSQL()
        {
            string sql = "";

            sql +=("area=" + "'" + area + "' ,");
            sql += ("crimerate=" + crimerate + ",");
            sql += ("accidentrate=" + accidentrate);
            return sql;
        }
        public override string getPersistSQL()
        {
            string sql = "";

            sql += "'" + area + "',";
            sql += crimerate + ",";
            sql += accidentrate;
            return sql;
        }

        /***********************************/
        /* there are Set / Get functions   */
        /***********************************/
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
        public int CrimeRate
        {
            set
            {
                crimerate = value;
            }
            get
            {
                return crimerate;
            }
        }
        public int Accidentrate
        {
            set
            {
                accidentrate = value;
            }
            get
            {
                return accidentrate;
            }
        }
    }
}
