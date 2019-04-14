using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Messages;
using Train.Packets;

namespace Train.MessageHandlers
{
    class Version_MH:AbstractMessageHandler
    {
        public override bool Solve(AbstractRecvMessage arm)
        {
            int msgId = arm.GetMessageID();
            //通常消息24
            if (msgId == 24)
            {
                MH((Message024)arm);
                return true;
            }
            return false;
        }
        private void MH(Message024 m24)
        {
            AbstractPacket ap = m24.GetAlternativePacket();
            if (ap.GetType() == typeof(Packet042))
            {
                Message156 m156 = new Message156();//断开通信连接
                SendMsg(m156, _CommType.RBC);
            }
        }
    }
}
