using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——线路条件
    /// </summary>
    public class Packet068:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int Q_DIR;              //2bit
        int L_PACKET;           //13bit
        int Q_SCALE;            //2bit
        bool Q_TRACKINIT;       //1bit
        int D_TRACKINIT;        //15bit
        int[] D_TRACKCOND;      //15bit
        int[] L_TRACKCOND;      //15bit 应忽略应答器信息完整性检查报警的距离
        int[] M_TRACKCOND;      //4bit
        int N_ITER;             //5bit
        int D_TRACKCOND_BASE;
        int L_TRACKCOND_BASE;
        int M_TRACKCOND_BASE;

        public const int LOC = 9;
        public const int ITER = 3;

        public override void Resolve(BitArray bitArray)
        {
            int[] intArray = new int[] { 8, 2, 13, 2, 1, 15, 15, 15, 4, 5, 15, 15, 4 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0, pos = 0;

            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);

                if ((i == 4) && (resultArray[i] == 0))
                {
                    i++;
                    continue;
                }
                if (i == 5)
                {
                    break;
                }

                if ((i == LOC) && (resultArray[LOC] == 0))
                {
                    i += ITER;
                    continue;
                }

                if (i == LOC + ITER)
                {
                    D_TRACKCOND = new int[resultArray[LOC]];
                    L_TRACKCOND = new int[resultArray[LOC]];
                    M_TRACKCOND = new int[resultArray[LOC]];

                    D_TRACKCOND[0] = resultArray[LOC + 1];
                    L_TRACKCOND[0] = resultArray[LOC + 2];
                    M_TRACKCOND[0] = resultArray[LOC + 3];

                    for (int j = 1; j < resultArray[LOC]; j++)
                    {
                        D_TRACKCOND[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 1]);
                        L_TRACKCOND[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 2]);
                        M_TRACKCOND[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 3]);
                    }
                }
            }

            NID_PACKET = resultArray[0];
            Q_DIR = resultArray[1];
            L_PACKET = resultArray[2];
            Q_SCALE = resultArray[3];
            if (resultArray[4] == 1)
            {
                Q_TRACKINIT = true;
            }
            else
            {
                Q_TRACKINIT = false;
            }
            D_TRACKINIT = resultArray[5];
            D_TRACKCOND_BASE = resultArray[6];
            L_TRACKCOND_BASE = resultArray[7];
            M_TRACKCOND_BASE = resultArray[8];
            N_ITER = resultArray[9];
        }
    }
}
