﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Train.Messages;

namespace Train.MessageHandlers
{
    /// <summary>
    /// Dealing with entering shunting mode request
    /// </summary>
    class Shunt_MH : AbstractMessageHandler
    {
        public Shunt_MH(MessageHandler mh) : base(mh) { }

        public override bool Solve(AbstractRecvMessage arm)
        {
            int msgId = arm.GetMessageID();
            if(msgId == 28) // acknowledge shunting mode
            {
                if (arm.M_ACK) SendAck(arm);
                mainForm.BeginInvoke(new EventHandler(mainForm.rbWorkMode_CheckedChanged), _M_MODE.SH, null);
                Message150 m150 = new Message150();
                // mode may not be changed in time, so wait until it changed.
                while(Trains.TrainDynamics.GetPacket0().M_MODE != (int)_M_MODE.SH)
                {
                    Thread.Sleep(10);
                }
                m150.SetPacket0or1(Trains.TrainDynamics.GetPacket0());
                SendMsg(m150);
                return true;
            }
            if(msgId == 27) // refuse shunting mode
            {
                if (arm.M_ACK) SendAck(arm);
                return true;
            }
            return false;
        }
    }
}
