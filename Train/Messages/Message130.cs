﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using Train.Packets;
using Train.Utilities;
using Train.Data;

namespace Train.Messages
{
    /// <summary>
    /// 车到地——请求调车模式
    /// </summary>
    public class Message130 : AbstractSendMessage
    {

        public const int MESSAGEID = 130;
        AbstractPacket ap01;        //信息包0/1

        public override byte[] Resolve()
        {
            int BitArrayLEN = 74;
            BitArray bit01 = ap01.Resolve();
            BitArrayLEN += bit01.Length;
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
    }
}
