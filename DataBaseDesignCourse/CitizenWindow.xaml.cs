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
using Microsoft.Win32;

namespace DataBaseDesignCourse
{
	/// <summary>
	/// addCitizen.xaml 的交互逻辑
	/// </summary>
	public partial class addCitizen : Window
	{
        string photopath;
        bool ismodify;
        Citizen modifyc;
        int tax;

		public addCitizen(bool ismodify, object o)
		{
			this.InitializeComponent();
            BindBox.bindCitizenCrimestatus(this.CitizenCrimestatus);
            BindBox.bindCitizenHometown(this.CitizenHome);
            BindBox.bindCitizenGender(this.CitizenGender);

            photopath = "";

            modifyc = (Citizen)o;

            this.ismodify = ismodify;
            if (ismodify)
            {

                this.CitizenID.IsEnabled = false;

                this.CitizenName.Text = modifyc.Name;
                this.CitizenAddress.Text = modifyc.Address;
                this.CitizenBirthday.Text = modifyc.Birthday;
                if (modifyc.Gender == "M")
                {
                    this.CitizenGender.Text = "男";
                }
                if (modifyc.Gender == "F")
                {
                    this.CitizenGender.Text = "女";
                }
                string hometown = modifyc.Hometown;

                this.CitizenHome.Text = hometown.TrimEnd();
                this.CitizenID.Text = modifyc.PKID;
                this.CitizenPhone.Text = modifyc.Telephone;
                this.CitizenPhoto.Source = modifyc.Photo;
                this.CitizenCrimestatus.Text = modifyc.Crimestatus;
                tax = modifyc.Tax;
            }
            else
            {
                tax = 10;
            }
			// 在此点之下插入创建对象所需的代码。
		}

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DataManager ins = DataManager.createInstance();

            if (this.CitizenName.Text.Length == 0 ||
                this.CitizenHome.Text.Length == 0 ||
                this.CitizenID.Text.Length == 0 ||
                this.CitizenPhone.Text.Length == 0 ||
                this.CitizenGender.Text.Length == 0 ||
                this.CitizenBirthday.Text.Length == 0 ||
                this.CitizenCrimestatus.Text.Length == 0 ||
                this.CitizenAddress.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("请保持数据完整！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }

            modifyc.Name = this.CitizenName.Text;
            modifyc.Hometown = this.CitizenHome.Text;
            modifyc.PKID = this.CitizenID.Text;
            modifyc.Telephone = this.CitizenPhone.Text;

            if (photopath.Length != 0)
            {
                modifyc.Photo = new BitmapImage();
                modifyc.Photo.BeginInit();
                modifyc.Photo.StreamSource = System.IO.File.OpenRead(photopath);
                modifyc.Photo.EndInit();
            }

            if (this.CitizenGender.Text == "男")
            {
                modifyc.Gender = "M";
            }
            else if (this.CitizenGender.Text == "女")
            {
                modifyc.Gender = "F";
            }
            
            try
            {
                modifyc.Birthday = this.CitizenBirthday.Text;
            }
            catch (System.FormatException ex)
            {
                ex.ToString();
                System.Windows.MessageBox.Show("请将时间格式设置为yyyy-mm-dd！", "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
            
            modifyc.Crimestatus = this.CitizenCrimestatus.Text;
            modifyc.Address = this.CitizenAddress.Text;
            modifyc.Tax = tax;

            this.DialogResult = true;

            if (ismodify)
            {
                ins.Merge(modifyc);
            }
            else
            {
                if (!ins.Persist(modifyc))
                {
                    System.Windows.MessageBox.Show("ID发生了冲突！", "提示", System.Windows.MessageBoxButton.OK);
                    return;
                }
            }
            this.Close();
        }

        public object ModifyC
        {
            get
            {
                return (object)modifyc;
            }
        }

        private void changePhoto_Click(object sender, RoutedEventArgs e)
        {
            string filename;

            OpenFileDialog openimage = new OpenFileDialog();
            openimage.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

            if (openimage.ShowDialog() ?? false)
            {
                filename = openimage.FileName;
                BitmapImage bimg = new BitmapImage(new System.Uri(filename));

                if (bimg.PixelWidth != 100 || bimg.PixelHeight != 120)
                {
                    System.Windows.MessageBox.Show("请使用100 * 120规格的图片！", "提示", System.Windows.MessageBoxButton.OK);
                    return;
                }

                this.CitizenPhoto.Source = bimg;
                photopath = filename;
            }

            
        }
	}
}