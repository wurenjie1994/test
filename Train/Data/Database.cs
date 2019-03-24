using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train.Data
{
    public class Database
    {
        public static void Init()
        {
            InitTrainInfo();
            InitBaliseGroup();
        }
        public static void InitTrainInfo()
        {
            TrainInfo.TrainID = 0x123456;
            TrainInfo.L_TRAIN = 140;//设为140米
            TrainInfo.NID_ENGINE = 0x123456;
            TrainInfo.NID_XUSER = 123;
            TrainInfo.NID_OPERATIONAL = 0x12345678;
            TrainInfo.NC_TRAIN = 0;
            TrainInfo.V_MAXTRAIN = 70;// 70*5 km/h
            TrainInfo.M_LOADINGGAUGE = 0x01;
            TrainInfo.M_AXLELOAD = 10;
            TrainInfo.M_AIRTIGHT = 0;
            TrainInfo.NID_STMList.Add(1);//假定STM编号为1
            TrainInfo.NID_RADIOList.Add(0x1234567890123456);//假定值
            TrainInfo.M_TRACTION.Add(0x12);//假定值

        }

        public static void InitBaliseGroup()
        {
            for(int i = 0; i < 20; i++)
            {
                BaliseGroup bg = new BaliseGroup();
                bg.Nid_bg = i;
                bg.Position = i * 100;
                BaliseGroup.BgList.Add(bg);
            }
        }
    }
}
