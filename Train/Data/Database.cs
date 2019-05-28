using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train.Data
{
    public class Database
    {
        public void Init()
        {
            Connect();
            InitTrainInfo();
            InitBaliseGroup();
        }
        public static void InitTrainInfo()
        {
            TrainInfo.TrainID = 0x123456;
            TrainInfo.L_TRAIN = 140;//设为140米
            TrainInfo.NID_ENGINE = 10020632;
            TrainInfo.NID_XUSER = 123;
            TrainInfo.NID_OPERATIONAL = 0x12345678;
            TrainInfo.NC_TRAIN = 0;
            TrainInfo.V_MAXTRAIN = 70;// 70*5 km/h
            TrainInfo.M_LOADINGGAUGE = 0x01;
            TrainInfo.M_AXLELOAD = 10;
            TrainInfo.M_AIRTIGHT = 0;
            TrainInfo.NID_STMList.Add(1);//假定STM编号为1
            TrainInfo.NID_RADIOList.Add(0x1234567890123456);//假定值
            TrainInfo.M_TRACTION.Add(0x12);//假定值

        }

        public void InitBaliseGroup()
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select Name,BaliseNum,Kilo,Type,`Use`,PS1,PS2 from down_balise;";//use 是mysql中关键字，使用时要用反引号``括起来
            //cmd.ExecuteNonQuery();        //用于增删改
            MySqlDataReader data = cmd.ExecuteReader();   //用于查找
            List<Balise> list = Trains.TrainDynamics.DownBgList;
            while (data.Read())
            {
                Balise balise = new Balise();
                balise.BaliseName=data.GetString(0);
                balise.BaliseNumber = data.GetString(1);
                string[] kilo = data.GetString(2).Split('+');
                balise.Position = Convert.ToInt32(kilo[0].Trim('k', 'K')) * 1000 + Convert.ToInt32(kilo[1]);
                balise.IsSourced = "有源".Equals(data[3]);
                balise.Usage = (data[4] == DBNull.Value) ? null : data.GetString(4);
                balise.Remark1 = (data[5] == DBNull.Value) ? null : data.GetString(5);
                balise.Remark2 = (data[6] == DBNull.Value) ? null : data.GetString(6);
                list.Add(balise);
            }
            data.Close();
        }
        MySqlConnection conn;
        public void Connect()
        {
            String connectionString = "server=127.0.0.1;uid=wrj;pwd=1234;database=test";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MessageBox.Show("数据库连接成功！");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //conn.Close();
            }
        }
        public void Close()
        {
            if (conn != null)
                conn.Close();
        }

    }
}
