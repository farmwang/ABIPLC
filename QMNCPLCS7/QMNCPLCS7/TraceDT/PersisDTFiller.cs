using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;
using System.Threading;
using QMNetCoreFrame.Form;
using QMNCPLCS7;

namespace QMNCPLCS7.TraceDT
{
  public  class PersisDTFiller
    {

        public static string CL1NewDTFiller(string RiseTagID,string RiseEqp,string RiseStatus ,uint real)
        {
            string formid = FormID.GetFormID();
            try
            {
               KMStatus status = KAGStatus.GetStatus(real);

                DTFiller data = new DTFiller();
                data.Start_time = DateTime.Now;
                data.End_time = DateTime.Now.AddMinutes(0.3);
                data.create_time = DateTime.Now;
                data.Duration = 0.2;
                data.FormID = formid;
                data.PDate = DateTime.Now;
                data.TagID = "101001";
                data.LineID = "CL1";
                data.DeviceID = "Filler";
                if (status.ISDown)
                {
                    data.IsDown = "Y";
                }
                else
                {
                    data.IsDown = "N";
                }
                
                data.Status = status.Status;
                data.Create_by = "DTCal";
                data.RiseEqp = EqpName.GetEqpName(RiseTagID);
                data.RiseTagID = RiseTagID;

                DTFiller.CreateNew(data);

            }
            catch(Exception ex)
            {
                formid = null;
                Log.Error(ex.ToString());
            }
           


            return formid;
        }


      

    }
}
