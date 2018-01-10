using NRules.Fluent.Dsl;
using nRulesProcessor.Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRulesProcessor.Rules
{
    class MatchWinner : Rule
    {
        public override void Define()
        {
            Market market = null;
            Scoreboard scoreboard = null;
            When().Match<Scoreboard>(() => scoreboard, s => s.isMatchComplete);

            When().Match<Market>(() => market, m => m.Name.Equals("To Win") && !m.isMarkedUp);

            Then().Do(ctx => Markup(market, scoreboard))
                .Do(ctx => ctx.Update(market));
        }

        private static void Markup(Market market, Scoreboard scoreboard)
        {
            if(scoreboard.HomeScore > scoreboard.AwayScore)
            {
                market.Participants.SingleOrDefault(p => p.settlementCode == "Home").isWinner = true;
            }
            else
            {
                market.Participants.SingleOrDefault(p => p.settlementCode == "Away").isWinner = true;
            }
            market.Participants.ForEach(p => p.isMarkedUp = true);
            market.isMarkedUp = true;
        }
    }
}
