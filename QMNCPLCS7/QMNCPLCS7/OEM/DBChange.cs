using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using QMNetCoreFrame.Log;
using System.Threading;
using QMNCPLCS7;
using QMNetCoreFrame.TaskUtility;



namespace QMNCPLCS7.OEM
{
   public class DBChange
    {
        public static Dictionary<string, UInt16> RealData = new Dictionary<string, UInt16>();
        public static Dictionary<string, uint> LDData = new Dictionary<string, uint>();
        public static Dictionary<string, ArrayList> OEMPoint = new Dictionary<string, ArrayList>();

        public static Dictionary<string, RowDataPoint> DicStatus = new Dictionary<string, RowDataPoint>();

        public static Dictionary<string, uint> DicReal = new Dictionary<string, uint>();


        private static bool loop = true;

        private static string IP1 = "10.21.189.222";
        public static string Tailback1 = "601001";
        public static string Red1 = "601002";
        public static string Green1 = "601003";
        public static string Blue1= "601004";
        public static string Amber1 = "601005";

        private static string IP2 = "10.21.189.223";
        public static string Tailback2 = "602001";
        public static string Red2 = "602002";
        public static string Green2 = "602003";
        public static string Blue2 = "602004";
        public static string Amber2 = "602005";


       public static void SetOEM1EX()
        {
            RealData[Tailback1] = UInt16.MaxValue;
            RealData[Red1] = UInt16.MaxValue;
            RealData[Green1] = UInt16.MaxValue;
            RealData[Blue1] = UInt16.MaxValue;
            RealData[Amber1] = UInt16.MaxValue;
        }

        public static void SetOEM2EX()
        {
            RealData[Tailback2] = UInt16.MaxValue;
            RealData[Red2] = UInt16.MaxValue;
            RealData[Green2] = UInt16.MaxValue;
            RealData[Blue2] = UInt16.MaxValue;
            RealData[Amber2] = UInt16.MaxValue;
        }


        public static void Init()
        {
            RealData.Clear();
            LDData.Clear();
            OEMPoint.Clear();
            DicStatus.Clear();
            DicReal.Clear();


            DicReal.Add(IP1, uint.MaxValue);
            DicReal.Add(IP2, uint.MaxValue);

            RowDataPoint A = new RowDataPoint();
            A.IP = IP1;
            A.TagID = IP2;
            A.datatype = 132;
            A.dbNumber = 700;
            A.startByte = 4;
            A.bitNumber = -1;
            A.vartype = 3;

            DicStatus.Add(IP1, A);

            RowDataPoint B = new RowDataPoint();
            B.IP = IP2;
            B.TagID = IP2;
            B.datatype = 132;
            B.dbNumber = 700;
            B.startByte = 4;
            B.bitNumber = -1;
            B.vartype = 3;
            DicStatus.Add(IP2, B);





            LDData.Add(IP1, uint.MaxValue);
            LDData.Add(IP2, uint.MaxValue);

            RealData.Add(Tailback1, UInt16.MaxValue);
            RealData.Add(Red1, UInt16.MaxValue);
            RealData.Add(Green1, UInt16.MaxValue);
            RealData.Add(Blue1, UInt16.MaxValue);
            RealData.Add(Amber1, UInt16.MaxValue);


            RealData.Add(Tailback2, UInt16.MaxValue);
            RealData.Add(Red2, UInt16.MaxValue);
            RealData.Add(Green2, UInt16.MaxValue);
            RealData.Add(Blue2, UInt16.MaxValue);
            RealData.Add(Amber2, UInt16.MaxValue);


            ArrayList list1 = new ArrayList();
            RowDataPoint point = new RowDataPoint();
            point.IP = IP1 ;
            point.TagID = Tailback1 ;
            point.datatype = 131;
            point.dbNumber = 0;
            point.startByte = 200;
            point.bitNumber = 0;
            point.vartype = 1;
            list1.Add(point);

            RowDataPoint red1 = new RowDataPoint();
            red1.IP = IP1;
            red1.TagID = Red1;
            red1.datatype = 130;
            red1.dbNumber = 0;
            red1.startByte = 12;
            red1.bitNumber = 3;
            red1.vartype = 0;
            list1.Add(red1);


            RowDataPoint green1 = new RowDataPoint();
            green1.IP = IP1;
            green1.TagID = Green1;
            green1.datatype = 130;
            green1.dbNumber = 0;
            green1.startByte = 12;
            green1.bitNumber = 5;
            green1.vartype = 0;
            list1.Add(green1);

            RowDataPoint blue1 = new RowDataPoint();
            blue1.IP = IP1;
            blue1.TagID = Blue1;
            blue1.datatype = 130;
            blue1.dbNumber = 0;
            blue1.startByte = 12;
            blue1.bitNumber = 6;
            blue1.vartype = 0;
            list1.Add(blue1);

            RowDataPoint armber1 = new RowDataPoint();
            armber1.IP = IP1;
            armber1.TagID = Amber1;
            armber1.datatype = 130;
            armber1.dbNumber = 0;
            armber1.startByte = 12;
            armber1.bitNumber = 4;
            armber1.vartype = 0;
            list1.Add(armber1);



            ArrayList list2 = new ArrayList();
            RowDataPoint point2 = new RowDataPoint();
            point2.IP = IP2;
            point2.TagID = Tailback2;
            point2.datatype = 131;
            point2.dbNumber = 0;
            point2.startByte = 200;
            point2.bitNumber = 0;
            point2.vartype = 1;
            list2.Add(point2);

            RowDataPoint red2 = new RowDataPoint();
            red2.IP = IP2;
            red2.TagID = Red2;
            red2.datatype = 130;
            red2.dbNumber = 0;
            red2.startByte = 12;
            red2.bitNumber = 3;
            red2.vartype = 0;
            list2.Add(red2);


            RowDataPoint green2 = new RowDataPoint();
            green2.IP = IP2;
            green2.TagID = Green2;
            green2.datatype = 130;
            green2.dbNumber = 0;
            green2.startByte = 12;
            green2.bitNumber = 5;
            green2.vartype = 0;
            list2.Add(green2);

            RowDataPoint blue2 = new RowDataPoint();
            blue2.IP = IP2;
            blue2.TagID = Blue2;
            blue2.datatype = 130;
            blue2.dbNumber = 0;
            blue2.startByte = 12;
            blue2.bitNumber = 6;
            blue2.vartype = 0;
            list2.Add(blue2);

            RowDataPoint armber2 = new RowDataPoint();
            armber2.IP = IP2;
            armber2.TagID = Amber2;
            armber2.datatype = 130;
            armber2.dbNumber = 0;
            armber2.startByte = 12;
            armber2.bitNumber = 4;
            armber2.vartype = 0;
            list2.Add(armber2);

            OEMPoint.Add(IP1, list1);
            OEMPoint.Add(IP2, list2);
        }

        public static void Run()
        {
            

            FuncAsyn.RunP0(GetPLCDataLoop);
            Thread.Sleep(2000);
            FuncAsyn.RunP0(WritePLCLoop);
        }


        private static void WritePLCLoop()
        {
            while (loop)
            {
                try
                {
                   
                    WritePLC();
                }
                catch(Exception ex)
                {
                    Log.Error(ex.ToString());
                }

                Thread.Sleep(5000);

            }
        }
        private static void WritePLC()
        {
            if (DicReal[IP1] == uint.MaxValue)
            {
                
                WriteOEMPLC(IP1, "Down");
            }
            else
            {
               if(DicReal[IP1] == 512)
                {
                   
                   WriteOEMPLC(IP1, "Run");
                }
                else if(DicReal[IP1] == 256)
                {
                    WriteOEMPLC(IP1, "Idle");
                }
               else
                {
                    WriteOEMPLC(IP1, "Down");
                }
            }


            if (DicReal[IP2] == uint.MaxValue)
            {

                WriteOEMPLC(IP2, "Down");
            }
            else
            {
                if (DicReal[IP2] == 512)
                {

                    WriteOEMPLC(IP2, "Run");
                }
                else if (DicReal[IP2] == 256)
                {
                    WriteOEMPLC(IP2, "Idle");
                }
                else
                {
                    WriteOEMPLC(IP2, "Down");
                }
            }

        }


        private static void WriteOEMPLC(string IP,string status)
        {
            string openstr = "OK";
            uint code = 1;

            if (status == "Idle")
            {
                code = 32768;
            }
            else if (status == "Run")
            {
                code = 128;
            }
            else
            {
                code = 1;
            }
            try
            {
                Plc plc = OEMWritePLC.CreatePLC(CpuType.S7300, IP, 0, 2);

                try
                {
                  openstr=  plc.QMOpen();
                    if (openstr == "OK")
                    {
                        plc.Write(DataType.DataBlock, 700, 20, code, -1);
                        Log.Info("[DBChange][WriteOEMPLC] Success    "+IP+"  "+code);
                    }
                   else
                    {
                        Log.Error("[DBChange][WriteOEMPLC]IP :"+IP+openstr);
                    }

                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
                finally
                {
                    plc.Close();
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }


           

        }

        

       

        private static void GetPLCDataLoop()
        {
            while (loop)
            {
                try
                {
                    //GetPLCData();//

                    GetDicPLCData();
                }
                catch(Exception ex)
                {
                    Log.Error(ex.ToString());
                }
               

                Thread.Sleep(5000);
            }
        }


        private static void GetDicPLCData()
        {
            try
            {
                uint str;
                RowDataPoint point = null;
                string openstr = "OK";
                object readobj = null;
                RowDataPoint eqp = null;
                foreach (var adapter in DicStatus)
                {
                    point = adapter.Value;
                    if (point != null)
                    {

                        Plc plc = OEMPLC.CreatePLC(CpuType.S7300, adapter.Key, 0, 2);    //new Plc(CpuType.S7300, "10.21.189.139", 0, 2);

                        try
                        {
                            openstr = plc.QMOpen();
                            if (openstr == "OK")
                            { 
                                    try
                                    {
                                        readobj = plc.QMRead((DataType)point.datatype, point.dbNumber, point.startByte, (VarType)point.vartype, 1);
                                        // str = (UInt32)plc.QMRead((DataType)eqp.datatype, eqp.dbNumber, eqp.startByte, (VarType)eqp.vartype, 1);
                                        if (readobj != null)
                                        {
                                            str = Convert.ToUInt16(readobj);
                                        Console.WriteLine("OEM PLC Data " + adapter.Key + "  " + str);
                                        DicReal[adapter.Key] = str;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error(ex.ToString());
                                    }

                                

                            }
                            else
                            {
                                DicReal[adapter.Key] = uint.MaxValue;

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
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

        }

        private static void GetPLCData()
        {
            try
            {
                uint str ;
                ArrayList list = null;
                string openstr = "OK";
                object readobj = null;
                RowDataPoint eqp = null;
                foreach (var adapter in OEMPoint)
                {
                    list = adapter.Value;
                    if (list != null)
                    {
                        
                        Plc plc = OEMPLC.CreatePLC(CpuType.S7300, adapter.Key, 0, 2);    //new Plc(CpuType.S7300, "10.21.189.139", 0, 2);

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
                                            str = Convert.ToUInt16( readobj);
                                          

                                            Console.WriteLine(eqp.TagID + " OEM  Value is: " + str);
                                            Log.Info("[OEM]" + eqp.TagID+"  " + str);
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
                                if (adapter.Key == IP1)
                                {
                                    SetOEM1EX();
                                }
                                else
                                {
                                    SetOEM2EX();
                                }
                                
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
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

        }

    }
}
