using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseDesignCourse.Entitys
{
    class Carmanager : Entity
    {
        private string drivinglicence;
        private string drivinglicencetype;
        private int point;
        private string ID;

        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Carmanager";
        }

        public override bool getPrimaryKeyType()
        {
            return false;
        }

        public override string getTableName()
        {
            return "carmanager";
        }

        public override string getPrimaryKeyName()
        {
            return "drivinglicence";
        }

        public override string getForeignKeyName()
        {
            return "ID";
        }

        public override string getPrimaryKey()
        {
            return "'" + drivinglicence + "'";
        }

        public override void fillData(SqlDataReader reader)
        {
            drivinglicence = (string)reader.GetValue(0);
            drivinglicencetype = (string)reader.GetValue(1);
            point = (int)reader.GetValue(2);
            ID = (string)reader.GetValue(3);
        }

        public override string getMergeSQL()
        {
            string sql = "";
            sql += ("drivinglicence=" + "'" + drivinglicence + "' ,");
            sql += ("drivinglicencetype=" + "'" + drivinglicencetype + "' ,");
            sql += ("point=" +  point + ",");
            sql += ("ID=" + "'" + ID + "'");

          return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";
            sql += "'" + drivinglicence + "',";
            sql += "'" + drivinglicencetype + "',";
            sql += point + ",";
            sql += "'" + ID + "'";
           return sql;
        }

        public string Drivinglicence
        {
            set
            {
                drivinglicence = value;
            }
            get
            {
                return drivinglicence;
            }
        }

        public string Drivinglicencetype
        {
            set
            {
                drivinglicencetype = value;
            }
            get
            {
                return drivinglicencetype;
            }
        }

        public int Point
        {
            set
            {
                point = value;
            }
            get
            {
                return point;
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
