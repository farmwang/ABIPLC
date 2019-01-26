using System;
using System.Collections.Generic;
using System.Text;
using QMNetCorePLCS7;

namespace QMNCPLCS7
{
    class PLCComm
    {
    }

    public class PLCSingleton
    {
        private static Plc plc = null;
        private static object singlock = new object();

        public static Plc CreatePLC(CpuType cpu,string ip,short rack,short slot)
        {
            if (plc == null)
            {
                lock (singlock)
                {
                    if (plc == null)
                    {
                        plc = new Plc(cpu, ip, rack, slot);
                    }
                }
            }
            plc.SetCPU(cpu);
            plc.SetIP(ip);
            plc.SetRack(rack);
            plc.SetSlot(slot);
            return plc;
        }
    }
}
