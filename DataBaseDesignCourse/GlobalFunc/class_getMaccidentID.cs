using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataBaseDesignCourse.GlobalFunc
{
    class class_getMaccidentID : Process
    {
        public int max_accident_id = -1;//默认状态负一

        public override void dealReader(SqlDataReader reader)
        {
            max_accident_id = -1;
            reader.Read();
            max_accident_id = (int)reader.GetValue(0);

        }

        public override string getSQL()
        {
            return "select MAX(accidentID) from accident";
        }
    }
}
