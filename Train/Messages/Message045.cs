using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Packets;
using Train.Utilities;

namespace Train.Messages
{
    public class Message045:AbstractRecvMessage
    {
        /// <summary>
        /// 地到车——分配坐标系
        /// </summary>
        const int MESSAGEID = 45;
        bool Q_ORIENTATION;         //1bit

        public override void Resolve(byte[] recvData)
        {
            BitArray bitArray = Bits.ToBitArray(recvData);

            int[] intArray = new int[] { 8, 10, 32, 1, 24, 1 };
            int Len = intArray.Length;
            int[] resultArray = new int[Len];
            int i = 0, pos = 0;
            for (i = 0; i < Len; i++)
            {
                resultArray[i] = Bits.ToInt(bitArray, ref pos, intArray[i]);
            }

            NID_MESSAGE = resultArray[0];
            L_MESSAGE = resultArray[1];
            T_TRAIN=(uint)(resultArray[2]);
            if (resultArray[3] == 1)
            {
                M_ACK = true;
            }
            else
            {
                M_ACK = false;
            }
            NID_LRBG = resultArray[4];
            if (resultArray[5] == 1)
            {
                Q_ORIENTATION = true;
            }
            else
            {
                Q_ORIENTATION = false;
            }
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
    }
}
