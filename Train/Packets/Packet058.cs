using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——位置报告参数
    /// </summary>
    public class Packet058:AbstractPacket
    {
        int NID_PACKET;         //8bit
        int Q_DIR;              //2bit
        int L_PACKET;           //13bit
        int Q_SCALE;            //2bit
        int T_CYCLOC;           //8bit
        int D_CYCLOC;           //15bit
        int M_LOC;              //3bit
        int N_ITER;             //5bit
        int[] D_LOC;            //15bit
        bool[] Q_LGTLOC;        //1bit

        public const int LOC = 7;
        public const int ITER = 2;

        public override void Resolve(BitArray bitArray)
        {
            int[] intArray = new int[] { 8, 2, 13, 2, 8, 15, 3, 5, 15, 1 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0, pos = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);

                if ((i == LOC) && (resultArray[LOC] == 0))
                {
                    i += ITER;
                    continue;
                }

                if (i == LOC + ITER)
                {
                    D_LOC = new int[resultArray[LOC]];
                    Q_LGTLOC = new bool[resultArray[LOC]];

                    D_LOC[0] = resultArray[LOC + 1];
                    if (resultArray[LOC + 2] == 1)
                    {
                        Q_LGTLOC[0] = true;
                    }

                    for (int j = 1; j < resultArray[LOC]; j++)
                    {
                        D_LOC[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 1]);
                        Q_LGTLOC[j] = bitArray.Get(pos);
                        pos += 1;
                    }
                }
            }

            NID_PACKET = resultArray[0];
            Q_DIR = resultArray[1];
            L_PACKET = resultArray[2];
            Q_SCALE = resultArray[3];
            T_CYCLOC = resultArray[4];
            D_CYCLOC = resultArray[5];
            M_LOC = resultArray[6];
            N_ITER = resultArray[7];
        }
    }
}
