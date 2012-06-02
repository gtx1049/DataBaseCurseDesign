using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DataBaseDesignCourse.GlobalFunc
{
    class BindBox
    {
        static public void bindIDtypebox(ComboBox combo)
        {
            combo.Items.Add("驾照");
            combo.Items.Add("身份证");
        }

        static public void bindCitizenCrimestatus(ComboBox combo)
        {
            combo.Items.Add("无罪");
            combo.Items.Add("在逃");
            combo.Items.Add("入狱");
            combo.Items.Add("前科");
        }

        static public void bindCitizenHometown(ComboBox combo)
        {
            combo.Items.Add("北京");
            combo.Items.Add("天津");
            combo.Items.Add("上海");
            combo.Items.Add("重庆");
            combo.Items.Add("河北");
            combo.Items.Add("河南");
            combo.Items.Add("云南");
            combo.Items.Add("辽宁");
            combo.Items.Add("黑龙江");
            combo.Items.Add("湖南");
            combo.Items.Add("安徽");
            combo.Items.Add("山东");
            combo.Items.Add("新疆");
            combo.Items.Add("江苏");
            combo.Items.Add("浙江");
            combo.Items.Add("江西");
            combo.Items.Add("湖北");
            combo.Items.Add("广西");
            combo.Items.Add("甘肃");
            combo.Items.Add("山西");
            combo.Items.Add("内蒙古");
            combo.Items.Add("陕西");
            combo.Items.Add("吉林");
            combo.Items.Add("福建");
            combo.Items.Add("贵州");
            combo.Items.Add("广东");
            combo.Items.Add("青海");
            combo.Items.Add("西藏");
            combo.Items.Add("四川");
            combo.Items.Add("宁夏");
            combo.Items.Add("海南");
            combo.Items.Add("台湾");
            combo.Items.Add("香港");
            combo.Items.Add("澳门");
        }

        static public void bindCasetype(ComboBox combo)
        {
            combo.Items.Add("民事");
            combo.Items.Add("刑事");
        }

        static public void bindCitizenGender(ComboBox combo)
        {
            combo.Items.Add("男");
            combo.Items.Add("女");
        }

        static public void bindCarType(ComboBox combo)
        {
            combo.Items.Add("卡车");
            combo.Items.Add("轿车");
            combo.Items.Add("面包车");
        }

        static public void bindCarStatus(ComboBox combo)
        {
            combo.Items.Add("在用");
            combo.Items.Add("报废");
            combo.Items.Add("盗窃");
        }

        static public void bindArea(ComboBox combo)
        {
            combo.Items.Add("嘉定区");
            combo.Items.Add("长宁区");
            combo.Items.Add("普陀区");
            combo.Items.Add("静安区");
            combo.Items.Add("黄浦区");
        }
    }
}
