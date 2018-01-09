namespace FC
{
    using System;
    using static F;

    public static class Date
    {
        public static Option<DateTime> Parse(string s) => DateTime.TryParse(s, out var d) ? Some(d) : None;

        public static Option<DateTimeOffset> ParseOffset(string s) => DateTimeOffset.TryParse(s, out var d) ? Some(d) : None;
    }
}