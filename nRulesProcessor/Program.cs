using NRules;
using NRules.Diagnostics;
using NRules.Fluent;
using nRulesProcessor.Business_Objects;
using nRulesProcessor.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nRulesProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();
            session.Events.RuleFiringEvent += OnRuleFiringEvent;

            Participant HomeParticipant = new Participant() { settlementCode = "Home" };
            Participant AwayParticipant = new Participant() { settlementCode = "Away" };
            var market = new Market() { Name = "To Win", Participants = new List<Participant>() { HomeParticipant, AwayParticipant } };
            var scoreboard = new Scoreboard { AwayScore = 20, HomeScore = 10, isMatchComplete = true };

            session.Insert(market);
            session.Insert(scoreboard);
            session.Insert(HomeParticipant);
            session.Insert(AwayParticipant);

            session.Update(market);
            session.Fire();

            Console.ReadLine();
        }

        private static void OnRuleFiringEvent(object sender, AgendaEventArgs e)
        {
            Console.WriteLine("Rule about to fire {0}", e.Rule.Name);
        }
    }
}
