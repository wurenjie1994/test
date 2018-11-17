using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 地到车——CTCS-3级的行车许可
    /// </summary>
    public class Packet015:AbstractPacket
    {
        int NID_PACKET;             //8bit
        int Q_DIR;                  //2bit
        int L_PACKET;               //13bit
        int Q_SCALE;                //2bit
        int V_LOA;                  //7bit
        int T_LOA;                  //10bit
        int N_ITER;                 //5bit
        int[] L_SECTION;            //15bit
        bool[] Q_SECTIONTIMER;      //1bit
        int[] T_SECTIONTIMER;       //10bit
        int[] D_SECTIONTIMERSTOPLOC;//15bit
        int L_ENDSECTION;           //15bit
        bool Q_SECTIONTIMER_BASE;
        int T_SECTIONTIMER_BASE;
        int D_SECTIONTIMERSTOPLOC_BASE;
        bool Q_ENDTIMER;            //1bit
        int T_ENDTIMER;             //10bit
        int D_ENDTIMERSTARTLOC;     //15bit
        bool Q_DANGERPOINT;         //1bit
        int D_DP;                   //15bit
        int V_RELEASEDP;            //7bit
        bool Q_OVERLAP;             //1bit
        int D_STARTOL;              //15bit
        int T_OL;                   //10bit
        int D_OL;                   //15bit
        int V_RELEASEOL;            //7bit

        public const int LOC = 6;
        public const int ITER = 4;

        public override void Resolve(BitArray bitArray,ref int pos)
        {
            int[] intArray = new int[] { 8, 2, 13, 2, 7, 10, 5, 15, 1, 10, 15, 15, 1, 10, 15, 1, 10, 15, 1, 15, 7, 1, 15, 10, 15, 7 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);

                if ((i == 12) || (i == 15) || (i == 18) && (resultArray[i] != 1))
                {
                    i += 2;
                    continue;
                }
                if ((i == 21) && (resultArray[i] != 1))
                {
                    i += 4;
                    continue;
                }

                if ((i == LOC) && (resultArray[LOC] == 0))
                {
                    i += ITER;
                    continue;
                }

                if (i == LOC + ITER)
                {
                    L_SECTION = new int[resultArray[LOC]];
                    Q_SECTIONTIMER = new bool[resultArray[LOC]];
                    T_SECTIONTIMER = new int[resultArray[LOC]];
                    D_SECTIONTIMERSTOPLOC = new int[resultArray[LOC]];

                    L_SECTION[0] = resultArray[LOC + 1];
                    if (resultArray[LOC + 2] == 1)
                    {
                        Q_SECTIONTIMER[0] = true;
                    }
                    T_SECTIONTIMER[0] = resultArray[LOC + 3];
                    D_SECTIONTIMERSTOPLOC[0] = resultArray[LOC + 4];

                    for (int j = 1; j < resultArray[LOC]; j++)
                    {
                        L_SECTION[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 1]);
                        Q_SECTIONTIMER[j] = bitArray.Get(pos);
                        pos += 1;
                        if (Q_SECTIONTIMER[j] == true)
                        {
                            T_SECTIONTIMER[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 3]);
                            D_SECTIONTIMERSTOPLOC[j] = Bits.ToInt(bitArray, ref pos, intArray[LOC + 4]);
                        }
                    }
                }
            }

            NID_PACKET = resultArray[0];
            Q_DIR = resultArray[1];
            L_PACKET = resultArray[2];
            Q_SCALE = resultArray[3];
            V_LOA = resultArray[4];
            T_LOA = resultArray[5];
            N_ITER = resultArray[6];
            L_ENDSECTION = resultArray[11];
            if (resultArray[12] == 1)
            {
                Q_SECTIONTIMER_BASE = true;
            }
            else
            {
                Q_SECTIONTIMER_BASE = false;
            }
            T_SECTIONTIMER_BASE = resultArray[13];
            D_SECTIONTIMERSTOPLOC_BASE = resultArray[14];
            if (resultArray[15] == 1)
            {
                Q_ENDTIMER = true;
            }
            else
            {
                Q_ENDTIMER = false;
            }
            T_ENDTIMER = resultArray[16];
            D_ENDTIMERSTARTLOC = resultArray[17];
            if (resultArray[18] == 1)
            {
                Q_DANGERPOINT = true;
            }
            else
            {
                Q_DANGERPOINT = false;
            }
            D_DP = resultArray[19];
            V_RELEASEDP = resultArray[20];
            if (resultArray[21] == 1)
            {
                Q_OVERLAP = true;
            }
            else
            {
                Q_OVERLAP = false;
            }
            D_STARTOL = resultArray[22];
            T_OL = resultArray[23];
            D_OL = resultArray[24];
            V_RELEASEOL = resultArray[25];
        }
    }
}
