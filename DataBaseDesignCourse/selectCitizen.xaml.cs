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
using System.Collections.ObjectModel;

namespace DataBaseDesignCourse
{
    /// <summary>
    /// selectCitizen.xaml 的交互逻辑
    /// </summary>
    public partial class selectCitizen : Window
    {
        private object addc;

        public selectCitizen()
        {
            InitializeComponent();

            DataManager ins = DataManager.createInstance();
            List<Entity> cs = ins.FindAll(Citizen.getClass());
            ObservableCollection<Citizen> cns = new ObservableCollection<Citizen>();
            for (int i = 0; i < cs.Count; i++)
            {
                Citizen ci = (Citizen)cs[i];
                cns.Add(ci);
            }
            addCitizenList.ItemsSource = cns;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
           addc = addCitizenList.SelectedItem;
           this.DialogResult = true;
           this.Close();
        }

        public object Addo
        {
            get
            {
                return addc;
            }
        }
    }
}
