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




namespace QMNCPLCS7.TraceDT
{
   public class TraceDownEqp
    {
        private static bool loop = true;

        public static void Run(string fromid)
        {
            loop = true;
            while (loop)
            {
                if (TraceCL1.IsQuit())  //确保前一个 DT结束 ，在执行新的DT计算
                {
                    loop = false;
                    TraceCL1.Run(fromid);
                }
                Thread.Sleep(1000);
            }

            
             
              
            
        }
    }
}
