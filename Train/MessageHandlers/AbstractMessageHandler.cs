using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static UltimateHandler_MH mhUltimateHandler = new UltimateHandler_MH();
        //设置责任链
        public static void Init()
        {
            mhCommSession.SetNext(mhEB)
                .SetNext(mhUltimateHandler).SetNext(null);
        }
        //处理接收到的报文
        public static void Handling(Messages.AbstractRecvMessage am)
        {
            AbstractMessageHandler amh = mhCommSession;
            while (!amh.Solve(am))
                amh = amh.GetNext();
        }
    }
}
