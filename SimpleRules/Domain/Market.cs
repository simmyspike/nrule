namespace NRules.Samples.SimpleRules.Domain
{
    public class Market
    {
        public string Name { get; private set; }

        public Market(string name)
        {
            Name = name;
        }
    }
}