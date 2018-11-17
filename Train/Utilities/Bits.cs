using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train.Utilities
{
    /// <summary>
    /// 工具库，针对于bit的操作
    /// </summary>
    public class Bits
    {
        //截取BitArray
        public static BitArray SubBitArray(BitArray bitArray,int start,int length)
        {
            BitArray bit = new BitArray(length);
            for (int i = 0; i < length; i++)
            {
                bit[i] = bitArray[i + start];
            }
            return bit;
        }
        public static int ToInt(BitArray bitArray, ref int position, int length)
        {
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                result = bitArray.Get(position + i) ? result + (1 << i) : result;
            }
            position += length;
            return result;
        }
        public static long ToInt(BitArray bitArray, ref int position, int length, int x)
        {
            long result = 0;
            for (int i = 0; i < length; i++)
            {
                result = bitArray.Get(position + i) ? result + (1 << i) : result;
            }
            position += length;
            return result;
        }
        public static void ConvergeBitArray(BitArray bitArray, int data, ref int position, int length)
        {
            int remain = 0;
            for (int i = 0; i < length; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1) ? true : false;
                data /= 2;
            }
            position += length;
        }
        public static void ConvergeBitArray(BitArray bitArray, long data, ref int position, int length)
        {
            long remain = 0;
            for (int i = 0; i < length; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1) ? true : false;
                data /= 2;
            }
            position += length;
        }
        public static void ConvergeBitArray(BitArray bitArray, ulong data, ref int position, int length)
        {
            ulong remain = 0;
            for (int i = 0; i < length; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1) ? true : false;
                data /= 2;
            }
            position += length;
        }
        public static void ToByte(byte[] sendData, BitArray bitArray)
        {
            int pos = 0;
            for (int i = 0; pos < bitArray.Length; i++)
            {
                sendData[i] = Convert.ToByte(Bits.ToInt(bitArray, ref pos, 8));
            }
        }
    }
}
