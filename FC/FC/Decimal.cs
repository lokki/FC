namespace FC
{
    using static F;

    public static class Decimal
    {
        public static Option<decimal> Parse(string s) => decimal.TryParse(s, out var result) ? Some(result) : None;
    }
}