using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Messages;
namespace Train.MessageHandlers
{
    public class MessageHandler
    {
        private CommSession_MH mhCommSession ;
        private EB_MH mhEB ;
        private General_MH mhVersion ;
        private MA_MH mhMa ;
        private LocReport_MH mhLocReport ;
        private UltimateHandler_MH mhUltimateHandler ;

        public static MainForm mainForm;
        private _CommType commType;
        public MessageHandler(_CommType commType)
        {
            this.commType = commType;
        }

        //设置责任链
        public void Init(MainForm mf)
        {
            mainForm = mf;
            mhCommSession = new CommSession_MH(this);
            mhEB = new EB_MH(this);
            mhVersion = new General_MH(this);
            mhMa = new MA_MH(this);
            mhLocReport = new LocReport_MH(this);
            mhUltimateHandler = new UltimateHandler_MH(this);
            mhCommSession.SetNext(mhEB).SetNext(mhVersion)
                .SetNext(mhMa).SetNext(mhLocReport)
                .SetNext(mhUltimateHandler).SetNext(null);
        }
        //处理接收到的报文
        public void Handling(Messages.AbstractRecvMessage am)
        {
            AbstractMessageHandler amh = mhCommSession;
            while (!amh.Solve(am))
                amh = amh.GetNext();
        }

        public _CommType CommType { get { return commType; } }
        public MA_MH MhMa { get { return mhMa; } }
        public LocReport_MH MhLocReport { get { return mhLocReport; } }
    }
}
