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
    /// table.xaml 的交互逻辑
    /// </summary>
    public partial class table : Window
    {
        private System.Windows.Forms.DataGridView listDataGrid;

        public table(string cmd)
        {
            InitializeComponent();
            listDataGrid = windowsFormsHost1.Child as System.Windows.Forms.DataGridView;
            this.DataContext = this;

            DataManager ins = DataManager.createInstance();

            listDataGrid.DataSource = ins.getDataTable(cmd);
        }
    }
}
