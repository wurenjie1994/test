using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Messages;

namespace Train.MessageHandlers
{
    /// <summary>
    /// Message应在此类之前被处理
    /// </summary>
    class UltimateHandler_MH : AbstractMessageHandler
    {

        /// <summary>
        /// 总是返回true
        /// </summary>
        /// <param name="am"></param>
        /// <returns></returns>
        public override bool Solve(AbstractMessage am)
        {
            return true;
        }
    
    }
}
