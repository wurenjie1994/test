using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——链接，应答器组的链接信息
    /// </summary>
    public class Packet005:AbstractPacket
    {
        int NID_PACKET;             //8bit
        int Q_DIR;                  //2bit
        int L_PACKET;               //13bit
        int Q_SCALE;                //2bit
        int[] D_LINK;               //15bit
        bool[] Q_NEWCOUNTRY;        //1bit
        int[] NID_C;                //10bit
        int[] NID_BG;               //14bit
        bool[] Q_LINKORIENTATION;   //1bit
        int[] Q_LINKREACTION;       //2bit
        int[] Q_LOCACC;             //6bit
        int N_ITER;                 //5bit
        int D_LINK_BASE;
        bool Q_NEWCOUNTRY_BASE;
        int NID_C_BASE;
        int NID_BG_BASE;
        bool Q_LINKORIENTATION_BASE;
        int Q_LINKREACTION_BASE;
        int Q_LOCACC_BASE;

        public const int LOC = 11;
        public const int ITER = 7;

        public override void Resolve(BitArray bitArray)
        {
            int[] intArray = new int[] { 8, 2, 13, 2, 15, 1, 10, 14, 1, 2, 6, 5, 15, 1, 10, 14, 1, 2, 6 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0, pos = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);

                if ((i == 5) && (resultArray[i] != 1))
                {
                    i++;
                    continue;
                }

                if ((i == LOC) && (resultArray[LOC] == 0))
                {
                    i += ITER;
                    continue;
                }

                if (i == LOC + ITER)
                {
                    D_LINK = new int[resultArray[LOC]];
                    Q_NEWCOUNTRY = new bool[resultArray[LOC]];
                    NID_C = new int[resultArray[LOC]];
                    NID_BG = new int[resultArray[LOC]];
                    Q_LINKORIENTATION = new bool[resultArray[LOC]];
                    Q_LINKREACTION = new int[resultArray[LOC]];
                    Q_LOCACC = new int[resultArray[LOC]];

                    D_LINK[0] = resultArray[LOC + 1];
                    if (resultArray[LOC + 2] == 1)
                    {
                        Q_NEWCOUNTRY[0] = true;
                    }
                    NID_C[0] = resultArray[LOC + 3];
                    NID_BG[0] = resultArray[LOC + 4];
                    if (resultArray[LOC + 5] == 1)
                    {
                        Q_LINKORIENTATION[0] = true;
                    }
                    Q_LINKREACTION[0] = resultArray[LOC + 6];
                    Q_LOCACC[0] = resultArray[LOC + 7];

                    for (int j = 1; j < resultArray[LOC]; j++)
                    {
                        D_LINK[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 1]);
                        Q_NEWCOUNTRY[j] = bitArray.Get(pos);
                        pos += 1;
                        if (Q_NEWCOUNTRY[j] == true)
                        {
                            NID_C[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 3]);
                        }
                        NID_BG[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 4]);
                        Q_LINKORIENTATION[j] = bitArray.Get(pos);
                        pos += 1;
                        Q_LINKREACTION[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 6]);
                        Q_LOCACC[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 7]);
                    }
                }
            }

            NID_PACKET = resultArray[0];
            Q_DIR = resultArray[1];
            L_PACKET = resultArray[2];
            Q_SCALE = resultArray[3];
            D_LINK_BASE = resultArray[4];
            if (resultArray[5] == 1)
            {
                Q_NEWCOUNTRY_BASE = true;
            }
            else
            {
                Q_NEWCOUNTRY_BASE = false;
            }
            NID_C_BASE = resultArray[6];
            NID_BG_BASE = resultArray[7];
            if (resultArray[8] == 1)
            {
                Q_LINKORIENTATION_BASE = true;
            }
            else
            {
                Q_LINKORIENTATION_BASE = false;
            }
            Q_LINKREACTION_BASE = resultArray[9];
            Q_LOCACC_BASE = resultArray[10];
            N_ITER = resultArray[11];
        }
    }
}
