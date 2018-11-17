using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Utilities;

namespace Train.Packets
{
    /// <summary>
    /// 车到地——CTCS-3级转换信息
    /// </summary>
    public class Packet009 : AbstractPacket
    {
        int NID_PACKET;         //8bit
        int L_PACKET;           //13bit
        int NID_LTRBG;          //24bit

        public override BitArray Resolve()
        {
            BitArray bitArray = new BitArray(45);
            int[] intArray = new int[] { 8, 13, 24 };
            int[] DataArray = new int[] { NID_PACKET, L_PACKET, NID_LTRBG };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
            }
            return bitArray;
        }
    }
}