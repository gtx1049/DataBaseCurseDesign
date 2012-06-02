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
using DataBaseDesignCourse.GlobalFunc;
using DataBaseDesignCourse.Entitys;
using System.Collections.ObjectModel;

namespace DataBaseDesignCourse
{
	/// <summary>
	/// CaseWindow.xaml 的交互逻辑
	/// </summary>
	public partial class CaseWindow : Window
	{
        Cases addcase;

		public CaseWindow(object o)
		{
			this.InitializeComponent();

            BindBox.bindCasetype(this.CaseType);

            addcase = (Cases)o;
			// 在此点之下插入创建对象所需的代码。
		}

        private void sure_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            DataManager ins = DataManager.createInstance();

            if(this.CaseAddress.Text.Length == 0 || 
               this.CaseContent.Text.Length == 0 ||
               this.CaseTime.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            if(this.CaseSurvey.IsChecked == false &&
               this.CaseTrial.IsChecked == false &&
               this.CaseBuild.IsChecked == false &&
               this.CaseFinish.IsChecked == false)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            if (this.CaseFinish.IsChecked == true)
            {
                addcase.Casestatus = "结案";
            }
            else if (this.CaseSurvey.IsChecked == true)
            {
                addcase.Casestatus = "调查";
            }
            else if (this.CaseTrial.IsChecked == true)
            {
                addcase.Casestatus = "审讯";
            }
            else if (this.CaseBuild.IsChecked == true)
            {
                addcase.Casestatus = "立案";
            }

            addcase.Casetype = this.CaseType.Text;
            addcase.Casedescribe = this.CaseContent.Text;
            addcase.Caseaddress = this.CaseAddress.Text;

            try
            {
                addcase.Time = this.CaseTime.Text;
            }
            catch (System.FormatException ex)
            {
                ex.ToString();
                System.Windows.MessageBox.Show("请将时间格式设置为yyyy-mm-dd hh-mm-ss！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CaseRelatedPersonList.ItemsSource;

            if (cns == null || cns.Count == 0)
            {
                ins.Persist(addcase);
                this.Close();
            }
            else
            {
                ins.Persist(addcase);

                class_getMcaseID maxcaseID = new class_getMcaseID();
                ins.exeProcessSQL(maxcaseID);
                addcase.CaseID = maxcaseID.max_case_id;

                for (int i = 0; i < cns.Count; i++)
                {
                    ins.PersistManyToManyRelation(addcase, cns[i], "case_person");
                }
                this.Close();
            }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public object Addcase
        {
            get 
            {
                return (object)addcase;
            }
        }

        private void addCase_Click(object sender, RoutedEventArgs e)
        {
            selectCitizen sc = new selectCitizen();
            if(sc.ShowDialog() ?? false)
            {
                ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CaseRelatedPersonList.ItemsSource;

                if (cns == null)
                {
                    cns = new ObservableCollection<Citizen>();
                }

                Citizen c = (Citizen)sc.Addo;
                cns.Add(c);
                this.CaseRelatedPersonList.ItemsSource = cns;
            }
        }

        private void deletCase_Click(object sender, RoutedEventArgs e)
        {
            Citizen c = (Citizen)this.CaseRelatedPersonList.SelectedItem;

            if (c == null)
            {
                return;
            }

            ObservableCollection<Citizen> cns = (ObservableCollection<Citizen>)this.CaseRelatedPersonList.ItemsSource;
            cns.Remove(c);
        }
	}
}