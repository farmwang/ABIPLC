using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;
using System.Threading;

namespace QMNCPLCS7.TraceDT
{

    public class HisFiller
    {
        public static string TagID = "101001";
        public static UInt64 refid = 0;
        public static string RiseEqp = "";
        public static DateTime Time;


    }
  public  class TraceCL1
    {
        private static bool loop = true;
        private static bool isquit = false;
        private static  string DepackS = "";
        
        private static string FillerS = "";
        private static string CIPS = "";
        private static string PasteurizerS = "";
        private static string Pack1S = "";
        private static string Pack2S = "";
        private static string Pack3S = "";
        private static string Pack4S = "";
        private static string OEM1S = "";
        private static string OEM2S = "";
        private static string Palletizer1S = "";
        private static string Palletizer2S = "";
        private static string WrapS = "";


        private static string DepackV = ""; 
        private static string FillerV = "";
        private static string CIPV = "";
        private static string PasteurizerV = "";
        private static string Pack1V = "";
        private static string Pack2V = "";
        private static string Pack3V = "";
        private static string Pack4V = "";
        private static string OEM1SV = "";
        private static string OEM2V = "";
        private static string Palletizer1V = "";
        private static string Palletizer2V = "";
        private static string WrapV = "";

        private static string FormID = "";
        private static int loopcounter = 0;






        public static void Run(string formid)
        {
            Log.Info("Starting [TraceCL1][Run]...");
            try
            {
                loopcounter = 0;
                isquit = false;
                while (loop)
                {
                    GetDownEqp(formid);
                    loopcounter++;
                    Log.Info("[TraceCL1][FormID][Loop] " + formid + "  now loop " + loopcounter);
                    Thread.Sleep(30000);

                }
                isquit = true;
              
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
          
          

            Log.Info("End [TraceCL1][Run]...");

        }




        public static void SetLoop()
        {
            loop = true;
        }

        public static void CloseLoop()
        {
            isquit = true;
            loop = false;
        }

        public static bool IsQuit()
        {
            return isquit;
        }

        private static void GetDownEqp(string formid)
        {
            try
            {
                //FillerS = KAGStatus.GetStatus(RealData.dic["101001"]).Status;
                //if (!string.IsNullOrEmpty(FillerS))
                //{
                //    if (FillerS == "Lack")
                //    {

                //        DTFiller.UpdateRiseEqp(formid, EqpName.DepackStatusTagID, EqpName.Depack);

                //    }
                //    else if (FillerS == "Tailback")
                //    {
                        // GetVStatus();
                        //  GetStatus();
                        EqpKPI.CL1Tailback(formid);
                //    }
                //    else
                //    {
                //        DTFiller.UpdateRiseEqp(formid, EqpName.FillerStatusTagID, EqpName.Filler);

                //    }
                //}
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        private static void GetStatus()
        {
            DTFormStatus data = new DTFormStatus();
            data.FormID = FormID;
            data.LineID = "CL1";
            data.create_by = "DTCal";


            DepackS = KAGStatus.GetStatus(RealData.dic["101101"]).Status;
            data.DeviceID = "DePack";
            data.TagID = "101101";
            data.Status = DepackS;
            DTFormStatus.CreateNew(data);


            FillerS = KAGStatus.GetStatus(RealData.dic["101001"]).Status;
            data.DeviceID = "CL1_Filler";
            data.TagID = "101001";
            data.Status =FillerS;
            DTFormStatus.CreateNew(data);

            CIPS = KAGStatus.GetStatus(RealData.dic["101201"]).Status;

            data.DeviceID = "CL1_CIP";
            data.TagID = "101201";
            data.Status = CIPS;
            DTFormStatus.CreateNew(data);

            PasteurizerS = KAGStatus.GetStatus(RealData.dic["102001"]).Status;

            data.DeviceID = "CL1_Pasteurizer";
            data.TagID = "102001";
            data.Status = PasteurizerS;
            DTFormStatus.CreateNew(data);


            Pack3S = KAGStatus.GetStatus(RealData.dic["101301"]).Status;
            data.DeviceID = "CL1_Pack3";
            data.TagID = "101301";
            data.Status = Pack3S;
            DTFormStatus.CreateNew(data);

            Pack4S = KAGStatus.GetStatus(RealData.dic["101401"]).Status;
            data.DeviceID = "CL1_Pack4";
            data.TagID = "101401";
            data.Status = Pack4S;
            DTFormStatus.CreateNew(data);

            Palletizer1S = KAGStatus.GetStatus(RealData.dic["101501"]).Status;
            data.DeviceID = "CL1_Palletizer1";
            data.TagID = "101501";
            data.Status = Palletizer1S;
            DTFormStatus.CreateNew(data);

            Palletizer2S = KAGStatus.GetStatus(RealData.dic["101601"]).Status;
            data.DeviceID = "CL1_Palletizer2";
            data.TagID = "101601";
            data.Status = Palletizer2S;
            DTFormStatus.CreateNew(data);

            WrapS = KAGStatus.GetStatus(RealData.dic["101701"]).Status;
            data.DeviceID = "CL1_Wrap";
            data.TagID = "101701";
            data.Status = WrapS;
            DTFormStatus.CreateNew(data);
            //  OEM1S= KAGStatus.GetStatus(RealData.dic[""]).Status;
            //   OEM2S= KAGStatus.GetStatus(RealData.dic[""]).Status;



        }


        private static void GetVStatus()
        {
            DepackV = KAGStatus.CheckStatus(RealData.dic[EqpName.DepackStatusTagID]);
            FillerV = KAGStatus.CheckStatus(RealData.dic[EqpName.FillerStatusTagID]);
            CIPV = KAGStatus.CheckStatus(RealData.dic[EqpName.CIPStatusTagID]);
            PasteurizerV = KAGStatus.CheckStatus(RealData.dic[EqpName.PasteurizerStatusTagID]);
           // Pack1V = KAGStatus.CheckStatus(RealData.dic[EqpName.CIPStatusTagID]);
          //  Pack2V = KAGStatus.CheckStatus(RealData.dic[EqpName.CIPStatusTagID]);
            Pack3V = KAGStatus.CheckStatus(RealData.dic[EqpName.Pack3StatusTagID]);
            Pack4V = KAGStatus.CheckStatus(RealData.dic[EqpName.Pack4StatusTagID]);
          //  OEM1SV = KAGStatus.CheckStatus(RealData.dic[EqpName.CIPStatusTagID]);
            //OEM2V = KAGStatus.CheckStatus(RealData.dic[EqpName.CIPStatusTagID]);
            Palletizer1V = KAGStatus.CheckStatus(RealData.dic[EqpName.Palletizer1StatusTagID]);
            Palletizer2V = KAGStatus.CheckStatus(RealData.dic[EqpName.Palletizer2StatusTagID]);
            WrapV = KAGStatus.CheckStatus(RealData.dic[EqpName.WrapStatusTagID]);
        }
        private static void FirstTailBack(string tagid)
        {
          

            if(PasteurizerV== "Tailback"&&Pack3V== "Tailback"&&Pack4V== "Tailback"&&Palletizer1V== "Tailback"&&Palletizer2V== "Tailback")
            { 
                EqpDown.CreateWrapDown(FormID, WrapS); 
            }
            else if (PasteurizerV == "Down")
            {
                EqpDown.CreatePasteurizerDown(FormID, PasteurizerS);
            }
            else if (PasteurizerV == "Operating")
            {
                 
            }
            else if (PasteurizerV == "Tailback")
            {

            }


        }

       


        
    }
}
