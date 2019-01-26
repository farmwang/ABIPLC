using System;
using System.Collections.Generic;
using System.Text;
 
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;
using System.Threading;
using QMNetCoreFrame.TaskUtility;

namespace QMNCPLCS7
{
   public class JobDT
    {
        public static bool loop = true;
      //  int rv = 0;
       
        public static void Compare()
        {
            try
            {
                PLCHisData hisdata = null;
                foreach (var R in RealData.dic)
                {
                    if (R.Value == uint.MaxValue)  //判断是否断线
                    {
                        hisdata = FrontData.dic[R.Key];
                        hisdata.refid = 0;
                        hisdata.Time = DateTime.Now;
                        hisdata.Value = uint.MaxValue;

                    }
                    else
                    {
                        Log.Info("[JobDT] TagID: " + R.Key + "  Real Value  " + R.Value + "===" + FrontData.dic[R.Key].Value + "   HisData Value ");
                        if (R.Value == FrontData.dic[R.Key].Value)//设备状态没有变化
                        {
                            hisdata = FrontData.dic[R.Key];
                            TimeSpan span = DateTime.Now - hisdata.Time;
                            double muni = span.TotalMinutes;
                            if (muni > 2)
                            {
                                DTKAG.PlusDT(hisdata.refid, muni);
                                hisdata.Time = DateTime.Now;
                                if (R.Key == EqpName.FillerStatusTagID)
                                {
                                    if (!string.IsNullOrEmpty(hisdata.formid))
                                    {
                                        DTFiller.DTPlusDuration(hisdata.formid, muni);
                                    }
                                }
                            }
                          //  hisdata.Value = R.Value;
                        }
                        else  //设备状态有变化
                        {
                            QMNCPLCS7.TraceDT.TraceCL1.CloseLoop();


                            hisdata = FrontData.dic[R.Key];
                            TimeSpan span = DateTime.Now - hisdata.Time;
                            double muni = span.TotalMinutes;

                            DTKAG.PlusDTFinish(hisdata.refid, muni);  //结束上一状态

                            hisdata.refid = DTKAG.KAGCreateNewDT(hisdata.TagID,hisdata.type, R.Value);//创建新的状态
                            hisdata.Time = DateTime.Now;  //更新 FrontData
                            hisdata.Value = R.Value;

                            if (R.Key == EqpName.FillerStatusTagID)  //如果是Filler 结束 FIller状态
                            {
                                if (!string.IsNullOrEmpty(hisdata.formid))
                                {
                                    DTFiller.DTPlusDurationFinish(hisdata.formid, muni);
                                    if (R.Value == 8)
                                    {
                                        hisdata.formid = QMNCPLCS7.TraceDT.PersisDTFiller.CL1NewDTFiller(EqpName.DepackStatusTagID, EqpName.Depack, "", RealData.dic[EqpName.FillerStatusTagID]);

                                    }
                                    else if (R.Value == 16)
                                    {
                                        QMNCPLCS7.TraceDT.TraceCL1.SetLoop();
                                        FuncAsyn.RunP1(QMNCPLCS7.TraceDT.TraceDownEqp.Run, hisdata.formid);
                                    }
                                    else if(R.Value==128)
                                    {

                                    }
                                    else
                                    {
                                        hisdata.formid = QMNCPLCS7.TraceDT.PersisDTFiller.CL1NewDTFiller(EqpName.FillerStatusTagID, EqpName.Filler, "", RealData.dic[EqpName.FillerStatusTagID]);

                                    }

                                }

                                
                            }

                           

                             
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
           
        }

        public static void ChangeStatus(string tagid,uint real, PLCHisData front)
        {

        }

        public static void Run()
        {
            while (loop)
            {
                Log.Info("[JobDT ][Loop]");
                Thread.Sleep(20000);
                
                try
                {
                    Compare();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }
    }
}
