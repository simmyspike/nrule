using System.Reflection;
using NRules.Fluent;
using NRules.Samples.SimpleRules.Domain;
using System;

namespace NRules.Samples.SimpleRules
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            //Load domain model
            var ToWinMarket = new Market("ToWin");
            var Scoreboard = new Scoreboard();

            //Insert facts into rules engine's memory
            session.Insert(ToWinMarket);
            session.Insert(Scoreboard);

            //Start match/resolve/act cycle
            //session.Update(ToWinMarket);
            session.Fire();

            foreach (Participant part in ToWinMarket.Participants)
            {
                Console.WriteLine(part.Description + " - " + part.isWinner);
            }

            Console.ReadLine();
        }
    }
}