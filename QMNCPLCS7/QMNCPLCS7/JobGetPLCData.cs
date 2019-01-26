using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using System.Threading;
using QMNetCoreFrame.Log;
using QMNCPLCS7.TraceDT;


namespace QMNCPLCS7
{
   public class JobGetPLCData
    {
        static bool loop = true;
        public static void GetDataFromPLC()
        {
            try
            {
                UInt32 str = 0;
                ArrayList list = null;
                string openstr = "OK";
                object readobj = null;
                foreach (var adapter in RowConfig.EqpPoint)
                {
                    list = adapter.Value;
                    if (list != null)
                    {
                        RowDataPoint eqp = (RowDataPoint)list[0];
                        Plc plc = PLCSingleton.CreatePLC(CpuType.S7300, eqp.IP, 0, 2);    //new Plc(CpuType.S7300, "10.21.189.139", 0, 2);

                        try
                        {
                           openstr= plc.QMOpen();
                            if (openstr == "OK")
                            {
                                foreach (var V in list)
                                {
                                    eqp = (RowDataPoint)V;
                                    try
                                    {
                                        readobj= plc.QMRead((DataType)eqp.datatype, eqp.dbNumber, eqp.startByte, (VarType)eqp.vartype, 1);
                                       // str = (UInt32)plc.QMRead((DataType)eqp.datatype, eqp.dbNumber, eqp.startByte, (VarType)eqp.vartype, 1);
                                        if (readobj != null)
                                        {
                                            str = (UInt32)readobj;
                                            RealData.dic[eqp.TagID]= str;
                                          
                                            Console.WriteLine(eqp.TagID + "  Value is: " + str);

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error(ex.ToString());
                                    }

                                }

                            }
                            else
                            {
                                SetEQPRealDataMax(eqp.EQP);
                                Log.Error("[PLC][Link Fail] IP Address is : " + eqp.IP);
                                Log.Error(openstr);
                            }
                            //  throw new InvalidAddressException("To few periods for DB address");
                            plc.Close();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
           
        }

        public static void GetFirstDataFromPLC()
        {
            try
            {
               
                UInt32 str = 0;
                ArrayList list = null;
                string openstr = "OK";
                object readobj = null;
                PLCHisData plchis = null;
                foreach (var adapter in RowConfig.EqpPoint)
                {
                    list = adapter.Value;
                    if (list != null)
                    {
                        RowDataPoint eqp = (RowDataPoint)list[0];
                        Plc plc = PLCSingleton.CreatePLC(CpuType.S7300, eqp.IP, 0, 2);    //new Plc(CpuType.S7300, "10.21.189.139", 0, 2);

                        try
                        {
                            openstr = plc.QMOpen();
                            if (openstr == "OK")
                            {
                                
                                foreach (var V in list)
                                {
                                    eqp = (RowDataPoint)V;
                                    try
                                    {
                                        readobj = plc.QMRead((DataType)eqp.datatype, eqp.dbNumber, eqp.startByte, (VarType)eqp.vartype, 1);
                                        // str = (UInt32)plc.QMRead((DataType)eqp.datatype, eqp.dbNumber, eqp.startByte, (VarType)eqp.vartype, 1);
                                        if (readobj != null)
                                        {
                                            str = (UInt32)readobj;
                                             
                                            plchis =  FrontData.dic[eqp.TagID];
                                            
                                            plchis.Value = str;
                                            plchis.TagID = eqp.TagID;
                                            plchis.type = RowConfig.TagDic[plchis.TagID].type;
                                            
                                            plchis.refid=  DTKAG.KAGCreateNewDT(eqp.TagID,plchis.type, str);
                                            plchis.Time = DateTime.Now;

                                            if (eqp.TagID == EqpName.FillerStatusTagID)
                                            {
                                              plchis.formid=  PersisDTFiller.CL1NewDTFiller("", "", "",str);
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error(ex.ToString());
                                    }

                                }
                                plc.Close();
                            }
                            else
                            {
                                SetEQPRealDataMax(eqp.EQP);
                                Log.Error("[PLC][Link Fail] IP Address is : " + eqp.IP);
                                Log.Error(openstr);
                            }
                            //  throw new InvalidAddressException("To few periods for DB address");
                           
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public static void Run()
        {
            while (loop)
            {
                Log.Info("[GetPlc Data Thread][Loop]");
                Thread.Sleep(1000);
                try
                {
                    JobGetPLCData.GetDataFromPLC();
                }
                catch(Exception ex)
                {
                    Log.Error(ex.ToString());
                }
               
            }
           
        }


        public static void SetEQPRealDataMax(string eqpid)
        {
            try
            {
                if (string.IsNullOrEmpty(eqpid))
                {
                    return;
                }
                DataTable dt = DevicePoint.GetTagIDByEqp(eqpid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RealData.dic[dt.Rows[i]["TagID"].ToString()] = uint.MaxValue;
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
           
        }
    }
}
