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
        private Bitmap photo;
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
        //you must override this function so that you can fill the object
        public override void fillData(SqlDataReader reader)
        {
            if (reader.Read())
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
                    photo = new Bitmap(memoryStream);
                }
                else
                {
                    photo = null;
                }
                tax = (int)reader.GetValue(9);
            }
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
                MemoryStream stream = new MemoryStream();
                photo.Save(stream, ImageFormat.Png);
                byte[] bys = stream.ToArray();
                sql += ("photo=" + bys + ",");
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
                MemoryStream stream = new MemoryStream();
                photo.Save(stream, ImageFormat.Png);
                byte[] bys = stream.ToArray();
                sql += (bys + ",");
            }
            sql += tax;

            return sql;
        }
        /***********************************/
        /* there are Set / Get functions   */
        /***********************************/
        public void setID(string ID)
        {
            this.ID = ID;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setGender(string gender)
        {
            this.gender = gender;
        }

        public void setHometown(string hometown)
        {
            this.hometown = hometown;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public void setTelephone(string telephone)
        {
            this.telephone = telephone;
        }

        public void setBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        public void setCrimestatus(string crimestatus)
        {
            this.crimestatus = crimestatus;
        }

        public void setPhoto(Bitmap photo)
        {
            this.photo = photo;
        }

        public void setTax(int tax)
        {
            this.tax = tax;
        }

        public string getID()
        {
            return ID;
        }

        public string getName()
        {
            return name;
        }

        public string getGender()
        {
            return gender;
        }

        public string getHometown()
        {
            return hometown;
        }

        public string getAddress()
        {
            return address;
        }

        public string getTelephone()
        {
            return telephone;
        }

        public DateTime getBirthday()
        {
            return birthday;
        }

        public string getCrimestatus()
        {
            return crimestatus;
        }

        public Bitmap getPhoto()
        {
            return photo;
        }

        public int getTax()
        {
            return tax;
        }
    }
}
