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
	/// Window1.xaml 的交互逻辑
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			this.InitializeComponent();
            DataManager ins = DataManager.createInstance();
            Citizen c = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), "210703199104272017");
            Citizen c2 = (Citizen)ins.FindbyPrimaryKey(Citizen.getClass(), "130824199005210010");
            c.getID();
            c2.getID();
            // 在此点之下插入创建对象所需的代码。
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
	}
}