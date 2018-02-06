using System.Collections.Generic;

namespace NRules.Samples.SimpleRules.Domain
{
    public class Market
    {
        public string Name { get; private set; }

        public List<Participant> Participants { get; private set; } = new List<Participant>();

        public Market(string name)
        {
            Name = name;
            Participants.Add(new Participant() { Description = "Team 1" });
            Participants.Add(new Participant() { Description = "Team 2" });
        }
    }
}