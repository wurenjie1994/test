using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 车到地——位置报告
    /// </summary>
    public class Packet000:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int L_PACKET;           //13bit
        int Q_SCALE;            //2bit
        int NID_LRBG;           //24bit
        int D_LRBG;             //15bit
        int Q_DIRLRBG;          //2bit
        int Q_DLRBG;            //2bit
        int L_DOUBTOVER;        //15bit
        int L_DOUBTUNDER;       //15bit
        int Q_LENGTH;           //2bit
        int L_TRAININT;         //15bit
        int V_TRAIN;            //7bit
        int Q_DIRTRAIN;         //2bit
        int M_MODE;             //4bit
        int M_LEVEL;            //3bit
        int NID_STM;            //8bit

        public override BitArray Resolve()
        {
            BitArray bitArray = new BitArray(137);
            int[] intArray = new int[] { 8, 13, 2, 24, 15, 2, 2, 15, 15, 2, 15, 7, 2, 4, 3, 8 };
            int[] DataArray = new int[] { NID_PACKET, L_PACKET, Q_SCALE, NID_LRBG, D_LRBG, Q_DIRLRBG, Q_DLRBG, L_DOUBTOVER, L_DOUBTUNDER, Q_LENGTH, L_TRAININT, V_TRAIN, Q_DIRTRAIN, M_MODE, M_LEVEL, NID_STM };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
                if ((i == 9) && (DataArray[i] != 1) && (DataArray[i] != 2))
                {
                    i++;
                    continue;
                }
                if ((i == 14) && (DataArray[i] != 1))
                {
                    i++;
                    continue;
                }
            }
            return bitArray;
        }
    }
}
