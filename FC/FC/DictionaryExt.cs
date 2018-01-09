namespace FC
{
    using System.Collections.Generic;
    using static F;

    public static class DictionaryExt
    {
        public static Option<V> Lookup<K, V>(this IDictionary<K, V> dict, K key) => dict.TryGetValue(key, out var value) ? Some(value) : None;
    }
}