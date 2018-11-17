using System;
using System.Reflection;
using Train.Data;

namespace Train.Messages
{
    public abstract class AbstractMessage
    {
        /// <summary>
        /// 地到车消息包需要覆盖此方法，只是提供一个接口
        /// </summary>
        /// <param name="recvData">接收到的信息</param>
        public virtual void Resolve(byte[] recvData)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 车到地消息包需要覆盖此方法
        /// </summary>
        /// <returns>返回组装好信息的ByteArray</returns>
        public virtual byte[] Resolve(TrainToRBCData trainToRBCData)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 用于返回Message实例的方法
        /// </summary>
        /// <param name="recvData">接收到的信息</param>
        /// <returns></returns>
        public static AbstractMessage GetMessage(byte[] recvData)
        {
            int id = recvData[0];
            String className = "Train.Messages.Message" + String.Format("{0:D2}", id);
            Type t = Type.GetType(className);
            Object obj = t.GetConstructor(Type.EmptyTypes).Invoke(new Object[0]);
            AbstractMessage message = (AbstractMessage)obj;
            message.Resolve(recvData);
            return message;
        }
        public virtual int GetMessageID()
        {
            throw new NotSupportedException();
        }
    }
}
