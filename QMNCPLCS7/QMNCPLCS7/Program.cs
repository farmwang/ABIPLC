
using System;
using QMNetCorePLCS7;
using QMNetCoreFrame.Log;
using QMNetCoreFrame.MSSql;
using System.Threading;
using QMNetCoreFrame.TaskUtility;
using QMNCPLCS7.TraceDT;

namespace QMNCPLCS7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            QMNetCoreFrame.Log.Log.InitLog();
            //QMNetCoreFrame.MSSql.MSSql.ConnStr = "Server=127.0.0.1,1433;Database=EXLD;User ID=mes;Password=Fy861213";
            
              QMNetCoreFrame.MSSql.MSSql.ConnStr = "Server=127.0.0.1,1433;Database=EXLD;User ID=mes;Password=Krones1itk";


            
            //ReadPLC();
            RowConfig.InitData();

            Log.Info("Init Device IP Datapoint Finished");
            RowConfig.InitDic();

            Log.Info("Init Dic Finished");
            RowConfig.InitTagDic();

            Log.Info("Init TagDic Finished");
            //
            //FuncAsyn.RunP0(JobGetPLCData.GetFirstDataFromPLC);
            EqpKPI.Init();
            Log.Info("EqpKPI Dic Init Finished");


            QMNCPLCS7.OEM.DBChange.Init();
            QMNCPLCS7.OEM.DBChange.Run();


            JobGetPLCData.GetFirstDataFromPLC();

            Thread.Sleep(60000);
            FuncAsyn.RunP0(JobGetPLCData.Run);

            Thread.Sleep(180000);
            FuncAsyn.RunP0(JobDT.Run);
         
            while (loop)
            {
                Log.Info("[Program Main Thread][Loop]");
                Thread.Sleep(1000000000);
               // JobGetPLCData.GetDataFromPLC();

                
            }
            

            Console.ReadLine();
        }

        private static void ReadPLC()
        {
            try
            {
                Plc plc = PLCSingleton.CreatePLC(CpuType.S7300, "10.21.189.139", 0, 2);    //new Plc(CpuType.S7300, "10.21.189.139", 0, 2);
                plc.Open();
                UInt32 str = (UInt32)plc.Read(DataType.DataBlock, 181, 0, VarType.DWord, 1);

                Console.WriteLine("Status  "+str.ToString());

                str = (UInt32)plc.Read(DataType.DataBlock, 181, 4, VarType.DWord, 1);
                Console.WriteLine("Operation  " + str.ToString());

                str = (UInt32)plc.Read(DataType.DataBlock, 181, 8, VarType.DWord, 1);
                Console.WriteLine("Program   " + str.ToString());

                str = (UInt32)plc.Read(DataType.DataBlock, 181, 12, VarType.DWord, 1);
                Console.WriteLine("First alarm    " + str.ToString());

                str = (UInt32)plc.Read(DataType.DataBlock, 181, 16, VarType.DWord, 1);
                Console.WriteLine("Current message     " + str.ToString());
               

                plc.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           

        }



        private object ReadAddress(Plc plc, string address, VarType datatype)
        {

            if (!string.IsNullOrEmpty(address))
            {
                string type = address.Substring(0, 1);
                object obj = null;
                int fix = 3;
                int db = 0;
                int startadr = 0;
                switch (type)
                {
                    case "D":
                        fix = address.IndexOf('.');
                        db = Convert.ToInt32(address.Substring(2, fix - 2));
                        startadr = Convert.ToInt32(address.Substring(fix + 4));
                        obj = plc.Read(DataType.DataBlock, db, startadr, datatype, 1);
                        //label1.Text = db.ToString() + "  " + startadr.ToString() + " ";
                        break;
                    case "M":
                        startadr = Convert.ToInt32(address.Substring(2));
                        obj = plc.Read(DataType.Memory, 0, startadr, datatype, 1);
                       // label1.Text = startadr.ToString() + " ";
                        break;
                    case "C":
                        break;
                    case "I":
                        break;
                    case "O":

                        break;

                    case "Q":
                        fix = address.IndexOf('.');
                        // startadr = Convert.ToInt32(address.Substring(fix + 4));
                        obj = plc.Read(DataType.Output, 8, 3, datatype, 1);
                        break;
                    case "T":
                        break;
                    default:
                        break;
                }


                return obj;
            }
            else
            {

                return null;
            }
        }

        private void ReadM()
        {
            Plc plc = new Plc(CpuType.S7300, "172.29.132.18", 0, 2);
            plc.Open();
            //   float str = (float)plc.Read(DataType.Memory, 0, 622, VarType.Real, 1); 
            bool str = (bool)plc.Read(DataType.Output, 8, 3, VarType.Bit, 6);
          //  textBox1.Text = str.ToString();
            plc.Close();
        }


    }
}
