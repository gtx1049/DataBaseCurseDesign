using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace DataBaseDesignCourse.Entitys
{
    class Citizen : Entity
    {
        private string ID;
        private string name;
        private string gender;
        private string hometown;
        private string address;
        private string telephone;
        private DateTime birthday;
        private string crimestatus;
        private BitmapImage photo;
        private int tax;

        //every Entity class have its own type
        static public string getClass()
        {
            return "DataBaseDesignCourse.Entitys.Citizen";
        }

        public override bool getPrimaryKeyType()
        {
            return false;
        }

        public override string getTableName()
        {
            return "citizen";
        }

        public override string getPrimaryKeyName()
        {
            return "ID";
        }

        public override string getPrimaryKey()
        {
            return "'" + ID + "'";
        }

        public override string getForeignKeyName()
        {
            return "*";
        }
        //you must override this function so that you can fill the object
        public override void fillData(SqlDataReader reader)
        {
            ID = (string)reader.GetValue(0);
            name = (string)reader.GetValue(1);
            gender = (string)reader.GetValue(2);
            hometown = (string)reader.GetValue(3);
            address = (string)reader.GetValue(4);
            telephone = (string)reader.GetValue(5);
            birthday = (DateTime)reader.GetValue(6);
            crimestatus = (string)reader.GetValue(7);
            if (reader[8].GetType() != typeof(DBNull))
            {
                byte[] bs = (byte[])reader[8];
                MemoryStream memoryStream = new MemoryStream(bs);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                photo = new BitmapImage();
                photo.BeginInit();

                photo.CacheOption = BitmapCacheOption.OnLoad;
                photo.StreamSource = memoryStream;
                photo.EndInit();
                photo.Freeze();

            }
            else
            {
                photo = null;
            }
            tax = (int)reader.GetValue(9);
        }

        public override string getMergeSQL()
        {
            string sql = "";
            sql += ("ID=" + "'" + ID + "' ,");
            sql += ("name=" + "'" + name + "' ,");
            sql += ("gender=" + "'" + gender + "' ,");
            sql += ("hometown=" + "'" + hometown + "' ,");
            sql += ("address=" + "'" + address + "' ,");
            sql += ("telephone=" + "'" + telephone + "' ,");
            sql += ("birthday=" + "'" + birthday.ToString() + "' ,");
            sql += ("crimestatus=" + "'" + crimestatus + "' ,");
            
            if(photo != null)
            {
                byte[] imageData = new byte[photo.StreamSource.Length];
                photo.StreamSource.Seek(0, System.IO.SeekOrigin.Begin);
                photo.StreamSource.Read(imageData, 0, imageData.Length);

                

                sql += ("photo=" + bytetoString(imageData) + ",");
            }
            sql += ("tax=" + tax);

            return sql;
        }

        public override string getPersistSQL()
        {
            string sql = "";
            sql += "'" + ID + "',";
            sql += "'" + name + "',";
            sql += "'" + gender + "',";
            sql += "'" + hometown + "',";
            sql += "'" + address + "',";
            sql += "'" + telephone + "',";
            sql += "'" + birthday.ToString() + "',";
            sql += "'" + crimestatus + "',";
            if (photo == null)
            {
                sql += "null,";
            }
            else
            {
                byte[] imageData = new byte[photo.StreamSource.Length];
                photo.StreamSource.Seek(0, System.IO.SeekOrigin.Begin);
                photo.StreamSource.Read(imageData, 0, imageData.Length);

                sql += (bytetoString(imageData) + ",");
            }
            sql += tax;
            return sql;
        }
        //convert the byte array to 0x string, reference to the net
        private string bytetoString(byte[] bs)
        {
            string  hexstr = "0x";
            for (int i=0; i < bs.Length; i++)
            {
                char hex1;
                char hex2;
                int value = bs[i]; //直接将unsigned char赋值给整型的值，系统会正动强制转换
                int v1 = value/16;
                int v2 = value % 16;

                //将商转成字母
                if (v1 >= 0 && v1 <= 9)
                {
                    hex1 = (char)(48 + v1);
                }
                else
                {
                    hex1 = (char)(55 + v1);
                }
                //将余数转成字母
                if (v2 >= 0 && v2 <= 9)
                {
                    hex2 = (char)(48 + v2);
                }
                else
                {
                    hex2 = (char)(55 + v2);
                }
                //将字母连接成串
                hexstr = hexstr + hex1 + hex2;
            }
            return hexstr;

        }
        /***********************************/
        /* there are Set / Get functions   */
        /***********************************/
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
        public string Name
        {
            set
            {
                Name = value;
            }
            get
            {
                return name;
            }
        }
        public string Gender
        {
            set
            {
                gender = value;
            }
            get
            {
                return gender;
            }
        }
        public string Hometown
        {
            set
            {
                hometown = value;
            }
            get
            {
                return hometown;
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
        public string Telephone
        {
            set
            {
                telephone = value;
            }
            get
            {
                return telephone;
            }
        }
        public string Birthday
        {
            set
            {
                birthday = Convert.ToDateTime(value);
            }
            get
            {
                return birthday.ToShortDateString();
            }
        }
        public string Crimestatus
        {
            set
            {
                crimestatus = value;
            }
            get
            {
                return crimestatus;
            }
        }
        public BitmapImage Photo
        {
            set
            {
                photo = value;
            }
            get
            {
                return photo;
            }
        }
        public int Tax
        {
            set
            {
                tax = value;
            }
            get
            {
                return tax;
            }
        }
    }
}
