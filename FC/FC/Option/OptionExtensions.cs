namespace FC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Unit = System.ValueTuple;
    using static F;

    public static class OptionExtensions
    {
        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> f)
          => optT.Match(
             None: () => None,
             Some: f);

        public static IEnumerable<R> Bind<T, R>(this Option<T> @this, Func<T, IEnumerable<R>> func)
          => @this.AsEnumerable().SelectMany(func);

        public static Option<Unit> ForEach<T>(this Option<T> @this, Action<T> action)
           => Map(@this, action.ToFunc());

        public static Option<R> Map<T, R>(this Option.None _, Func<T, R> f) => None;

        public static Option<R> Map<T, R>(this Option.Some<T> some, Func<T, R> f) => Some(f(some.Value));

        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> f)
         => optT.Match(
            () => None,
            (t) => Some(f(t)));

        public static Unit Match<T>(this Option<T> @this, Action None, Action<T> Some)
          => @this.Match(None.ToFunc(), Some.ToFunc());

        public static T GetOrElse<T>(this Option<T> opt, T defaultValue)
         => opt.Match(
            () => defaultValue,
            (t) => t);

        public static T GetOrElse<T>(this Option<T> opt, Func<T> fallback)
         => opt.Match(
            fallback,
            (t) => t);

        public static Option<T> OrElse<T>(this Option<T> left, Option<T> right)
         => left.Match(
            () => right,
            (_) => left);

        public static Option<T> OrElse<T>(this Option<T> left, Func<Option<T>> right)
         => left.Match(
            right,
            (_) => left);

        public static Option<R> Select<T, R>(this Option<T> @this, Func<T, R> func)
        => @this.Map(func);

        public static Option<T> Where<T>(this Option<T> optT, Func<T, bool> predicate)
         => optT.Match(
            () => None,
            (t) => predicate(t) ? optT : None);

        public static Option<RR> SelectMany<T, R, RR>(this Option<T> opt, Func<T, Option<R>> bind, Func<T, R, RR> project)
           => opt.Match(
              () => default,
              (t) => bind(t).Match(
                 () => default,
                 (r) => Some(project(t, r))));
    }
}
