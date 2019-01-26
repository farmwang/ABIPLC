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
    public class TagKPI
    {
        public string TagID { set; get; }
        public EqpSpanDuration M2 { set; get; }
        public EqpSpanDuration M5 { set; get; }
        public EqpSpanDuration M10 { set; get; }
        public EqpSpanDuration M15 { set; get; }
        public EqpSpanDuration M30 { set; get; }
        public EqpSpanDuration M60 { set; get; }

    }
   public class EqpKPI
    {
        public static Dictionary<string, TagKPI> Dic = new Dictionary<string, TagKPI>();
        public static Dictionary<string, double> CKPI = new Dictionary<string, double>();
        public static string L1TagID = "";
        public static string L2TagID = "";
        public static string L3TagID = "";
        public static double L1KPI = 0;
        public static double L2KPI = 0;
        public static double L3KPI = 0;



        public static void Init()
        {
            Dic.Clear();
            CKPI.Clear();

            TagKPI Depack = new TagKPI();
            Depack.TagID = EqpName.DepackStatusTagID;
            Dic.Add(Depack.TagID,Depack);
            CKPI.Add(Depack.TagID, 0);

            TagKPI Filler = new TagKPI();
            Filler.TagID = EqpName.FillerStatusTagID;
            Dic.Add(Filler.TagID, Filler);
            CKPI.Add(Filler.TagID, 0);


            TagKPI Pasteurizer = new TagKPI();
            Pasteurizer.TagID = EqpName.PasteurizerStatusTagID;
            Dic.Add(Pasteurizer.TagID, Pasteurizer); 
            CKPI.Add(Pasteurizer.TagID, 0);


            TagKPI Pack3 = new TagKPI();
            Pack3.TagID = EqpName.Pack3StatusTagID;
            Dic.Add(Pack3.TagID, Pack3);
            CKPI.Add(Pack3.TagID, 0);


            TagKPI Pack4 = new TagKPI();
            Pack4.TagID = EqpName.Pack4StatusTagID;
            Dic.Add(Pack4.TagID, Pack4);
            CKPI.Add(Pack4.TagID, 0);

            TagKPI Pack5 = new TagKPI();
            Pack5.TagID = EqpName.Pack5StatusTagID;
            Dic.Add(Pack5.TagID, Pack5);
            CKPI.Add(Pack5.TagID, 0);

            TagKPI Pack6 = new TagKPI();
            Pack6.TagID = EqpName.Pack6StatusTagID;
            Dic.Add(Pack6.TagID, Pack6);
            CKPI.Add(Pack6.TagID, 0);




            TagKPI Palletizer1 = new TagKPI();
            Palletizer1.TagID = EqpName.Palletizer1StatusTagID;
            Dic.Add(Palletizer1.TagID, Palletizer1);
            CKPI.Add(Palletizer1.TagID, 0);

            TagKPI Palletizer2 = new TagKPI();
            Palletizer2.TagID = EqpName.Palletizer2StatusTagID;
            Dic.Add(Palletizer2.TagID, Palletizer2);
            CKPI.Add(Palletizer2.TagID, 0);

            TagKPI Wrap = new TagKPI();
            Wrap.TagID = EqpName.WrapStatusTagID;
            Dic.Add(Wrap.TagID, Wrap);
            CKPI.Add(Wrap.TagID, 0);



        }

        public static void CL1Tailback(string formid)
        {
            try
            {
                SetKPI();
                GetL1L2L3();
                CalculateL1(formid);
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
           
        }

        public static void SetKPI()
        {
            EqpSpanDuration kpi = null;
            foreach(var P in Dic)
            {
                kpi= CalculateDuration.Get2MKPI(P.Key);
                if (kpi != null)
                {
                    P.Value.M2.Ex = false;
                    P.Value.M2.Down = kpi.Down;
                    P.Value.M2.Run = kpi.Run;
                    P.Value.M2.KPI = kpi.KPI; 
                }
                else
                {
                    P.Value.M2.Ex = true;
                }

                kpi = CalculateDuration.Get5MKPI(P.Key);
                if (kpi != null)
                {
                    P.Value.M5.Ex = false;
                    P.Value.M5.Down = kpi.Down;
                    P.Value.M5.Run = kpi.Run;
                    P.Value.M5.KPI = kpi.KPI;
                }
                else
                {
                    P.Value.M5.Ex = true;
                }

                kpi = CalculateDuration.Get10MKPI(P.Key);
                if (kpi != null)
                {
                    P.Value.M10.Ex = false;
                    P.Value.M10.Down = kpi.Down;
                    P.Value.M10.Run = kpi.Run;
                    P.Value.M10.KPI = kpi.KPI;
                }
                else
                {
                    P.Value.M10.Ex = true;
                }


                kpi = CalculateDuration.Get15MKPI(P.Key);
                if (kpi != null)
                {
                    P.Value.M15.Ex = false;
                    P.Value.M15.Down = kpi.Down;
                    P.Value.M15.Run = kpi.Run;
                    P.Value.M15.KPI = kpi.KPI;
                }
                else
                {
                    P.Value.M15.Ex = true;
                }



                kpi = CalculateDuration.Get30MKPI(P.Key);
                if (kpi != null)
                {
                    P.Value.M30.Ex = false;
                    P.Value.M30.Down = kpi.Down;
                    P.Value.M30.Run = kpi.Run;
                    P.Value.M30.KPI = kpi.KPI;
                }
                else
                {
                    P.Value.M30.Ex = true;
                }

                //kpi = CalculateDuration.Get60MKPI(P.Key);
                //if (kpi != null)
                //{
                //    P.Value.M60.Ex = false;
                //    P.Value.M60.Down = kpi.Down;
                //    P.Value.M60.Run = kpi.Run;
                //    P.Value.M60.KPI = kpi.KPI;
                //}
                //else
                //{
                //    P.Value.M60.Ex = true;
                //}

                CKPI[P.Key] = P.Value.M2.KPI*0.2 + P.Value.M5.KPI*0.2 + P.Value.M10.KPI*0.2 + P.Value.M15.KPI*0.2 + P.Value.M30.KPI*0.2 ;

            }
        }



        public static void GetL1L2L3()
        {
            double L1kpi = 1;
            string L1tagid = "";

            double L2kpi = 1;
            string L2tagid = "";

            double L3kpi = 1;
            string L3tagid = "";


            foreach (var P in CKPI)
            {
                if (P.Value < L1kpi)
                {
                    L1kpi = P.Value;
                    L1tagid = P.Key;
                }
            }

            foreach(var P in CKPI)
            {
                if (P.Key != L1tagid)
                {
                    if (P.Value < L2kpi)
                    {
                        L2kpi = P.Value;
                        L2tagid = P.Key;
                    }
                }
            }

            foreach (var P in CKPI)
            {
                if (P.Key != L1tagid&&P.Key!=L2TagID)
                {
                    if (P.Value < L3kpi)
                    {
                        L3kpi = P.Value;
                        L3tagid = P.Key;
                    }
                }
            }

            L1KPI = L1kpi;
            L2KPI = L2kpi;
            L3KPI = L3kpi;
            L1TagID = L1tagid;
            L2TagID = L2tagid;
            L3TagID = L3tagid;



        }



        public static void CalculateL1(string formid)
        {

            if (L1KPI > 0.6)
            {

            }
            else
            {

            }

            DTFiller.UpdateRiseEqp(formid, L1TagID, EqpName.GetEqpName(L1TagID));

            Log.Info("[EqpKPI][CalculateL1][FormID] "+formid+"  L1TagID " + L1TagID);
        }


    }
}
