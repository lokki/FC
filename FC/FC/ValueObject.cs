namespace FC
{
    public abstract class ValueObject<T> : System.IEquatable<T>
        where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if (other is null)
                return false;

            return EqualsCore(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            if (obj is T t)
                return EqualsCore(t);

            return false;
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
