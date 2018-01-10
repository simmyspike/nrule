using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRulesProcessor.Business_Objects
{
    class Participant
    {
        public string settlementCode { get; set; }
        public bool isWinner { get; set; }
        public bool isMarkedUp { get; set; }
    }
}
