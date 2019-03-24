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
        public static BitArray Union(BitArray first,BitArray second)
        {
            int len1 = first.Length, len2 = second.Length;
            BitArray res = new BitArray(len1 + len2);
            for (int i = 0; i < len1;) res[i] = first[i++];
            for (int i = len1, j = 0; i < res.Length; i++)
                res[i++] = second[j++];
            return res;
        }
        public static int ToInt(BitArray bitArray, ref int position, int length)
        {
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                if (position + i >= bitArray.Length) break;
                result = bitArray.Get(position + i) ? result | (1 << i) : result;
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
        /// <summary>
        /// 将data中低length位放到bitArray中
        /// </summary>
        /// <param name="bitArray"></param>
        /// <param name="data"></param>
        /// <param name="position">bitArray中起点</param>
        /// <param name="length">data长度</param>
        public static void ConvergeBitArray(BitArray bitArray, int data, ref int position, int length)
        {
            int remain = 0;
            for (int i = length-1; i >=0; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1);
                data /= 2;
            }
            position += length;
        }
        public static void ConvergeBitArray(BitArray bitArray, long data, ref int position, int length)
        {
            long remain = 0;
            for (int i = length-1; i >=0; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1);
                data /= 2;
            }
            position += length;
        }
        public static void ConvergeBitArray(BitArray bitArray, ulong data, ref int position, int length)
        {
            ulong remain = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                remain = data % 2;
                bitArray[position + i] = (remain == 1);
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
