using System;
using System.Collections.Generic;
using System.Text;
using QMNetCoreFrame.Log;

namespace QMNCPLCS7
{
   public class DTStatusChange
    {
      public static void  ChangeStatus(string tagid, uint real, uint front)
        {
           
            switch (tagid)
            {
                case "101001":  //听线酒机状态

                  //  DTCL1.DTFiller(tagid, real, front);

                    break;
                case "101002":  //听线酒机模式

                    break;

                case "101003":  //听线酒机程序

                    break;
                default:
                    break;
            }
        }






    }
}
