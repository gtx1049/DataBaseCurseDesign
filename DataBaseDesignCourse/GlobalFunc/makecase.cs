using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseDesignCourse.Entitys;


namespace DataBaseDesignCourse.GlobalFunc
{
    class makecase
    {
        public makecase()
        {
        }
      
        Random random_number=new Random();
        DateTime dt=Convert.ToDateTime("2007-1-1");
        Cases one_case;
        //string str;
        class_getMcaseID class_help_id = new class_getMcaseID();
        DataManager datamanager = DataManager.createInstance();
        List <Entity> list_place;
        List<Entity> list_cititzen;
        List<Entity> list_carinfo;

        Accident one_accident;
        class_getMaccidentID class_help_accident_id=new class_getMaccidentID();
        string []case_describe={"在好乐迪KTV唱歌时，因喝酒过多，砸坏门店的放音设备。",
                                                    "邻居报警，家中发生严重家庭暴力，导致一人眼角受伤，一人骨折",
                                                   "外出旅游时遇上交通事故，保险公司拒绝赔付，当事人带着亲友堵在保险公司门口",
                                                   "当事人借给同学现金1000，之后同学拒绝归还，遂报警",
                                                    "妻子出轨，丈夫捉奸在床后打伤第三者，妻子报警，要求调解。",       
                                                    "与情敌决斗时被设计陷害，现要求经济赔偿。"
                               };
        string[] case_penal_describe={"因仇恨杀掉同事，碎尸后抛入后山，10天后被抓获",
                                                    "盗窃20余户人家，终于被保安发现而被抓获",
                                                   "因为跟同学产生口角，用铁铲把人砸死，后自首",
                                                   "富二代开车撞伤人后，反而冲上去连刺8刀，造成受害者死亡",
                                                    "夜晚无人时，专盯少女在黑暗的小巷里行走，冲上去施行性犯罪",       
                                                    "等大款从银行里取钱出来，用枪袭击，抢的钱款30万"
                                     };
        string[] accident_penal_describe ={"大卡车因为驾驶员不小心，稍稍碰到了前方行驶的摩托车，摩托车瞬间飞出，司机当场死亡",
                                                    "在高速公路上不遵守限速规定，超速行驶，刹车不及，撞死翻越护栏闯入的行人",
                                                   "喝醉了酒危险驾驶，对红绿灯视而不见，直接与对面车辆相撞",
                                                   "富二代开车撞伤人后，反而冲上去连刺8刀，造成受害者死亡",
                                                    "与前车发生追尾",       
                                                    "没有驾驶证胡乱开车，导致汽车发生自燃事件"
                                     };
        string[] accident_violation_describe ={"在公路边随意乱停车",
                                                    "严重超速行驶，超速百分之200",
                                                   "醉酒驾驶",
                                                   "在街边随意停车",
                                                    "无视红绿灯",       
                                                    "逆向行驶"
                                     };


        public int make_case(int how_many_months)
        {
            int case_number_per_month = random_number.Next(8);
            if (case_number_per_month == 0)
                case_number_per_month++;
            //每月有多少事件完成。
            int accident_number_per_month=random_number.Next(7);
            if (case_number_per_month == 0)
                case_number_per_month++;
            //每月有多少交通事故完成。
            int cases_in_total = case_number_per_month * how_many_months;
            int accident_in_total=accident_number_per_month*how_many_months;

            list_place = datamanager.FindAll(Publicplace.getClass());
            list_cititzen = datamanager.FindAll(Citizen.getClass());
            list_carinfo = datamanager.FindAll(Carinfo.getClass());

            for (int i = 0; i < cases_in_total; i++) //案件生成和存入数据库
            {
                one_case = new Cases();
                //得到ID值

                if (random_number.Next(100) > 50)//民事
                {
                    one_case.Casetype = "民事";
                    one_case.Casedescribe = case_describe[random_number.Next(6)];

                    //list=datamanager.FindAll(Publicplace.getClass());
                    int temp=random_number.Next(list_place.Count);


                    one_case.Caseaddress = ((Publicplace)list_place[temp]).Address;
                    one_case.Casestatus = "调查";
                }
                else
                {
                     one_case.Casetype = "刑事";
                    one_case.Casedescribe = case_penal_describe[random_number.Next(6)];

                    //list=datamanager.FindAll(Publicplace.getClass());
                    int temp=random_number.Next(list_place.Count);


                    one_case.Caseaddress = ((Publicplace)list_place[temp]).Address;
                    one_case.Casestatus = "调查";
                }
                dt=Convert.ToDateTime("2007-1-1");
                dt = dt.AddYears(random_number.Next(5));
                dt = dt.AddMonths(random_number.Next(12));
                dt = dt.AddDays(random_number.Next(30));
                one_case.Time=dt.ToString();

                datamanager.Persist(one_case);
                datamanager.exeProcessSQL(class_help_id);
                int temp_number = class_help_id.max_case_id;
                //temp_number++;//得到下一个要生成的id号。
                one_case.CaseID = temp_number;

                //得到人
                // list=datamanager.FindAll(Citizen.getClass());
                temp_number = random_number.Next(3) + 1;
                if (temp_number > list_cititzen.Count)
                    temp_number = list_cititzen.Count;

                

                for(int j=0;j<temp_number;j++)
                {
                    datamanager.PersistManyToManyRelation(one_case, ((Citizen)list_cititzen[random_number.Next(list_cititzen.Count)]), "case_person");                
                }
            }


            for(int i=0;i<accident_in_total;i++)//生成交通事故并存入数据库
            {
                one_accident=new Accident();
                datamanager.exeProcessSQL(class_help_accident_id);
                int temp_number=class_help_accident_id.max_accident_id;
                temp_number++;//得到下一个要生成的id号。
                one_accident.AccidentID=temp_number;

                //下面赋值carid
                  //list=datamanager.FindAll(Carinfo.getClass());
                    int temp=random_number.Next(list_carinfo.Count);
                one_accident.CarID=((Carinfo)list_carinfo[temp]).CarID;

               //下面address
                      //list=datamanager.FindAll(Publicplace.getClass());
                    temp=random_number.Next(list_place.Count);
                    one_accident.Address = ((Publicplace)list_place[temp]).Address;
                //下面time
                 dt=Convert.ToDateTime("2007-1-1");
                dt = dt.AddYears(random_number.Next(5));
                dt = dt.AddMonths(random_number.Next(12));
                dt = dt.AddDays(random_number.Next(30));
                one_accident.Time=dt.ToString();
                //下面类型和描述
                if(random_number.Next(100)>50)//事故
                {
                    one_accident.Type="事故";
                    one_accident.Accidentcontent = accident_penal_describe[random_number.Next(6)];
                }
                else
                {
                    one_accident.Type = "违规";
                    one_accident.Accidentcontent = accident_violation_describe[random_number.Next(6)];
                }

                //下面存入
                datamanager.Persist(one_accident);
            }

            return cases_in_total + accident_in_total;

        }
    }
}
