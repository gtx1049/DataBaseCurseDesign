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

namespace DataBaseDesignCourse
{
    /// <summary>
    /// inputMonthBox.xaml 的交互逻辑
    /// </summary>
    public partial class inputMonthBox : Window
    {
        private int monthnum;

        public inputMonthBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.monthcount.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请输入月数值", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            try
            {
                monthnum = Convert.ToInt32(this.monthcount.Text);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                System.Windows.MessageBox.Show("您的输入有误", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        public int Monthnum
        {
            get
            {
                return monthnum;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
