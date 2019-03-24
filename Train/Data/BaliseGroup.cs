using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train.Data
{
    public class BaliseGroup
    {
        private int nid_bg;     //应答器组编号
        private int nid_c=1001;          //地区号，应统一赋值
        private int position;       //应答器组位置，相对于线路最左端，单位：米

        private static List<BaliseGroup> bgList = new List<BaliseGroup>();

        public int Nid_bg
        {
            get
            {
                return nid_bg;
            }

            set
            {
                nid_bg = value;
            }
        }

        public int Nid_c
        {
            get
            {
                return nid_c;
            }

            set
            {
                nid_c = value;
            }
        }

        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public static List<BaliseGroup> BgList
        {
            get
            {
                return bgList;
            }

            set
            {
                bgList = value;
            }
        }
    }
}
