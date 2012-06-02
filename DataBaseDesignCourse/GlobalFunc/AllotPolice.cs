using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DataBaseDesignCourse.Entitys;
using DataBaseDesignCourse;
using System.Data.SqlClient;

namespace DataBaseDesignCourse.GlobalFunc
{
    class AllotPolice
    {
        private DataManager dataManager = DataManager.createInstance();
        private Hashtable ht = new Hashtable();

        public AllotPolice()
        {
        }
        public void Allot()
        {
            List<Entity> crimeRate = dataManager.FindAll("Crimerate");
            List<Entity> police = dataManager.FindAll("Police");

            int PoliceCount = police.Count();
            int CrimeCount = 0;
            int pointer = 0;

            foreach (Crimerate crime in crimeRate)
            {
                CrimeCount += crime.CrimeRate;
            }

            foreach (Crimerate crimerate in crimeRate)
            {
                float PoliceNumOfArea = crimerate.CrimeRate * PoliceCount / CrimeCount;
                int number = (int)Math.Round(PoliceNumOfArea);

                if (number != 0)
                {
                    List<Entity> smallPolice = police.GetRange(pointer, number);
                    foreach (Police entity in smallPolice)
                    {
                        string sql = "UPDATE Police SET area = " + crimerate.Area + " WHERE policeID = " + entity.getPrimaryKey();
                        dataManager.persistSQL(sql);
                    }

                    pointer += number;
                }

                ht.Add(crimerate.Area, number);
            }
        }
        public int PoliceOfArea(string area)
        {
            foreach (DictionaryEntry de in this.ht)
            {
                if (Convert.ToString(de.Key) == area)
                {
                    return Convert.ToInt32(de.Value);
                }
            }

            return 0;
        }
    }
}
