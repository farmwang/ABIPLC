using System;
using System.Collections.Generic;
using System.Text;

namespace QMNCPLCS7
{
   public class GlobalName
    {
       

    }


    
    

   public class EqpName
    {
        public readonly static string Depack = "Depack";
        public readonly static string DepackStatusTagID = "101101";

        public readonly static string Filler = "CL1_Filler";
        public readonly static string FillerStatusTagID = "101001";


        public readonly static string CIP = "CIP";
        public readonly static string CIPStatusTagID = "101201";

        public readonly static string Pasteurizer = "CL1_Pasteurizer";
        public readonly static string PasteurizerStatusTagID = "102001";


        public readonly static string Pack1 = "CL1_Pack1";
        public readonly static string Pack1StatusTagID = "xxx";
        public readonly static string Pack2 = "CL1_Pack2";
        public readonly static string Pack2StatusTagID = "xxx";


        public readonly static string Pack3 = "Pack3";
        public readonly static string Pack3StatusTagID = "101301";

        public readonly static string Pack4 = "Pack4";
        public readonly static string Pack4StatusTagID = "101401";


        public readonly static string Pack5 = "Pack5";
        public readonly static string Pack5StatusTagID = "103201";

        public readonly static string Pack6= "Pack6";
        public readonly static string Pack6StatusTagID = "103301";



        public readonly static string Palletizer1 = "Palletizer1";
        public readonly static string Palletizer1StatusTagID = "101501";

        public readonly static string Palletizer2 = "Palletizer2";
        public readonly static string Palletizer2StatusTagID = "101601";


        public readonly static string Wrap = "Wrap";
        public readonly static string WrapStatusTagID = "101701";



        public static string GetEqpName(string tagid)
        {
            switch (tagid)
            {
                case "101101":
                    return Depack;
                case "101001":
                    return Filler;
                case "101201":
                    return CIP;
                case "102001":
                    return Pasteurizer;
                case "101301":
                    return Pack3;
                case "101401":
                    return Pack4;
                case "101501":
                    return Palletizer1;
                case "101601":
                    return Palletizer2;
                case "101701":
                    return Wrap;
                default:
                    return "";

            }
        }
        
    }
    





    public class SpanStatus
    {
        public string Status { set; get; }
        public double Duration { set; get; }
    }


    public class EqpSpanDuration
    {
        public bool Ex { set; get; }
        public string TagID { set; get; }
        public double Down { set; get; }
        public double Run { set; get; }
        public double KPI { set; get; }
        public EqpSpanDuration()
        {
            Ex = false;
            Down = 0;
            Run = 0;
            KPI = 0;
        }
    }
}
