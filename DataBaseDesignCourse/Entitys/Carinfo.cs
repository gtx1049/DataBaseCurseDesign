using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace DataBaseDesignCourse.Entitys
{

    class Carinfo: Entity
    {
        private string carID; //
        private string carstyle; //车类型
        private DateTime purchasetime;
        private DateTime latestchecktime;        //
        private DateTime insurancedate; //
        private string remark;
        private string status;
        private string ID; ////

        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Carinfo";
        }
        public override bool getPrimaryKeyType()
        {
            return false;
        }

        public override string getTableName()
        {
            return "carinfo";
        }

        public override string getPrimaryKeyName()
        {
            return "carID";
        }

        public override string getPrimaryKey()
        {
            return "'" + carID.ToString() + "'";
        }

        public override string getForeignKeyName()
        {
            return "ID";
        }

        //you must override this function so that you can fill the object
        public override void fillData(SqlDataReader reader)
        {
   
            carID = (string)reader.GetValue(0);
            carstyle = (string)reader.GetValue(1);
            purchasetime = (DateTime)reader.GetValue(2);
            latestchecktime = (DateTime)reader.GetValue(3);
            insurancedate = (DateTime)reader.GetValue(4);
             remark = (string)reader.GetValue(5);
             status = (string)reader.GetValue(6);
             ID = (string)reader.GetValue(7);


        }

        public override string getMergeSQL()
        {
            string sql = "";
            sql += ("carID=" + "'" + carID + "' ,");
            sql += ("carstyle=" + "'" + carstyle + "' ,");
            sql += ("purchasetime=" + "'" + purchasetime.ToString() + "' ,");
            sql += ("latestchecktime=" + "'" + latestchecktime.ToString() + "' ,");
            sql += ("insurancedate=" + "'" + insurancedate.ToString() + "' ,");
            sql += ("remark=" + "'" + remark + "' ,");
            sql += ("status=" + "'" + status + "',");
            sql += ("ID=" + "'" + ID + "'");

            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";
            sql += "'" + carID + "',";
            sql += "'" + carstyle+ "',";
            sql += "'" + purchasetime.ToString() + "',";
            sql += "'" + latestchecktime.ToString() + "',";
            sql += "'" + insurancedate.ToString() + "',";
            sql += "'" + remark + "',";
            sql += "'" + status + "',";
            sql += "'" + ID + "'";

            return sql;
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
        }//
        public string Carstyle
        {
            set
            {
                carstyle = value;
            }
            get
            {
                return carstyle;
            }
        }//
        public string Purchasetime
        {
            set
            {
                purchasetime = Convert.ToDateTime(value);
            }
            get
            {
                return purchasetime.ToShortDateString();
            }
        }//
        public string Latestchecktime
        {
            set
            {
                latestchecktime = Convert.ToDateTime(value);
            }
            get
            {
                return latestchecktime.ToShortDateString();
            }
        }//
        public string Insurancedate
        {
            set
            {
                insurancedate = Convert.ToDateTime(value);
            }
            get
            {
                return insurancedate.ToShortDateString();
            }
        }//
        public string Remark
        {
            set
            {
                remark = value;
            }
            get
            {
                return remark;
            }
        }//
        public string Status
        {
            set 
            {
                status = value;
            }
            get
            {
                return status;
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
        }//
    }
}
