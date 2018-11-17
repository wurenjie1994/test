using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 车到地——确认后的列车数据
    /// </summary>
    public class Packet011:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int L_PACKET;           //13bit
        long NID_OPERATIONAL;   //32bit
        int NC_TRAIN;           //15bit
        int L_TRAIN;            //12bit
        int V_MAXTRAIN;         //7bit
        int M_LOADINGGAUGE;     //8bit
        int M_AXLELOAD;         //7bit
        int M_AIRTIGHT;         //2bit
        int N_ITER1;            //5bit
        int N_ITER2;            //5bit
        int[] M_TRACTION;       //8bit
        int[] NID_STM;          //8bit

        public override BitArray Resolve()
        {
            BitArray bitArray = new BitArray(200);
            int[] intArray = new int[] { 8, 13, 32, 15, 12, 7, 8, 7, 2 };
            int[] DataArray = new int[] { NID_PACKET, L_PACKET, 0, NC_TRAIN, L_TRAIN, V_MAXTRAIN, M_LOADINGGAUGE, M_AXLELOAD, M_AIRTIGHT };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i == 2)
                {
                    Bits.ConvergeBitArray(bitArray, NID_OPERATIONAL, ref pos, intArray[i]);
                }
                else
                {
                    Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
                }
            }

            Bits.ConvergeBitArray(bitArray, N_ITER1, ref pos, 5);
            for (int i = 0; i < N_ITER1; i++)
            {
                Bits.ConvergeBitArray(bitArray, M_TRACTION[i], ref pos, 8);
            }
            Bits.ConvergeBitArray(bitArray, N_ITER2, ref pos, 5);
            for (int i = 0; i < N_ITER1; i++)
            {
                Bits.ConvergeBitArray(bitArray, NID_STM[i], ref pos, 8);
            }

            return bitArray;
        }
    }
}
