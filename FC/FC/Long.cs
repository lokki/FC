namespace FC
{
    using static F;

    public static class Long
    {
        public static Option<long> Parse(string s) => long.TryParse(s, out var result) ? Some(result) : None;
    }
}