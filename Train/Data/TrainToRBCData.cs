using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Packets;

namespace Train.Data
{
    public class TrainToRBCData
    {
      
        int T_TRAIN; //车载设备时钟
        static int NID_ENGINE;//车载设备标 CTCS编号
        bool Q_TRACKDEL;//删除线路描述信息,消息编号132
        int NID_EM;//紧急消息编号,消息编号147
        int Q_EMERGENCYSTOP;//紧急停车确认限定词,消息编号147
        int Q_STATUS;//SoM位置报告状态,消息编号157

        Packet001 packet001;
        Packet011 packet011;
    }
}
