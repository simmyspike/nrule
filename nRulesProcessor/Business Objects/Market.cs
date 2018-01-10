using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRulesProcessor.Business_Objects
{
    class Market
    {
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
        public bool isMarkedUp { get; set; }
    }
}
