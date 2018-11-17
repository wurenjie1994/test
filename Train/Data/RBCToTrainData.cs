using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Train.Messages;

namespace Train.Data
{
    public class RBCToTrainData
    {
        private static RBCToTrainData instance = new RBCToTrainData();
        private RBCToTrainData() { }
        public static RBCToTrainData GetInstance()
        {
            return instance;
        }
        Message003 message = new Message003();
        /**
         * 要有相应的get方法
         * */
    }
}
