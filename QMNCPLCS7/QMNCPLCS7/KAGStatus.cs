using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;
using System.Collections;
using QMNCPLCS7.Entities;
using System.Data;
using System.Threading;
using QMNetCoreFrame.Log;

namespace QMNCPLCS7
{
    public class KMStatus
    {
        public bool ISDown { set; get; }
        public string Status { set; get; }
        public string Reason { set; get; }

       public KMStatus()
        {
            ISDown = true;
            Reason = "Normal";
        }
    }
    public class KAGStatus
    {

        public static KMStatus GetStatus(uint value)
        {
            KMStatus status = new KMStatus();
             
            switch (value)
            {
                case 1:  //Stopped 
                    status.Status = "Stopped";
                    return  status;


                case 2://Starting
                    status.Status = "Starting";
                    return  status;



                case 4:  //Prepared
                    status.Status = "Prepared";
                    return status;

                case 8:   //Lack
                    status.Status = "Lack";
                    status.Reason = "Abnormal";
                    return status;

                case 16:  //Tailback
                    status.Status = "Tailback";
                    status.Reason = "Abnormal";
                    return status;


                case 32:  //Lack Branch Line
                    status.Status = "Lack_Branch";
                    status.Reason = "Abnormal";
                    return status;


                case 64:  //Tailback Branch Line
                    status.Status = "Tailback";
                    status.Reason = "Abnormal";
                    return status;


                case 128:  //Operating
                    status.Status = "Operating";
                    status.ISDown = false;
                    return status;


                case 256:  //Stopping
                    status.Status = "Stopping";
                    return status;


                case 512:  //Aborting
                    status.Status = "Aborting";
                    status.Reason = "Abnormal";
                    return status;

                case 1024:  //Equipment Failure
                    status.Status = "Equipment_Failure";
                    status.Reason = "Abnormal";
                    return status;


                case 2048:  //External Failure
                    status.Status = "External_Failure";
                    status.Reason = "Abnormal";
                    return status;



                case 4096:  //Emergency Stop
                    status.Status = "Emergency_Stop";
                    status.Reason = "Abnormal";
                    return status;


                case 8192:  //Holding
                    status.Status = "Holding";
                    status.Reason = "Abnormal";
                    return status;


                case 16384:  //Held
                    status.Status = "Held";
                    status.Reason = "Abnormal";
                    return status;

                case 32768:  //Idle
                    status.Status = "Idle";
                    status.Reason = "Abnormal";
                    return status;

                default:
                    status.Status = "UnKonwn";
                    status.Reason = "Abnormal";
                    return status;
            }

        }



        public static KMStatus GetMode(uint value)
        {
            KMStatus mode = new KMStatus();
            mode.ISDown = false;
            switch (value)
            {
                case 1:
                    mode.Status = "Off";
                    return mode;
                case 2:
                    mode.Status = "Manual";
                    return mode;
                case 4:
                    mode.Status = "SemiAuto";
                    return mode;
                case 8:
                    mode.Status = "Auto";
                    return mode;
                default:
                    mode.Status = "UnKonwn";
                    return mode;
            }
        }


        public static KMStatus GetProgram(uint value)
        {
            KMStatus program = new KMStatus();
            program.ISDown = false;
            switch (value)
            {
                case 1:
                    program.Status = "Production";
                    return program;
                case 2:
                    program.Status = "StartUp";
                    return program;
                case 4:
                    program.Status = "RunDown";
                    return program;
                case 8:
                    program.Status = "Clean";
                    return program;

                case 16:
                    program.Status = "Changeover";
                    return program;
                case 32:
                    program.Status = "Maintenance";
                    return program;
                case 64:
                    program.Status = "Break";
                    return program;

                default:
                    program.Status = "UnKonwn";
                    return program;
            }
        }


        public static string CheckStatus(uint value)
        {
            if (value == 16)
            {
                return "Tailback";

            }
            else if(value==8)
            {
                return "Lack";
            }
            else if (value == 128)
            {
                return "Operating";

            }
            else
            {
                return "Down";
            }
        }

        public enum Status{
            Stopped =1,
            Starting=2,
            Prepared=4,
            Lack=8,
            Tailback=16,
            Lack_Branch_Line=32,
            Tailback_Branch_Line=64,
            Operating=128,
            Stopping=256,
            Aborting=512,
            Equipment_Failure=1024,
            External_Failure=2048,
            Emergency_Stop=4096,
            Holding=8192,
            Held=16384,
            Idle=32768
        }

        

    }
}
