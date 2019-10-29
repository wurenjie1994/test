﻿using System;
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
    /// 车到地——列车位置报告
    /// </summary>
    public class Message136 : AbstractSendMessage
    {
        const int MESSAGEID = 136;

        AbstractPacket ap01;        //信息包0/1
        AbstractPacket ap;          //可选择的信息包

        public override byte[] Resolve()
        {
            int BitArrayLEN = 74;
            BitArray bit01 = ap01.Resolve();
            BitArray bit = (ap==null?null:ap.Resolve());
            BitArrayLEN += bit01.Length + (bit == null ? 0 : bit.Length);
            BitArray bitArray = new BitArray(BitArrayLEN);

            L_MESSAGE = BitArrayLEN / 8 + (BitArrayLEN % 8 == 0 ? 0 : 1);
            NID_MESSAGE = MESSAGEID;

            int[] intArray = new int[] { 8, 10, 32, 24 };
            int[] DataArray = new int[] { NID_MESSAGE, L_MESSAGE, (int)T_TRAIN, NID_ENGINE };
            int pos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                Bits.ConvergeBitArray(bitArray, DataArray[i], ref pos, intArray[i]);
            }
            for (int i = 0; i < bit01.Length; i++)
            {
                bitArray[pos++] = bit01[i];
            }
            for (int i = 0;bit!=null && i < bit.Length; i++)
            {
                bitArray[pos++] = bit[i];
            }

            byte[] sendData = new byte[L_MESSAGE];
            Bits.ToByte(sendData, bitArray);

            return sendData;
        }
        public override int GetMessageID()
        {
            return MESSAGEID;
        }
        public void SetPacket0or1(AbstractPacket p01)
        {
            ap01 = p01;
        }
        public void SetAlternativePacket(AbstractPacket ap)
        {
            this.ap = ap;
        }
    }
}
