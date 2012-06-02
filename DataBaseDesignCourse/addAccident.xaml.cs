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

namespace DataBaseDesignCourse
{
    /// <summary>
    /// addAccident.xaml 的交互逻辑
    /// </summary>
    public partial class addAccident : Window
    {
        private Accident ac;

        public addAccident(string type, string carid)
        {
            InitializeComponent();

            ac = new Accident();

            ac.Type = type;
            ac.CarID = carid;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void sure_Click(object sender, RoutedEventArgs e)
        {
            if(this.accidentAddress.Text.Length == 0 ||
               this.accidentTime.Text.Length == 0 ||
               this.accidentContent.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            ac.Accidentcontent = this.accidentContent.Text;
            ac.Address = this.accidentAddress.Text;
            try
            {
                ac.Time = this.accidentTime.Text;
            }
            catch (System.FormatException ex)
            {
                ex.ToString();
                System.Windows.MessageBox.Show("请将时间格式设置为yyyy-mm-dd hh-mm-ss！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            DataManager ins = DataManager.createInstance();
            if (!ins.Persist(ac))
            {
                System.Windows.MessageBox.Show("发生了未知错误！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        public object Ac
        {
            get
            {
                return ac;
            }
        }
    }
}
