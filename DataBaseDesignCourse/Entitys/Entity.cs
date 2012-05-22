using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseDesignCourse.Entitys
{
    class Entity
    {
        //if return true, it's int, else char
        public virtual bool getPrimaryKeyType()
        {
            return false;
        }
        
        public virtual string getTableName()
        {
            return "*";
        }

        public virtual string getPrimaryKeyName()
        {
            return "*";
        }

        public virtual string getPrimaryKey()
        {
            return "*";
        }

        public virtual string getForeignKeyName()
        {
            return "*";
        }

        //use SqlDataReader to fill one Entity
        public virtual void fillData(SqlDataReader reader)
        {

        }

        public virtual string getMergeSQL()
        {
            return "*";
        }

        public virtual string getPersistSQL()
        {
            return "*";
        }
    }
}
