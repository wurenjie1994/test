using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Packets;
using Train.Utilities;

namespace Train.Messages
{
    public class Message008:AbstractRecvMessage
    {
        /// <summary>
        /// 地到车——列车数据确认
        /// </summary>
        const int MESSAGEID = 8;
        uint T_TRAIN2;

        public override void Resolve(byte[] recvData)
        {
            BitArray bitArray = new BitArray(recvData);

            int[] intArray = new int[] { 8, 10, 32, 1, 24, 32 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0, pos = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);
            }

            NID_MESSAGE = resultArray[0];
            L_MESSAGE = resultArray[1];
            T_TRAIN = Convert.ToUInt32(resultArray[2]);
            if (resultArray[3] == 1)
            {
                M_ACK = true;
            }
            else
            {
                M_ACK = false;
            }
            NID_LRBG = resultArray[4];
            T_TRAIN2 = Convert.ToUInt32(resultArray[5]);
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
    }
}
