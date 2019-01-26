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
   public class EqpDown
    {

         public static void CreateWrapDown(string FormID,string Status)
        {
            DTFiller data = new DTFiller();
            data.FormID = FormID;
            data.PDate = DateTime.Now;
            data.LineID = "CL1";
            data.DeviceID = EqpName.Filler;
            data.Start_time = DateTime.Now;
            data.End_time = DateTime.Now;
            data.Duration = 0.2;
            data.TagID = EqpName.FillerStatusTagID;
            data.IsDown = "Y";
            data.Status = KAGStatus.Status.Tailback.ToString();
            data.RiseEqp = EqpName.Wrap;
            data.RiseStatus = Status;
            data.RiseTagID = EqpName.WrapStatusTagID;
            data.Create_by = "DTCal";
            DTFiller.CreateNew(data);
            HisFiller.Time = DateTime.Now;
            HisFiller.refid = DTFiller.GetMaxRefid(FormID);
            HisFiller.RiseEqp = EqpName.Wrap;
        }



        public static void CreatePasteurizerDown(string FormID, string Status)
        {
            DTFiller data = new DTFiller();
            data.FormID = FormID;
            data.PDate = DateTime.Now;
            data.LineID = "CL1";
            data.DeviceID = EqpName.Filler;
            data.Start_time = DateTime.Now;
            data.End_time = DateTime.Now;
            data.Duration = 0.2;
            data.TagID = EqpName.FillerStatusTagID;
            data.IsDown = "Y";
            data.Status = KAGStatus.Status.Tailback.ToString();
            data.RiseEqp = EqpName.Wrap;
            data.RiseStatus = Status;
            data.RiseTagID = EqpName.WrapStatusTagID;
            data.Create_by = "DTCal";
            DTFiller.CreateNew(data);
            HisFiller.Time = DateTime.Now;
            HisFiller.refid = DTFiller.GetMaxRefid(FormID);
            HisFiller.RiseEqp = EqpName.Wrap;
        }

    }
}
