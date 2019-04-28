using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Train.Packets;
using Train.Messages;
using System.Windows.Forms;

namespace Train.MessageHandlers
{
    /// <summary>
    /// 处理MA相关报文信息
    /// </summary>
    class MA_MH : AbstractMessageHandler
    {
        public static Packet057 p57;
        Thread maRequestThread = null;
        int timer = 0;
        public MA_MH()
        {
            maRequestThread = new Thread(new ThreadStart(SendMARequest));
            maRequestThread.IsBackground = true;
            //it is not a good idea to start a thread in constructors
            maRequestThread.Start();
        }
        public override bool Solve(AbstractRecvMessage arm)
        {
            int msgId = arm.GetMessageID();

            if (msgId == 3)
            {
                MH((Message003)arm);
                return true;
            }
            //确认前方轨道空闲
            if(msgId == 34)
            {
                if (arm.M_ACK)
                    SendAck(arm);
                //发送前方轨道空闲确认
                Message149 m149 = new Message149();
                m149.SetPacket0or1(Trains.TrainDynamics.GetPacket0());
                SendMsg(m149, _CommType.RBC);
                //应该还要加上模式切换（OS、FS等），目前还不知道怎么做
                return true;
            }
            return false;
        }
        void MH(Message003 m3)
        {
            if (m3.M_ACK)
            {
                SendAck(m3);
            }
            PH(m3.GetPacket015());
            foreach (AbstractPacket ap in m3.GetAlternativePacket())
            {
                Type type = ap.GetType();
                if (type == typeof(Packet041)) PH((Packet041)ap);
                else if (type == typeof(Packet015)) PH((Packet015)ap);
                //else if (type == typeof(Packet068)) PH((Packet068)ap);
                //else if (type == typeof(Packet05)) PH((Packet05)ap);
                //else if (type == typeof(Packet003)) PH((Packet003)ap);
                else
                {
                    MessageBox.Show("Unhandled Packet in Message003:" + type.ToString());
                }
            }
        }
        private MA ma = new MA();//MA运算放在此类中
        void PH(Packet015 p15)
        {
            ma.GetValueFrom(p15);
        }
        void PH(Packet041 p41)
        {
            //开启一个线程处理等级切换
            Thread t = new Thread(new ParameterizedThreadStart(HandleC2C3Switch));
            t.IsBackground = true;
            t.Start(p41);
        }
        //处理ATP等级转换C2->C3 或 C3->C2
        public void HandleC2C3Switch(object obj)//必须用object作为形参类型
        {
            Packet041 p41 = (Packet041)obj;
            TrainState startState = mainForm.GetTrainState();
            int d_leveltr = p41.GetDLevelTr();
            //假设列车沿下行正向行驶
            while((startState.TrainLocation.RightLoc-d_leveltr)<0)
            {
                //让列车继续运行，直到列车前端越过等级转换点
            }
            if(p41.GetMLevelTr()==1)//switch to C2
            {
                mainForm.rbControlLevel_CheckedChanged(_ControlLevel.CTCS_2, null);
            }else if (p41.GetMLevelTr() == 3)//switch to C3
            {
                mainForm.rbControlLevel_CheckedChanged(_ControlLevel.CTCS_3, null);
            }
        }

        //根据p57包周期发送MA请求的线程
        public void SendMARequest()
        {
            while(Thread.CurrentThread.ThreadState != ThreadState.AbortRequested)
            {
                //列车还未收到p57包时，不需要周期判断MA请求
                if (p57 == null)
                {
                    Thread.Sleep(100);
                    continue;
                }
                //目前先只考虑T_CYCRQST参数
                if (timer > p57.GetTcycRqst())
                {
                    Message132 m132 = new Message132();
                    m132.SetTrackdel(false);//未删除线路描述
                    m132.SetPacket0or1(Trains.TrainDynamics.GetPacket0());
                    SendMsg(m132, _CommType.RBC);
                    timer = 0;//定时器清零
                }
                Thread.Sleep(1000);
                timer++;
            }
        }
    }

}
