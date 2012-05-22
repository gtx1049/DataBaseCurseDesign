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
			this.InitializeComponent();

            //Police p = new Police();
            //p.PKID = "210703199104272017";
            //p.PKpoliceID = 0;
            //p.Policetype = "刑警";
            //p.Area = "嘉定区";
            //p.Withagun = "是";
            //p.Salary = 100;

            //Carmanager c = new Carmanager();
            //c.PKID = "210703199104272017";
            //c.Drivinglicence = "辽G00000";
            //c.Drivinglicencetype = "大卡";
            //c.Point = 200;

            //Crimerate c = new Crimerate();
            //c.Area = "嘉定区";
            //c.CrimeRate = 2;
            //c.Accidentrate = 1;
            //Publicplace p = new Publicplace();
            //p.Address = "上海市嘉定区公安消防支队";
            //p.Introduction = "相信我们的消防实力";
            //p.Spending = 20;

            //Accident a = new Accident();
            //a.Address = "同济大学";
            //a.Time = "2012-5-20 21:40:01";
            //a.Accidentcontent = "撞车后损毁";
            //a.CarID = "辽G00000";
            //a.Type = "事故";

            //Cases c = new Cases();
            //c.Caseaddress = "同济";
            //c.Casetype = "刑事";
            //c.Casedescribe = "高天星的钱被偷了";
            //c.Casestatus = "调查";
            //c.Time = "2012-5-20";

            //Carinfo c = new Carinfo();
            //c.CarID = "辽G00000";
            //c.Carstyle = "大卡";
            //c.Purchasetime = "2012-1-10";
            //c.Latestchecktime = "2012-1-11";
            //c.Insurancedate = "2020-1-10";
            //c.Remark = "一辆可以超神的车";
            //c.Status = "在用";
            //c.PKID = "210703199104272017";


            DataManager ins = DataManager.createInstance();
            //Police p = (Police)ins.FindbyPrimaryKey(Police.getClass(), 1);
            //Carmanager c = (Carmanager)ins.FindbyPrimaryKey(Carmanager.getClass(), "辽G00000");
            //Crimerate c = (Crimerate)ins.FindbyPrimaryKey(Crimerate.getClass(), "嘉定区");
            //p.Salary = 120;
            //c.Point = 300;
            //ins.Merge(c);
           // Publicplace p = (Publicplace)ins.FindbyPrimaryKey(Publicplace.getClass(), 1);
            //p.Introduction = "我们是无敌的！";
           // c.Accidentrate = 3;
            //Accident a = (Accident)ins.FindbyPrimaryKey(Accident.getClass(), 1);
            //a.Accidentcontent = "撞成渣滓了！";
            //Cases c = (Cases)ins.FindbyPrimaryKey(Cases.getClass(), 1);
            //c.Casetype = "刑事";
            Carinfo c = (Carinfo)ins.FindbyPrimaryKey(Carinfo.getClass(), "辽G00000");
            c.Remark = "这真是一辆可以超神的车";
            ins.Merge(c);
            //Citizen c = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), "210703199104272017");
            //Citizen c2 = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), "130824199005210010");
            //string s = c.PKID;

            //c2.getID();

            //this.image1.Source = c2.Photo;
            //c.Photo = new BitmapImage();
            //c.Photo.BeginInit();
            //c.Photo.StreamSource = System.IO.File.OpenRead("D:\\gtx.jpg");
            //c.Photo.EndInit();
            //ins.Merge(c);
            
            
            // 在此点之下插入创建对象所需的代码。
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
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
            }
            else
            {
                this.isPolice.Text = "是";
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

        private void CarListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        
    }
}