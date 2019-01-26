using System;
using System.Collections.Generic;
using System.Text;

namespace QMNCPLCS7.Status
{
   public class CL1OEMStatus
    {

        public static KMStatus GetStatus(uint real)
        {
            KMStatus data = new KMStatus();
            switch (real)
            {
                case 1:
                    data.ISDown = true;
                    data.Status = "";
                    return data;

                case 128:
                    data.ISDown = true;
                    data.Status = "Stopped";
                    return data;
                case 512:
                    data.ISDown = false;
                    data.Status = "Operation";
                    return data;

                default:
                    data.ISDown = true;
                    data.Status = "UnKonw";
                    return data;
                
            }
        }
    }
}
