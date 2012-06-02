using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataBaseDesignCourse.Entitys;
using System.Drawing;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DataBaseDesignCourse.GlobalFunc;

namespace DataBaseDesignCourse
{
	/// <summary>
	/// Window1.xaml 的交互逻辑
	/// </summary>
    /// 

	public partial class Window1 : Window
	{


		public Window1()
		{
            try
            {
                this.InitializeComponent();
                BindBox.bindCitizenHometown(this.QueryHometown);
                BindBox.bindIDtypebox(this.QueryIDtype);
                BindBox.bindCasetype(this.QueryCaseType);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

		}
        
        /************************************************************************/
        /*                      Operation of Citizen                            */
        /************************************************************************/
        
        //select citizen value and read it
        private void CitizenListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Citizen c = (Citizen)this.CitizenList.SelectedItem;
            if (c == null)
            {
                return;
            }
            this.selectName.Text = c.Name;

            this.image1.Source = c.Photo;            

            DataManager ins = DataManager.createInstance();
            Police p = (Police)ins.FindOneToOne(c, Police.getClass());

            if (p == null)
            {
                this.isPolice.Text = "否";
                this.withGun.Text = "";
            }
            else
            {
                this.isPolice.Text = "是";
                this.withGun.Text = p.Withagun;
            }

            List<Entity>  cs = ins.FindOneToMany(c, Carmanager.getClass());
            ObservableCollection<Carmanager> carmanagertable = new ObservableCollection<Carmanager>();
            for (int i = 0; i < cs.Count; i++)
            {
                Carmanager ci = (Carmanager)cs[i];
                carmanagertable.Add(ci);
            }
            this.showLicence.ItemsSource = carmanagertable;

            List<Entity> cases = ins.FindManyToMany(c, Cases.getClass(), "case_person");
            ObservableCollection<Cases> casestable = new ObservableCollection<Cases>();
            for (int i = 0; i < cases.Count; i++)
            {
                Cases ci = (Cases)cases[i];
                casestable.Add(ci);
            }
            this.showCitizenCase.ItemsSource = casestable;

        }

        //refresh the citizen data
        private void CitizenRefreshClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.FindAll(Citizen.getClass());
            ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();
            for (int i = 0; i < cs.Count; i++)
            {
                Citizen ci = (Citizen)cs[i];
                cns.Add(ci);
            }
            CitizenList.ItemsSource = cns;
        }

        //delete one citizen
        private void CitizenDeleteClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Citizen c = (Citizen)this.CitizenList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再删除", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            if (ins.Delete(c))
            {
                System.Windows.MessageBox.Show("已经删除成功", "提示", System.Windows.MessageBoxButton.OK);
                ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CitizenList.ItemsSource;
                cns.Remove(c);
                this.CitizenList.ItemsSource = cns;               
            }
        }

        //modify one citizen
        private void CitizenModifyClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Citizen c = (Citizen)this.CitizenList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再修改", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            addCitizen cw = new addCitizen(true, c);
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CitizenList.ItemsSource;
                int index = cns.IndexOf(c);
                cns.Remove(c);

                c = (Citizen)cw.ModifyC;
                cns.Insert(index, c);
                //this.CitizenList.ItemsSource
            }
        }

        //add one citizen
        private void CitizenAddClick(object sender, RoutedEventArgs e)
        {
            addCitizen cw = new addCitizen(false, new Citizen());
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CitizenList.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Citizen>();
                }

                Citizen c = (Citizen)cw.ModifyC;
                cns.Add(c);
                this.CitizenList.ItemsSource = cns;
            }
        }

        //not accurate query
        private void QueryAboutClick(object sender, RoutedEventArgs e)
        {
            string thename = this.QueryCitizenName.Text;//name 0
            string thebirthday = this.QueryCitizenBirthday.Text;//birthday1
            string theaddress = this.QueryCitizenAddress.Text;//address2
            string thetelephone = this.QueryCitizenPhone.Text;//telephone3
            string thehometown = this.QueryHometown.Text;//hometown4
            string thegender = "";//gender5
            string thecrimestatus = "";//crimestatus6
            string thebefore = "'";
            string thedouhao = " and ";
            string thebehind = "'";
            int the_last_not_null = -1;
            if (QueryCitizenBoy.IsChecked == true)
            {
                thegender = "M";
            }
            if (QueryCitizenGirl.IsChecked == true)
            {
                thegender = "F";
            }
            if (QueryHasCrimeYes.IsChecked == true)
            {
                thecrimestatus = "!='无罪'";
            }
            if (QueryHasCrimeNo.IsChecked == true)
            {
                thecrimestatus = "='无罪'";
            }
            string[] thesearch = new string[7];
            string[] thesqls = new string[7];
            string sql = "";

            thesearch[0] = thename;
            thesearch[1] = thebirthday;
            thesearch[2] = theaddress;
            thesearch[3] = thetelephone;
            thesearch[4] = thehometown;
            thesearch[5] = thegender;
            thesearch[6] = thecrimestatus;
            for (int k = 0; k < 7; k++)
            {
                if (thesearch[k].Length != 0)
                {
                    the_last_not_null = k;
                }
            }
            if (the_last_not_null == -1)
            {
                System.Windows.MessageBox.Show("请至少输入一个查询值", "警告", System.Windows.MessageBoxButton.OK);
                return;
            }//弹出请至少输入一个查询值窗口
            thesqls[0] = ("name=" + thebefore + thename + thebehind);
            thesqls[1] = ("birthday=" + thebefore + thebirthday + thebehind);
            thesqls[2] = ("address=" + thebefore + theaddress + thebehind);
            thesqls[3] = ("telephone=" + thebefore + thetelephone + thebehind);
            thesqls[4] = ("hometown=" + thebefore + thehometown + thebehind);
            thesqls[5] = ("gender=" + thebefore + thegender + thebehind);
            thesqls[6] = ("crimestatus" + thecrimestatus);

            for (int i = 0; i < 7; i++)
            {
                if (thesearch[i] != "" && i != the_last_not_null)
                {
                    sql += thesqls[i];
                    sql += thedouhao;
                }
                if (thesearch[i] != "" && i == the_last_not_null)
                {
                    sql += thesqls[i];
                }
            }

            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.exeReadSQL(Citizen.getClass(), sql);
            ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();

            if (cs.Count == 0)
            {
                System.Windows.MessageBox.Show("无结果", "提示", System.Windows.MessageBoxButton.OK);
                CitizenList.ItemsSource = cns;
            }
       
            for (int i = 0; i < cs.Count; i++)
            {
                Citizen ci = (Citizen)cs[i];
                cns.Add(ci);
            }
            CitizenList.ItemsSource = cns;
        }

        //accurate query
        private void AccurateQueryClick(object sender, RoutedEventArgs e)
        {


            string theID = this.QueryID.Text;
            string sql;
            if (theID.Length == 0 || QueryIDtype.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请输入证件类型以及号码", "警告", System.Windows.MessageBoxButton.OK);
                return;
            }
            DataManager ins = DataManager.createInstance();

            if (QueryIDtype.Text == "身份证")
            {
                sql = ("ID=" + "'" + theID + "'");
                
                List<Entity> cs = ins.exeReadSQL(Citizen.getClass(), sql);
                ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();
                if (cs.Count == 0)
                {
                    System.Windows.MessageBox.Show("无结果", "提示", System.Windows.MessageBoxButton.OK);
                    this.CitizenList.ItemsSource = cns;
                    return;
                }
                for (int i = 0; i < cs.Count; i++)
                {
                    Citizen ci = (Citizen)cs[i];
                    cns.Add(ci);
                }
                CitizenList.ItemsSource = cns;
            }
            else if (QueryIDtype.Text == "驾照")
            {
                sql = ("drivinglicence=" + "'" + theID + "'");

                List<Entity> cs = ins.exeReadSQL(Carmanager.getClass(), sql);
                if (cs.Count == 0)
                {
                    System.Windows.MessageBox.Show("无结果", "提示", System.Windows.MessageBoxButton.OK);
                }
                ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();
                for (int i = 0; i < cs.Count; i++)
                {
                    Carmanager ca = (Carmanager)cs[i];
                    Citizen ci = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), ca.PKID);

                    cns.Add(ci);
                }
                CitizenList.ItemsSource = cns;
            }
        }

        //to decide if a man can have a gun
        private void hasGunClick(object sender, RoutedEventArgs e)
        {
            Citizen c = (Citizen)this.CitizenList.SelectedItem;
            if (c == null)
            {
                return;
            }
            DataManager ins = DataManager.createInstance();
            Police p = (Police)ins.FindOneToOne(c, Police.getClass());

            if (p == null)
            {
                System.Windows.MessageBox.Show("这个人不是警察！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            if (this.withGun.Text == "是")
            {
                this.withGun.Text = "否";
                p.Withagun = "否";
            }
            else if (this.withGun.Text == "否")
            {
                this.withGun.Text = "是";
                p.Withagun = "是";
            }
            ins.Merge(p);
        }

        //give a person license
        private void GiveLicenceClick(object sender, RoutedEventArgs e)
        {
            Citizen c = (Citizen)this.CitizenList.SelectedItem;
            if (c == null)
            {
                return;
            }
            addLiecse cw = new addLiecse(c);

            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Carmanager> cns = (ObservableCollection<Carmanager>)this.showLicence.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Carmanager>();
                }

                Carmanager cm = (Carmanager)cw.Cm;
                cns.Add(cm);
                this.showLicence.ItemsSource = cns;
            }
        }
        /************************************************************************/
        /*                      Operation of Cases                              */
        /************************************************************************/
        
        //refresh the cases data
        private void CasesRefreshClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.FindAll(Cases.getClass());
            ObservableCollection<Cases> cns = new ObservableCollection<Cases>();
            for (int i = 0; i < cs.Count; i++)
            {
                Cases ci = (Cases)cs[i];
                cns.Add(ci);
            }
            this.CasesList.ItemsSource = cns;
        }

        //When you select one case item
        private void CasesListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                return;
            }
            this.CasesContent.Text = c.Casedescribe;

            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.FindManyToMany(c, Citizen.getClass(), "case_person");
            if (cs != null)
            {
                ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();
                for (int i = 0; i < cs.Count; i++)
                {
                    Citizen ci = (Citizen)cs[i];
                    cns.Add(ci);
                }
                this.CaseRelatePerson.ItemsSource = cns;
            }
            else
            {
                this.CaseRelatePerson.ItemsSource = null;
            }

        }

        //Delete one case
        private void CaseDeleteClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再删除", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            ins.persistSQL("delete from case_person where caseID=" + c.getPrimaryKey());

            if (ins.Delete(c))
            {
                System.Windows.MessageBox.Show("已经删除成功", "提示", System.Windows.MessageBoxButton.OK);
                ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;
                cns.Remove(c);
                this.CasesList.ItemsSource = cns;
            }
        }

        //Add one case
        private void AddCaseClick(object sender, RoutedEventArgs e)
        {
            CaseWindow cw = new CaseWindow(new Cases());
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Cases>();
                }

                Cases c = (Cases)cw.Addcase;
                cns.Add(c);
                this.CasesList.ItemsSource = cns;
            }
        }

        //query the cases
        private void CaseQueryClick(object sender, RoutedEventArgs e)
        {
            int thecaseID = 0;
            string thetime;
            string thecaseaddress;
            string thecasetype;
            int the_last_not_null = -1;

            if (QueryCaseID.Text.Length != 0)
            {
                thecaseID = System.Int32.Parse(QueryCaseID.Text);//0
            }
                    
            thetime = QueryCaseTime.Text;//1
            thecaseaddress = QueryCaseAddress.Text;//2
            thecasetype = QueryCaseType.Text;//3
            string[] thesearch = new string[4];
            string[] thesqls = new string[4];
            string sql = "";
            string thebefore = "'";
            string thedouhao = " and ";
            string thebehind = "'";


            thesearch[0] = QueryCaseID.Text;
            thesearch[1] = thetime;
            thesearch[2] = thecaseaddress;
            thesearch[3] = thecasetype;
             for(int k = 0; k < 4; k++)
            {
                if(thesearch[k].Length != 0)
                {
                    the_last_not_null = k;
                }
            }
            if(the_last_not_null == -1)
            {
                System.Windows.MessageBox.Show("请至少输入一个查询值", "警告", System.Windows.MessageBoxButton.OK);
            }//弹出请至少输入一个查询值窗口
            thesqls[0] = ("caseID=" + thecaseID);
            thesqls[1] = ("time=" + thebefore + thetime + thebehind);
            thesqls[2] = ("caseaddress=" + thebefore + thecaseaddress + thebehind);
            thesqls[3] = ("casetype=" + thebefore + thecasetype + thebehind);
            for(int i = 0; i < 4; i++)
            {
                if(thesearch[i].Length != 0 && i != the_last_not_null)
                {
                    sql += thesqls[i];
                    sql += thedouhao;
                }
                if(thesearch[i].Length != 0 && i == the_last_not_null)
                {
                    sql += thesqls[i];
                }
            }
            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.exeReadSQL(Cases.getClass(),sql);
            ObservableCollection<Cases> cns = new ObservableCollection<Cases>();
            
            if (cs.Count == 0)
            {
                if (cs.Count == 0)
                {
                    System.Windows.MessageBox.Show("无结果", "提示", System.Windows.MessageBoxButton.OK);
                    this.CitizenList.ItemsSource = cns;
                    return;
                }
            }

            for (int i = 0; i < cs.Count; i++)
            {
                Cases ci = (Cases)cs[i];
                cns.Add(ci);
            }
            CasesList.ItemsSource = cns;
        }

        //build case
        private void BuildCaseClick(object sender, RoutedEventArgs e)
        {
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                return;
            }

            ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;
            int index = cns.IndexOf(c);
            cns.Remove(c);

            DataManager ins = DataManager.createInstance();
            c.Casestatus = "立案";

            cns.Insert(index, c);

            this.CasesList.ItemsSource = cns;
            

            ins.Merge(c);
        }

        //survey case
        private void SurveyCaseClick(object sender, RoutedEventArgs e)
        {
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                return;
            }

            ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;
            int index = cns.IndexOf(c);
            cns.Remove(c);

            DataManager ins = DataManager.createInstance();
            c.Casestatus = "调查";

            cns.Insert(index, c);

            this.CasesList.ItemsSource = cns;

            ins.Merge(c);
        }

        //trial case
        private void TrialCaseClick(object sender, RoutedEventArgs e)
        {
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                return;
            }

            ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;
            int index = cns.IndexOf(c);
            cns.Remove(c);

            DataManager ins = DataManager.createInstance();
            c.Casestatus = "审讯";

            cns.Insert(index, c);

            this.CasesList.ItemsSource = cns;

            ins.Merge(c);
        }

        //end case
        private void EndCaseClick(object sender, RoutedEventArgs e)
        {
            Cases c = (Cases)this.CasesList.SelectedItem;
            if (c == null)
            {
                return;
            }

            ObservableCollection<Cases> cns = (ObservableCollection<Cases>)this.CasesList.ItemsSource;
            int index = cns.IndexOf(c);
            cns.Remove(c);

            DataManager ins = DataManager.createInstance();
            c.Casestatus = "结案";

            cns.Insert(index, c);

            this.CasesList.ItemsSource = cns;

            ins.Merge(c);
        }
        /************************************************************************/
        /*                      Operation of Carinfo                            */
        /************************************************************************/
        
        //When you click the fresh button of carinfo
        private void CarRefreshClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.FindAll(Carinfo.getClass());
            ObservableCollection<Carinfo> cns = new ObservableCollection<Carinfo>();
            for (int i = 0; i < cs.Count; i++)
            {
                Carinfo ci = (Carinfo)cs[i];
                cns.Add(ci);
            }
            this.CarList.ItemsSource = cns;
        }

        //When you select one car item
        private void CarListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                return;
            }

            this.DisplayCarID.Text = c.CarID;
            this.DisplayCarInsurance.Text = c.Insurancedate;
            this.DisplayCarPurchaseTime.Text = c.Purchasetime;
            this.DisplayCarRemark.Text = c.Remark;
            this.DisplayCarStatus.Text = c.Status;
            this.DisplayCarstyle.Text = c.Carstyle;
            this.DisplayLastCheck.Text = c.Latestchecktime;


            DataManager ins = DataManager.createInstance();
            Citizen cz = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(),c.PKID);
            
            this.CarManagerName.Text = cz.Name;
            this.CarManagerPhoto.Source = cz.Photo;
            this.CarManagerHome.Text = cz.Hometown;

            if(cz.Gender == "F")
            {
                this.CarManagerGender.Text = "女";
            }
            else if(cz.Gender == "M")
            {
                this.CarManagerGender.Text = "男";
            }

            List<Entity> cl = ins.FindOneToMany(c, Accident.getClass());



            ObservableCollection<Accident> caradt = new ObservableCollection<Accident>();
            ObservableCollection<Accident> carbkrule = new ObservableCollection<Accident>();
            for (int i = 0; i < cl.Count; i++)
            {
                Accident ci = (Accident)cl[i];
                if (ci.Type == "事故")
                    caradt.Add(ci);
                else if (ci.Type == "违规")
                    carbkrule.Add(ci);
            }
            this.CarAccident.ItemsSource = caradt;
            this.CarBreakRule.ItemsSource = carbkrule;
        }

        //query the car
        private void QueryCarinfoClick(object sender, RoutedEventArgs e)
        {
            string carID = this.QueryCarID.Text;
            string managername = this.QueryManagerName.Text;
            string sql = "";
            if (carID.Length == 0 && managername.Length == 0)
            {
                System.Windows.MessageBox.Show("请输入一项", "警告", System.Windows.MessageBoxButton.OK);
            }

            if (carID.Length != 0 && managername.Length == 0)
            {
                sql = ("carID=" + "'" + carID + "'");
            }
           
            if (managername.Length != 0 && carID.Length == 0)
            {
                sql = ("ID=" + "'" + managername + "'");
            }

            if (managername.Length != 0 && carID.Length != 0)
            {
                sql = ("carID=" + "'" + carID + "'") + " and " + ("ID=" + "'" + managername + "'");
            }

            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.exeReadSQL(Carinfo.getClass(), sql);
            ObservableCollection<Carinfo> cns = new ObservableCollection<Carinfo>();
            for(int i = 0; i < cs.Count; i++)
            {
                Carinfo ci = (Carinfo)cs[i];
                cns.Add(ci);
            }
            this.CarList.ItemsSource = cns;
        }

        //add car
        private void AddCarinfoClick(object sender, RoutedEventArgs e)
        {
            addCar cw = new addCar(false, new Carinfo());
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Carinfo> cns = (ObservableCollection<Carinfo>)this.CarList.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Carinfo>();
                }

                Carinfo c = (Carinfo)cw.Thecar;
                cns.Add(c);
                this.CarList.ItemsSource = cns;
            }
        }

        //delete car
        private void DeleteCarinfoClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再删除", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            if (ins.Delete(c))
            {
                System.Windows.MessageBox.Show("已经删除成功", "提示", System.Windows.MessageBoxButton.OK);
                ObservableCollection<Carinfo> cns = (ObservableCollection<Carinfo>)this.CarList.ItemsSource;
                cns.Remove(c);
                this.CarList.ItemsSource = cns;
            }
        }

        //modify the carinfo
        private void ModifyCarinfoClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再修改", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            addCar cw = new addCar(true, c);
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Carinfo> cns = (ObservableCollection<Carinfo>)this.CarList.ItemsSource;
                int index = cns.IndexOf(c);
                cns.Remove(c);

                c = (Carinfo)cw.Thecar;

                this.DisplayCarID.Text = c.CarID;
                this.DisplayCarInsurance.Text = c.Insurancedate;
                this.DisplayCarPurchaseTime.Text = c.Purchasetime;
                this.DisplayCarRemark.Text = c.Remark;
                this.DisplayCarStatus.Text = c.Status;
                this.DisplayCarstyle.Text = c.Carstyle;
                this.DisplayLastCheck.Text = c.Latestchecktime;

                cns.Insert(index, c);
                //this.CitizenList.ItemsSource
            }
        }

        //add break rule info
        private void AddBreakRuleClick(object sender, RoutedEventArgs e)
        {
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再修改", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            addAccident cw = new addAccident("违规", c.CarID);
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Accident> cns = (ObservableCollection<Accident>)this.CarBreakRule.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Accident>();
                }

                Accident ac = (Accident)cw.Ac;
                cns.Add(ac);
                this.CarBreakRule.ItemsSource = cns;
            }
        }

        //delete break rule info
        private void DeleteBreakRuleClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Accident c = (Accident)this.CarBreakRule.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再删除", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            if (ins.Delete(c))
            {
                System.Windows.MessageBox.Show("已经删除成功", "提示", System.Windows.MessageBoxButton.OK);
                ObservableCollection<Accident> cns = (ObservableCollection<Accident>)this.CarBreakRule.ItemsSource;
                cns.Remove(c);
                this.CarBreakRule.ItemsSource = cns;
            }
        }

        //add accident info
        private void AddAccidentClick(object sender, RoutedEventArgs e)
        {
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再修改", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            addAccident cw = new addAccident("事故", c.CarID);
            cw.Owner = this;

            if (cw.ShowDialog() ?? false)
            {
                ObservableCollection<Accident> cns = (ObservableCollection<Accident>)this.CarAccident.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Accident>();
                }

                Accident ac = (Accident)cw.Ac;
                cns.Add(ac);
                this.CarAccident.ItemsSource = cns;
            }
        }

        //delete accident info
        private void DeleteAccidentClick(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();
            Accident c = (Accident)this.CarAccident.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择后再删除", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            if (ins.Delete(c))
            {
                System.Windows.MessageBox.Show("已经删除成功", "提示", System.Windows.MessageBoxButton.OK);
                ObservableCollection<Accident> cns = (ObservableCollection<Accident>)this.CarAccident.ItemsSource;
                cns.Remove(c);
                this.CarAccident.ItemsSource = cns;
            }
        }

        //display license
        private void DisplayLicenceClick(object sender, RoutedEventArgs e)
        {
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择汽车！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            DataManager ins = DataManager.createInstance();
            Citizen cz = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), c.PKID);

            List<Entity> listc = ins.FindOneToMany(cz, Carmanager.getClass());
            string license = "驾照为：\n";

            if (listc == null || listc.Count == 0)
            {
                System.Windows.MessageBox.Show("没有驾照，非法驾驶", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            for (int i = 0; i < listc.Count; i++)
            {
                Carmanager cm = (Carmanager)listc[i];
                license += (cm.Drivinglicence + "  " + cm.Drivinglicencetype);
                license += "\n";
            }


            System.Windows.MessageBox.Show(license, "提示", System.Windows.MessageBoxButton.OK);
        }
        
        //display ID
        private void DisplayIDClick(object sender, RoutedEventArgs e)
        {
            Carinfo c = (Carinfo)this.CarList.SelectedItem;
            if (c == null)
            {
                System.Windows.MessageBox.Show("请选择汽车！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            DataManager ins = DataManager.createInstance();
            Citizen cz = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), c.PKID);

            System.Windows.MessageBox.Show("身份证为：" + c.PKID, "提示", System.Windows.MessageBoxButton.OK);
        }
        /************************************************************************/
        /*                      Operation of Police                             */
        /************************************************************************/

        //when you click the canvas, it will be reflect
        private void clickCanvas(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p;
            p = e.GetPosition(this.themap);
            System.Windows.MessageBox.Show((int)p.X + "," + (int)p.Y, "提示", System.Windows.MessageBoxButton.OK);
        }

        //allocate the police
        private void AllocatePoliceClick(object sender, RoutedEventArgs e)
        {
            AllotPolice ap = new AllotPolice();
            ap.Allot();
            System.Windows.MessageBox.Show("分配成功！", "提示", System.Windows.MessageBoxButton.OK);

        }
        /************************************************************************/
        /*                      Operation of Simulation                            */
        /************************************************************************/
        
        //to simulate a process
        private void SimulationClick(object sender, RoutedEventArgs e)
        {
            inputMonthBox imb = new inputMonthBox();

            if (imb.ShowDialog() ?? false)
            {
                int month = imb.Monthnum;
                makecase mc = new makecase();
                makecrimerate mm = new makecrimerate();

                int total = mc.make_case(month);
                mm.make_crimerate();

                AddIncome2 ai = new AddIncome2();
                int income = ai.GetAllIncome(month);
                
                System.Windows.MessageBox.Show("生成事件共" + total + "条。\n总收入：" + income + "元", "提示", System.Windows.MessageBoxButton.OK);
                
            }
        }



    }
}