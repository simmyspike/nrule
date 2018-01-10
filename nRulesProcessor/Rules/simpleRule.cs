using NRules.Fluent.Dsl;
using nRulesProcessor.Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRulesProcessor.Rules
{
    class SimpleRule : Rule
    {
        private Market market = null;

        public override void Define()
        {
            When().Match<Market>(() => market);
        }
    }
}
