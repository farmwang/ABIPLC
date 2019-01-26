using System;
using System.Collections.Generic;
using System.Text;
using QMNCPLCS7.Entities;
using QMNetCoreFrame.Log;

namespace QMNCPLCS7
{
  public  class DTKAG
    {

        public static void DTFiller(string tagid,uint real,uint front)
        {
            switch (real)
            {
                case 1:  //Stopped 
                    CL1NewDT("CL1Filler", true, "Stopped");
                    break;

                case 2:  //Starting

                    break;

                case 4:  //Prepared

                    break;
                case 8:   //Lack

                    break;
                case 16:  //Tailback

                    break;

                case 32:  //Lack Branch Line

                    break;

                case 64:  //Tailback Branch Line

                    break;

                case 128:  //Operating

                    break;

                case 256:  //Stopping

                    break;

                case 512:  //Aborting

                    break;
                case 1024:  //Equipment Failure

                    break;

                case 2048:  //External Failure

                    break;


                case 4096:  //Emergency Stop

                    break;

                case 8192:  //Holding

                    break;

                case 16384:  //Held

                    break;
                default:
                    break;
            }
        }

        public static UInt64 KAGCreateNewDT(string tagid,string type, uint real)
        {
            UInt64 refid = 0;
            KMStatus status = new KMStatus();
            TagData taginfo = RowConfig.TagDic[tagid];
            try
            {
                
                if (taginfo == null)
                {
                    return 0;
                }

                if (type == "Status")
                {
                    status = KAGStatus.GetStatus(real);
                }
                else if (type == "Operation")
                {
                    status = KAGStatus.GetMode(real);
                }
                else if (type == "Program")
                {
                    status = KAGStatus.GetProgram(real);
                }
                else if (type == "CL1OEM")
                {
                    status = QMNCPLCS7.Status.CL1OEMStatus.GetStatus(real);
                }
                else
                {
                    status.Status = "UnKnow";
                }
                refid= NewDT(taginfo.LineID, taginfo.DeviceID,tagid, status.ISDown, status.Status,real);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                refid= DTRecord.GetMaxRefid(taginfo.DeviceID);
            }


            return refid;

            
        }


        public static UInt64 KAGCreateNewDT(string tagid,uint real)
        {
            TagData taginfo = RowConfig.TagDic[tagid];
            if (taginfo == null)
            {
                return 0;
            }
            
            switch (real)
            {
                case 1:  //Stopped 
                   return  NewDT(taginfo.LineID,taginfo.DeviceID, true, "Stopped");
                     

                case 2://Starting
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Starting");  

                    

                case 4:  //Prepared
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Prepared");
                    
                case 8:   //Lack
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Lack");
                   
                case 16:  //Tailback
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Tailback");
                  

                case 32:  //Lack Branch Line
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Lack Branch");
                    

                case 64:  //Tailback Branch Line
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Tailback");
                    

                case 128:  //Operating
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Operating");
                    

                case 256:  //Stopping
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Stopping");
                    

                case 512:  //Aborting
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Aborting");
                    
                case 1024:  //Equipment Failure
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Equipment Failure");
                   

                case 2048:  //External Failure
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "External Failure");
                     


                case 4096:  //Emergency Stop
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Emergency Stop");
                    

                case 8192:  //Holding
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Holding");
                 

                case 16384:  //Held
                    return NewDT(taginfo.LineID, taginfo.DeviceID, true, "Held");
                    
                default:
                    return 0; ;
            }

        }

        public static void PlusDT(UInt64 refid,double duration)
        {
            DTRecord.DTPlusDuration(refid, duration);
        }

        public static void PlusDTFinish(UInt64 refid, double duration)
        {
            DTRecord.DTPlusDurationFinish(refid, duration);
        }

        public static UInt64 CL1NewDT(string DeviceId,bool IsDown,string Status)
        {
            DTRecord data = new DTRecord();
            data.LineID = "CL1";
            data.PDate = DateTime.Now;
           
            data.DeviceID = DeviceId;

            if (IsDown)
            {
                data.IsDown = "Y";
            }
            else
            {
                data.IsDown = "N";
            }

            data.Start_time = DateTime.Now;
            data.Duration = 1;
            data.status = Status;

            DTRecord.CreateNew(data);

            return DTRecord.GetMaxRefid(DeviceId);
        }



        public static UInt64 NewDT(string LineID,string DeviceId, bool IsDown, string Status)
        {
            DTRecord data = new DTRecord();
            data.LineID = LineID;
            data.PDate = DateTime.Now;

            data.DeviceID = DeviceId;

            if (IsDown)
            {
                data.IsDown = "Y";
            }
            else
            {
                data.IsDown = "N";
            }

            data.Start_time = DateTime.Now;
            data.Duration = 0;
            data.status = Status;

            DTRecord.CreateNew(data);

            return DTRecord.GetMaxRefid(DeviceId);
        }


        public static UInt64 NewDT(string LineID, string DeviceId,string TagID, bool IsDown, string Status)
        {
            DTRecord data = new DTRecord();
            data.LineID = LineID;
            data.PDate = DateTime.Now;
            data.TagID = TagID;
            data.DeviceID = DeviceId;

            if (IsDown)
            {
                data.IsDown = "Y";
            }
            else
            {
                data.IsDown = "N";
            }

            data.Start_time = DateTime.Now;
            data.Duration = 0.2;
            data.status = Status;
            data.End_time = DateTime.Now.AddMinutes(0.2);
            DTRecord.CreateNew(data);

            return DTRecord.GetMaxRefid(DeviceId);
        }


        public static UInt64 NewDT(string LineID, string DeviceId, string TagID, bool IsDown, string Status,uint real)
        {
            DTRecord data = new DTRecord();
            data.LineID = LineID;
            data.PDate = DateTime.Now;
            data.TagID = TagID;
            data.DeviceID = DeviceId;
            data.Value = real;
            if (IsDown)
            {
                data.IsDown = "Y";
            }
            else
            {
                data.IsDown = "N";
            }

            data.Start_time = DateTime.Now;
            data.Duration = 0.2;
            data.status = Status;
            data.End_time = DateTime.Now.AddMinutes(0.2);
            DTRecord.CreateNew(data);

            return DTRecord.GetMaxRefid(DeviceId);
        }



    }
}
