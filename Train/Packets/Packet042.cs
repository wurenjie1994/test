using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——通信会话管理
    /// </summary>
    public class Packet042:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int Q_DIR;              //2bit
        int L_PACKET;           //13bit
        bool Q_RBC;             //1bit
        int NID_C;              //10bit
        int NID_RBC;            //14bit
        long NID_RADIO;         //64bit
        bool Q_SLEEPSESSION;    //1bit

        public override void Resolve(BitArray bitArray)
        {
            int[] intArray = new int[] { 8, 2, 13, 1, 10, 14, 64, 1 };
            int Len = intArray.Length;
            long[] resultArray = new long[Len];
            int i = 0, pos = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i], 0);
            }

            NID_PACKET = Convert.ToInt32(resultArray[0]);
            Q_DIR = Convert.ToInt32(resultArray[1]);
            L_PACKET = Convert.ToInt32(resultArray[2]);
            if (resultArray[3] == 1)
            {
                Q_RBC = true;
            }
            else
            {
                Q_RBC = false;
            }
            NID_C = Convert.ToInt32(resultArray[4]);
            NID_RBC = Convert.ToInt32(resultArray[5]);
            NID_RADIO = resultArray[6];
            if (resultArray[7] == 1)
            {
                Q_SLEEPSESSION = true;
            }
            else
            {
                Q_SLEEPSESSION = false;
            }
        }
    }
}
