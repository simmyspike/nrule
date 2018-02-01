using System;
using System.Collections.Generic;
using System.Linq;
using NRules.Fluent.Dsl;
using NRules.Samples.SimpleRules.Domain;

namespace NRules.Samples.SimpleRules.Rules
{
    [Name("Preferred customer discount")]
    public class ToWin : Rule
    {
        public override void Define()
        {
            Market market = null;

            When()
                .Match<Market>(() => market, market.Name == "ToWin");

            Then()
                .Do(ctx => Console.WriteLine("hit"));
        }
    }
}