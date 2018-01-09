namespace FC
{
    using static F;

    public static class Double
    {
        public static Option<double> Parse(string s) => double.TryParse(s, out var result) ? Some(result) : None;
    }
}