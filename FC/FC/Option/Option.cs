namespace FC
{
    using System;
    using System.Collections.Generic;
    using Unit = System.ValueTuple;
    using static F;

    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);
        public static Option.None None => Option.None.Default;
    }

    public readonly struct Option<T> : IEquatable<Option.None>, IEquatable<Option<T>>
    {
        private T Value { get; }
        private bool IsSome { get; }
        private bool IsNone => !IsSome;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            IsSome = true;
            Value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value)
            => value == null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some) => IsSome ? Some(Value) : None();
        public Unit Match(Action None, Action<T> Some) => Match(None.ToFunc(), Some.ToFunc());

        public IEnumerable<T> AsEnumerable()
        {
            if (IsSome)
                yield return Value;
        }

        public override int GetHashCode() => IsSome ? Value.GetHashCode() : 0;

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Option<T> option))
                return false;

            return Equals(option);
        }

        public bool Equals(Option.None _) => IsNone;
        public bool Equals(Option<T> other)
        {
            return (IsSome && other.IsSome && Value.Equals(other.Value))
                || (IsNone && other.IsNone);
        }

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        public override string ToString() => IsSome ? $"Some({Value})" : "None";
    }

    public static class Option
    {
        public readonly struct None
        {
            internal static readonly None Default = new None();
        }

        public readonly struct Some<T>
        {
            internal T Value { get; }
            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException();

                Value = value;
            }
        }
    }
}
