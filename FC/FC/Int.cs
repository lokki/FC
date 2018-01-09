namespace FC
{
    using static F;

    public static class Int
    {
        public static Option<int> Parse(string s) => int.TryParse(s, out var result) ? Some(result) : None;
    }
}