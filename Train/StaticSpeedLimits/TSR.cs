using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train.StaticSpeedLimits
{
    /// <summary>
    /// 临时限速
    /// </summary>
    public class TSR : StaticSpeedLimit
    {
        private int id;
        private double length;
        private double distance;
        private double velocity;
        private bool front;

        private double totalDis=0;//接收到报文后，列车走行距离
        private static Dictionary<int, TSR> tsrDict = new Dictionary<int, TSR>();

        public TSR(Packets.Packet065 p65)
        {
            p65.SetValueTo(this);
        }

        public static double Run(double dis)
        {
            dis = Math.Abs(dis);
            double maxV = 600 / 3.6;
            
            foreach(TSR tsr in tsrDict.Values)
            {
                tsr.totalDis += dis;
                if (tsr.totalDis < tsr.distance) continue;  //还未到限速区域
                if (tsr.totalDis < tsr.length) maxV = Math.Min(maxV, tsr.velocity);
                else tsrDict.Remove(tsr.id);    //已经越过限速区域
            }
            return maxV;
        }

        public static void Add(TSR tsr)
        {
            tsrDict.Add(tsr.id, tsr);
        }
        public static void Remove(int id)
        {
            if(tsrDict.ContainsKey(id))
                tsrDict.Remove(id);
        }
        /// <summary>
        /// 列车运行方向改变时，之前的所有TSR都应删除
        /// </summary>
        public static void Clear()
        {
            tsrDict.Clear();
        }
        #region setters/getters
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public double Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        public double Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public bool Front
        {
            get
            {
                return front;
            }

            set
            {
                front = value;
            }
        }
        #endregion
    }
}
