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
using DataBaseDesignCourse.GlobalFunc;
using System.Collections.ObjectModel;

namespace DataBaseDesignCourse
{
	/// <summary>
	/// addCar.xaml 的交互逻辑
	/// </summary>
	public partial class addCar : Window
	{
        private bool ismodify;
        private Carinfo thecar;
        private Citizen themanager;

		public addCar(bool ismodify, object o)
		{
			this.InitializeComponent();
            BindBox.bindCarType(this.CarType);
            BindBox.bindCarStatus(this.CarStatus);
			// 在此点之下插入创建对象所需的代码。


            thecar = (Carinfo)o;

            this.ismodify = ismodify;
            if (ismodify)
            {

                this.CarID.IsEnabled = false;

                this.CarID.Text = thecar.CarID;

                this.CarType.Text = thecar.Carstyle.TrimEnd();
                this.CarStatus.Text = thecar.Status.TrimEnd();

                this.PurchaseTime.Text = thecar.Purchasetime;
                this.Insurance.Text = thecar.Insurancedate;
                this.LastCheckTime.Text = thecar.Latestchecktime;
                this.CarRemark.Text = thecar.Remark;

                this.CarOfPersonID.Text = thecar.PKID;
            }

		}

        public object Thecar
        {
            get
            {
                return thecar;
            }
        }

        private void sure_Click(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();

            if (this.PurchaseTime.Text.Length == 0 ||
                this.LastCheckTime.Text.Length == 0 ||
                this.Insurance.Text.Length == 0 ||
                this.CarID.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            thecar.CarID = this.CarID.Text;
            thecar.Status = this.CarStatus.Text;
            thecar.Carstyle = this.CarType.Text;

            if (this.CarRemark.Text.Length == 0)
            {
                thecar.Remark = "无";
            }

            try
            {
                thecar.Purchasetime = this.PurchaseTime.Text;
                thecar.Latestchecktime = this.LastCheckTime.Text;
                thecar.Insurancedate = this.Insurance.Text;
            }
            catch (System.FormatException ex)
            {
                ex.ToString();
                System.Windows.MessageBox.Show("请将时间格式设置为yyyy-mm-dd！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            if (this.CarOfPersonID.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请提供车主！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            else
            {
                thecar.PKID = this.CarOfPersonID.Text;
            }

            this.DialogResult = true;

            if (ismodify)
            {
                ins.Merge(thecar);
            }
            else
            {
                if (!ins.Persist(thecar))
                {
                    System.Windows.MessageBox.Show("发生了错误！", "提示", System.Windows.MessageBoxButton.OK);
                    return;
                }
            }
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void changePerson_Click(object sender, RoutedEventArgs e)
        {
            selectCitizen sc = new selectCitizen();
            if (sc.ShowDialog() ?? false)
            {
                Citizen c = (Citizen)sc.Addo;
                themanager = c;
                this.CarOfPersonID.Text = c.PKID;
            }
        }
	}
}