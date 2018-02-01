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

            //Insert facts into rules engine's memory
            session.Insert(ToWinMarket);

            //Start match/resolve/act cycle
            //session.Update(ToWinMarket);
            session.Fire();

            Console.ReadLine();
        }
    }
}