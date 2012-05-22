using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace DataBaseDesignCourse.GlobalFunc
{
    class Process
    {

        public virtual void dealReader(SqlDataReader reader)
        {

        }

        public virtual string getSQL()
        {
            return "*";
        }

    }
}
