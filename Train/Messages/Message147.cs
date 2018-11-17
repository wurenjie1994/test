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
    public class Message147 : AbstractMessage
    {
        /// <summary>
        /// 车到地——紧急停车确认
        /// </summary>
        const int MESSAGEID = 147;
        int ID01;
        int NID_MESSAGE;            //8bit
        int L_MESSAGE;              //10bit
        uint T_TRAIN;               //32bit
        int NID_ENGINE;             //24bit
        int NID_EM;                 //4bit
        int Q_EMERGENCYSTOP;        //2bit（可选）
        AbstractPacket ap01;        //可选择的信息包0/1

        const int BitArrayLEN = 248;
        const int byteLEN = BitArrayLEN / 8;

        public override byte[] Resolve(TrainToRBCData trainToRBCData)
        {
            BitArray bitArray = new BitArray(BitArrayLEN);
            int[] intArray = new int[] { 8, 10, 32, 24, 4, 2 };
            int[] DataArray = new int[] { NID_MESSAGE, L_MESSAGE, 0, NID_ENGINE, NID_EM, Q_EMERGENCYSTOP };
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
