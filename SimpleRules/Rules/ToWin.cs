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
            Scoreboard scoreboard = null;

            When()
                .Match<Market>(() => market, a => market.Name == "ToWin")
                .Match<Scoreboard>(() => scoreboard);

            Then()
                .Do(ctx => MarkUp(market, scoreboard));
        }

        private void MarkUp(Market market, Scoreboard scoreboard)
        {
            if(scoreboard.team1score > scoreboard.team2score)
            {
                market.Participants.Where(x => x.Description.Contains("Team 1")).All(x => x.isWinner = true);
            }
            else
            {
                market.Participants.Where(x => x.Description.Contains("Team 2")).All(x => x.isWinner = true);
            }
        }
    }
}