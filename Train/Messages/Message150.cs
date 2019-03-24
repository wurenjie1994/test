using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Packets;
using Train.Utilities;
using Train.Data;

namespace Train.Messages
{
    /// <summary>
    /// 车到地——任务结束
    /// </summary>
    public class Message150: AbstractSendMessage
    {

        const int MESSAGEID = 150;
        int ID01;

        AbstractPacket ap01;        //可选择的信息包0/1

        const int BitArrayLEN = 240;
        const int byteLEN = BitArrayLEN / 8;

        public override byte[] Resolve()
        {
            BitArray bitArray = new BitArray(BitArrayLEN);
            int[] intArray = new int[] { 8, 10, 32, 24 };
            int[] DataArray = new int[] { NID_MESSAGE, L_MESSAGE, 0, NID_ENGINE };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i == 2)
                {
                    Bits.ConvergeBitArray(bitArray, T_TRAIN, ref pos, intArray[i]);
                }
                else
                {
                    Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
                }
            }
            ap01 = AbstractPacket.GetPacket(ID01);
            BitArray bit = ap01.Resolve();
            for (int i = 0; i < bit.Length; i++)
            {
                bitArray[pos] = bit[i];
                pos++;
            }

            byte[] sendData = new byte[byteLEN];
            Bits.ToByte(sendData, bitArray);

            return sendData;
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
    }
}
