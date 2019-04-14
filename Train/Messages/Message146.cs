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
    public class Message146 : AbstractSendMessage
    {
        /// <summary>
        /// 车到地——确认
        /// </summary>
        const int MESSAGEID = 146;

        const int BitArrayLEN = 106;

        public override byte[] Resolve()
        {
            BitArray bitArray = new BitArray(BitArrayLEN);
            NID_MESSAGE = MESSAGEID;
            L_MESSAGE = BitArrayLEN / 8 + (BitArrayLEN % 8 == 0 ? 0 : 1);
            int[] intArray = new int[] { 8, 10, 32, 24, 32 };
            int[] DataArray = new int[] { NID_MESSAGE, L_MESSAGE, 0, NID_ENGINE, 0 };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i == 2)
                {
                    Bits.ConvergeBitArray(bitArray, T_TRAIN, ref pos, intArray[i]);
                }
                else if (i == 4)
                {
                    Bits.ConvergeBitArray(bitArray, T_TRAIN2, ref pos, intArray[i]);
                }
                else
                {
                    Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
                }
            }
            byte[] sendData = new byte[L_MESSAGE];
            Bits.ToByte(sendData, bitArray);

            return sendData;
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
    }
}
