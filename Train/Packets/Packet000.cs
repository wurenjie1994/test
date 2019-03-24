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
        int NID_PACKET=0;         //8bit
        int L_PACKET=8+13+2+24+15+2+2+15+15+2+7+2+4+3;           //13bit
        public int Q_SCALE;            //2bit
        public int NID_LRBG;           //24bit
        public int D_LRBG;             //15bit
        public int Q_DIRLRBG;          //2bit
        public int Q_DLRBG;            //2bit
        public int L_DOUBTOVER;        //15bit
        public int L_DOUBTUNDER;       //15bit
        public int Q_LENGTH;           //2bit
        public int L_TRAININT;         //15bit
        public int V_TRAIN;            //7bit
        public int Q_DIRTRAIN;         //2bit
        public int M_MODE;             //4bit
        public int M_LEVEL;            //3bit
        public int NID_STM;            //8bit

        public override BitArray Resolve()
        {
            if (Q_LENGTH == 1 || Q_LENGTH == 2) L_PACKET += 15;
            if (M_LEVEL == 1) L_PACKET += 8;
            BitArray bitArray = new BitArray(L_PACKET);
            int[] intArray = new int[] { 8, 13, 2, 24, 15, 2, 2, 15, 15, 2, 15, 7, 2, 4, 3, 8 };
            int[] DataArray = new int[] { NID_PACKET, L_PACKET, Q_SCALE, NID_LRBG, D_LRBG,
                Q_DIRLRBG, Q_DLRBG, L_DOUBTOVER, L_DOUBTUNDER, Q_LENGTH, L_TRAININT,
                V_TRAIN, Q_DIRTRAIN, M_MODE, M_LEVEL, NID_STM };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
                //Q_LENGTH
                if ((i == 9) && (DataArray[i] != 1) && (DataArray[i] != 2))
                {
                    i++;
                    continue;
                }
                //M_LEVEL
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
