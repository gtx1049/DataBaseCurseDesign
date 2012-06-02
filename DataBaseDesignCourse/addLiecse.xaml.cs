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

namespace DataBaseDesignCourse
{
    /// <summary>
    /// addLiecse.xaml 的交互逻辑
    /// </summary>
    public partial class addLiecse : Window
    {
        private Carmanager cm;
        private Citizen cz;

        public addLiecse(object o)
        {
            InitializeComponent();
            BindBox.bindCarType(this.LicenseType);

            cz = (Citizen)o;
            cm = new Carmanager();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void sure_Click(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();

            if (this.License.Text.Length == 0 ||
                this.LicenseType.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            cm.Drivinglicence = this.License.Text;
            cm.Drivinglicencetype = this.LicenseType.Text;
            cm.PKID = cz.PKID;
            cm.Point = 200;

            this.DialogResult = true;

            if (!ins.Persist(cm))
            {
                System.Windows.MessageBox.Show("ID发生了冲突！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            
            this.Close();
        }

        public object Cm
        {
            get
            {
                return cm;
            }
        }
    }
}
