using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Messages;
namespace Train.MessageHandlers
{
    public abstract class AbstractMessageHandler
    {
        protected AbstractMessageHandler next;
        protected AbstractMessageHandler SetNext(AbstractMessageHandler amh) { return next = amh; }
        protected AbstractMessageHandler GetNext() { return next; }
        /// <summary>
        /// 处理各类消息的函数
        /// </summary>
        /// <param name="am"></param>
        /// <returns>true表示消息被处理，false表示消息未被处理</returns>
        public abstract bool Solve(Messages.AbstractRecvMessage am);

        private static CommSession_MH mhCommSession = new CommSession_MH();
        private static EB_MH mhEB = new EB_MH();
        private static General_MH mhVersion = new General_MH();
        private static MA_MH mhMa = new MA_MH();
        private static LocReport_MH mhLocReport = new LocReport_MH();
        private static UltimateHandler_MH mhUltimateHandler = new UltimateHandler_MH();

        protected static MainForm mainForm;
        //设置责任链
        public static void Init(MainForm mf)
        {
            mainForm = mf;
            mhCommSession.SetNext(mhEB).SetNext(mhVersion)
                .SetNext(mhMa).SetNext(mhLocReport)
                .SetNext(mhUltimateHandler).SetNext(null);
        }
        //处理接收到的报文
        public static void Handling(Messages.AbstractRecvMessage am)
        {
            AbstractMessageHandler amh = mhCommSession;
            while (!amh.Solve(am))
                amh = amh.GetNext();
        }
        protected void SendMsg(AbstractSendMessage asm,_CommType commType)
        {
            if(commType == _CommType.RBC)
            {
                mainForm.SendToRBC(asm);
            }
        }
        public void SendAck(AbstractRecvMessage arm)
        {
            Message146 m146 = new Message146();
            m146.T_TRAIN2 = arm.T_TRAIN;
            SendMsg(m146, _CommType.RBC);
        }
    }
}
