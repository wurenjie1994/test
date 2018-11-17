using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Packets;
using Train.Utilities;

namespace Train.Messages
{
    public class Message018:AbstractMessage
    {
        /// <summary>
        /// 地到车——取消紧急停车
        /// </summary>
        const int MESSAGEID = 18;
        int NID_MESSAGE;            //8bit
        int L_MESSAGE;              //10bit
        uint T_TRAIN;               //32bit
        bool M_ACK;                 //1bit
        int NID_LRBG;               //24bit
        int NID_EM;                 //4bit

        public override void Resolve(byte[] recvData)
        {
            BitArray bitArray = new BitArray(recvData);

            int[] intArray = new int[] { 8, 10, 32, 1, 24, 4 };
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
            NID_EM = resultArray[5];
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
    }
}
