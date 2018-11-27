using System;
using System.Collections;

namespace Train.Packets
{
    public abstract class AbstractPacket
    {
        /// <summary>
        /// 地到车信息包需要覆盖此方法
        /// </summary>
        /// <param name="bitArray">存放收到的信息</param>
        public virtual void Resolve(BitArray bitArray)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 车到地信息包需要覆盖此方法
        /// </summary>
        /// <param name="obj">存放要发送的信息，目前还没想好用什么类型，暂且用Object</param>
        /// <returns>返回组装好信息的BitArray</returns>
        public virtual BitArray Resolve()
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 通过反射获取实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AbstractPacket GetPacket(int id)
        {
            String className = "Train.Packets.Packet" + String.Format("{0:D3}", id);
            Type t = Type.GetType(className);
            Object obj = t.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
            AbstractPacket packet = (AbstractPacket)obj;
            return packet;
        }
    }
}
