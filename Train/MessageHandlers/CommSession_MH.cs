using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Messages;

namespace Train.MessageHandlers
{
    /// <summary>
    /// 通信会话相关
    /// </summary>
    class CommSession_MH:AbstractMessageHandler
    {

        public override bool Solve(AbstractRecvMessage am)
        {
            int msgId = am.GetMessageID();
            //系统版本，收到此消息后车载设备应认为通信会话已经建立 
            if (msgId == 32)     
            {
                //车载设备应发送消息159：通信会话已建立（含车载设备电话号码:Packet003Train）
                Message159 m159 = new Message159();
                SendMsg(m159, _CommType.RBC);
                return true;
            }
            //通信会话开始，这是由RBC 发起的
            if(msgId==38)
            {
                //车载设备应发送消息：通信会话已建立（不必发送车载设备电话号码）
                Message159 m159 = new Message159();
                SendMsg(m159, _CommType.RBC);
                return true;
            }
            //通信会话结束确认
            if (msgId == 39)
            {
                Communication.Disconnect(_CommType.RBC);
                return true;
            }
            //拒绝列车
            if(msgId == 40)
            {
                Communication.Disconnect(_CommType.RBC);
                return true;
            }
            //接受列车
            if (msgId == 41)
            {

                return true;
            }
            return false;
        }
    }
}
