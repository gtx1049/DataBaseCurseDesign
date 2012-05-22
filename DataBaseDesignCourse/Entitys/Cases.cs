using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace DataBaseDesignCourse.Entitys
{
    class Cases : Entity
    {
        private int caseID; //案件编号   主码
        private string casetype;
        private string casedescribe;        //
        private string casestatus; //
        private string caseaddress;//地址
        private DateTime time;//案件登记时间
        

        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Cases";
        }
        public override bool getPrimaryKeyType()
        {
            return true;
        }

        public override string getTableName()
        {
            return "cases";
        }

        public override string getPrimaryKeyName()
        {
            return "caseID";
        }

        public override string getPrimaryKey()
        {
            return caseID.ToString() ;
        }

        public override string getForeignKeyName()
        {
            return "*";
        }
        //you must override this function so that you can fill the object
        public override void fillData(SqlDataReader reader)
        {

            caseID =(int)reader.GetValue(0);
            casetype = (string)reader.GetValue(1);
            casedescribe = (string)reader.GetValue(2);
            casestatus = (string)reader.GetValue(3);
            caseaddress = (string)reader.GetValue(4);
            time = (DateTime)reader.GetValue(5);
        
 
        }

        public override string getMergeSQL()
        {
            string sql = "";
            //sql += ("caseID=" + "" + caseID + " ,");
            sql += ("casetype=" + "'" + casetype + "' ,");
            sql += ("casedescribe=" + "'" + casedescribe + "' ,");
            sql += ("casestatus=" + "'" + casestatus + "' ,");
            sql += ("caseaddress=" + "'" + caseaddress + "' ,");
            sql += ("time=" + "'" + time.ToString() + "'");

            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";
            //sql += caseID.ToString() + ",";
            sql += "'" + casetype + "',";
            sql += "'" + casedescribe + "',";
            sql += "'" + casestatus + "',";
            sql += "'" + caseaddress + "',";
            sql += "'" + time.ToString() + "'";
         
            return sql;
        }
        public int CaseID
        {
            set
            {
                caseID = value;
            }
            get
            {
                return caseID;
            }
        }//
        public string Casetype
        {
            set
            {
                casetype = value;
            }
            get 
            {
                return casetype;
            }
        }
        public string Casedescribe
        {
            set
            {
                casedescribe = value;
            }
            get
            {
                return casedescribe;
            }
        }//
        public string Casestatus
        {
            set
            {
                casestatus = value;
            }
            get
            {
                return casestatus;
            }
        }
        public string Caseaddress
        {
            set
            {
                caseaddress = value;
            }
            get
            {
                return caseaddress;
            }
        }//
     
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
        }//

      
 

    }
}
