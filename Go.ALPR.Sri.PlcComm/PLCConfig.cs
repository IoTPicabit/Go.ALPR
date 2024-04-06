using System;
using System.Collections.Generic;
using System.Text;

namespace Go.ALPR.Sri.PlcComm
{
    public class PLCConfig
    {
        public const string plc = "plc";

        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int ProcessorSlot { get; set; }
        public string RoutePath { get; set; }
        public int CIPConnectionSize { get; set; }
        public bool DisableMultiServiceRequest { get; set; }
        public bool DisableSubscriptions { get; set; }
        public int PollRateOverride { get; set; }
        public int TimeOut { get; set; }
        public bool UseOmronRead { get; set; }
        public string TagConfirmacion { get; set; }
        public PLCCampoConfig[] Campos { get; set; }

    }
}
