using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——来自RBC的列车车次号
    /// </summary>
    public class Packet140:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int Q_DIR;              //2bit
        int L_PACKET;           //13bit
        long NID_OPERARIONAL;   //32bit

        public override void Resolve(BitArray bitArray)
        {
            int[] intArray = new int[] { 8, 2, 13, 32 };
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
            NID_OPERARIONAL = resultArray[3];
            TrainInfo.NID_OPERATIONAL = (int)NID_OPERARIONAL;
        }
    }
}
