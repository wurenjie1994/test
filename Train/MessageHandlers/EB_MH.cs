using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Train.Messages;

namespace Train.MessageHandlers
{
    /// <summary>
    /// 处理与紧急停车相关的消息
    /// </summary>
    class EB_MH : AbstractMessageHandler
    {
        Dictionary<int, AbstractRecvMessage> dictEB = new Dictionary<int, AbstractRecvMessage>();
        public override bool Solve(AbstractRecvMessage arm)
        {
            int msgId = arm.GetMessageID();
            //有条件紧急停车
            if (msgId == 15)
            {
                MH((Message015)arm);
                return true;
            }
            //无条件紧急停车
            if (msgId == 16)
            {
                MH((Message016)arm);
                return true;
            }
            //取消紧急停车
            if (msgId==18)
            {
                MH((Message018)arm);
                return true;
            }
            return false;
        }
        private void MH(Message015 m15)
        {
            int nid_em = m15.GetNID_EM();
            dictEB.Add(nid_em, m15);
            //发送紧急停车确认消息147
            if (m15.M_ACK)
            {
                Message147 m147 = new Message147();
                m147.SetNID_EM(nid_em);
                m147.SetQ_ES(1);  //考虑有条件紧急停车 使用值1
                m147.SetAbstractPacket(null);
                Communication.SendMsg(m147.Resolve(), _CommType.RBC);
            }
        }
        private void MH(Message016 m16)
        {
            int nid_em = m16.GetNID_EM();
            dictEB.Add(nid_em, m16);
            //发送紧急停车确认消息147
            if (m16.M_ACK)
            {
                Message147 m147 = new Message147();
                m147.SetNID_EM(nid_em);
                m147.SetQ_ES(2);  //无条件紧急停车 使用值2
                m147.SetAbstractPacket(null);
                Communication.SendMsg(m147.Resolve(), _CommType.RBC);
            }
        }
        private void MH(Message018 m18)
        {
            int nid_em = m18.GetNID_EM();
            if (dictEB.ContainsKey(nid_em)) dictEB.Remove(nid_em);
            //发送确认消息146
            if (m18.M_ACK)
            {
                Message146 m146 = new Message146();
                m146.T_TRAIN2 = m18.T_TRAIN;
                Communication.SendMsg(m146.Resolve(), _CommType.RBC);
            }
        }
    }
}
