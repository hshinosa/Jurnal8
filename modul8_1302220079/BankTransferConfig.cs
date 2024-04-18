using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_1302220079
{
    class BankTransferConfig
    {
        public string lang { get; set; }
        public TransferConfig transfer { get; set; }
        public List<string> methods { get; set; }
        public ConfirmationConfig confirmation { get; set; }

        public BankTransferConfig() { }

        public BankTransferConfig(string lang, TransferConfig transfer, List<string> methods, ConfirmationConfig confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }
    class TransferConfig
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public TransferConfig(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }
    class ConfirmationConfig
    {
        public string en { get; set; }
        public string id { get; set; }
        
        public ConfirmationConfig(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}
