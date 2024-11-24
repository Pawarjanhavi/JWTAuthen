using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo
{
    public class ATMCashWithDrawal
    {
        private readonly IHSMModule hsmModule;
        private readonly IHostBank hostBank;

        public ATMCashWithDrawal(IHSMModule hsmModule, IHostBank hostBank)
        {
            this.hsmModule = hsmModule;
            this.hostBank = hostBank;
        }

        public bool WithdrawAmount(string CardNumber, int PIN, int Amount)
        {
            if(!hsmModule.ValidatePIN(CardNumber,PIN))
            {
                return false;
            }
            if(!hostBank.Authenticate(CardNumber,Amount))
            {
                return false;
            }

            return true;
        }

    }
}
