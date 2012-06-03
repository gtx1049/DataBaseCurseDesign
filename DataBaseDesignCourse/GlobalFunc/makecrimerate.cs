using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseDesignCourse.Entitys;

namespace DataBaseDesignCourse.GlobalFunc
{
    class makecrimerate
    {
        Crimerate one_crimerate = new Crimerate();
        Random random_number = new Random();
        List<Entity> list;
        List<Entity> list2;
        List<Entity> list3;
        DataManager datamanager = DataManager.createInstance();

       
        public void make_crimerate()
        {
            int[] crime_number_in_places = { 0, 0, 0, 0, 0 };
            int[] accident_number_in_places = { 0, 0, 0, 0, 0 };
            list = datamanager.FindAll(Crimerate.getClass());
          

            int cases_in_all;
            int accident_in_all;

            list2= datamanager.FindAll(Cases.getClass());
            cases_in_all = list2.Count;
            list3 = datamanager.FindAll(Accident.getClass());
            accident_in_all = list3.Count;
            //每个地区的犯罪数量
            for (int i = 0; i < list2.Count; i++)
            {
                if(((Cases)list2[i]).Caseaddress[0] == '嘉')
                    crime_number_in_places[0]++;
                else if(((Cases)list2[i]).Caseaddress[0] == '普')
                    crime_number_in_places[1]++;
                else if (((Cases)list2[i]).Caseaddress[0] == '长')
                    crime_number_in_places[2]++;
                else if (((Cases)list2[i]).Caseaddress[0] == '静')
                    crime_number_in_places[3]++;
                else if (((Cases)list2[i]).Caseaddress[0] == '黄')
                    crime_number_in_places[4]++;

            }
            for (int i = 0; i < list3.Count; i++)
            {
                if (((Accident)list3[i]).Address[0] == '嘉')
                    accident_number_in_places[0]++;
                else if (((Accident)list3[i]).Address[0] == '普')
                    accident_number_in_places[1]++;
                else if (((Accident)list3[i]).Address[0] == '长')
                    accident_number_in_places[2]++;
                else if (((Accident)list3[i]).Address[0] == '静')
                    accident_number_in_places[3]++;
                else if (((Accident)list3[i]).Address[0] == '黄')
                    accident_number_in_places[4]++;
            }



                //首先判断是不是空表



                if (list.Count <= 1) // 原本没有表，要新生成表
                {
                    //float temp_propotion = 0;
                    one_crimerate.Area = "嘉定区";
                    one_crimerate.CrimeRate = crime_number_in_places[0] * 100 / cases_in_all;
                    //one_crimerate.CrimeRate = (int)temp_propotion*100;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[0] / accident_in_all;
                    datamanager.Persist(one_crimerate);

                    one_crimerate.Area = "普陀区";
                    one_crimerate.CrimeRate = crime_number_in_places[1] * 100 / cases_in_all;
                    //one_crimerate.CrimeRate = (int)temp_propotion*100;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[1] / accident_in_all;
                    datamanager.Persist(one_crimerate);



                    one_crimerate.Area = "长宁区";
                    one_crimerate.CrimeRate = crime_number_in_places[2] * 100 / cases_in_all;
                    //one_crimerate.CrimeRate = (int)temp_propotion*100;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[2] / accident_in_all;
                    datamanager.Persist(one_crimerate);

                    one_crimerate.Area = "静安区";
                    one_crimerate.CrimeRate = crime_number_in_places[3] * 100 / cases_in_all;
                    //one_crimerate.CrimeRate = (int)temp_propotion*100;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[3] / accident_in_all;
                    datamanager.Persist(one_crimerate);

                    one_crimerate.Area = "黄浦区";
                    one_crimerate.CrimeRate = crime_number_in_places[4] * 100 / cases_in_all;
                    //one_crimerate.CrimeRate = (int)temp_propotion*100;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[4] / accident_in_all;
                    datamanager.Persist(one_crimerate);


                }
                else if (list.Count > 1)
                {
                    //float temp_propotion = 0;
                    one_crimerate.Area = "嘉定区";

                    one_crimerate.CrimeRate = 100 * crime_number_in_places[0] / cases_in_all;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[0] / accident_in_all;
                    datamanager.Merge(one_crimerate);

                    one_crimerate.Area = "普陀区";
                    one_crimerate.CrimeRate = 100 * crime_number_in_places[1] / cases_in_all;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[1] / accident_in_all;
                    datamanager.Merge(one_crimerate);



                    one_crimerate.Area = "长宁区";
                    one_crimerate.CrimeRate = 100 * crime_number_in_places[2] / cases_in_all;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[2] / accident_in_all;
                    datamanager.Merge(one_crimerate);

                    one_crimerate.Area = "静安区";
                    one_crimerate.CrimeRate = 100 * crime_number_in_places[3] / cases_in_all;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[3] / accident_in_all;
                    datamanager.Merge(one_crimerate);

                    one_crimerate.Area = "黄浦区";
                    one_crimerate.CrimeRate = 100 * crime_number_in_places[4] / cases_in_all;
                    one_crimerate.Accidentrate = 100 * accident_number_in_places[4] / accident_in_all;
                    datamanager.Merge(one_crimerate);
                }
            
        }
    }
}
