using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseDesignCourse.GlobalFunc
{
    class AreaRect
    {
        public int lefttopX;
        public int lefttopY;
        public int rightbottomX;
        public int rightbottomY;
        private string address;

        public AreaRect(int x0, int y0, int x1, int y1, string address)
        {
            lefttopX = x0;
            lefttopY = y0;
            rightbottomX = x1;
            rightbottomY = y1;
            this.address = address;
        }

        public bool isPtinRect(System.Windows.Point p)
        {
            if( (p.X >= lefttopX && p.X <= rightbottomX) &&
                (p.Y >= lefttopY && p.Y <= rightbottomY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
        }
    }
}
