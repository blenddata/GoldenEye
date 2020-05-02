using System;

namespace GoldenEye.Backend.Core.Exceptions
{
    public class OptimisticConcurrencyException: Exception
    {
        public Type Type { get; }
        public object Id { get; }
        public object Version { get; }

        private OptimisticConcurrencyException(Type type, object id, object version): base(
            $"Cannot modify {type.Name} with id: {id}. Version `{version}` did not match.")
        {
            Type = type;
            Id = id;
            Version = version;
        }

        public static OptimisticConcurrencyException For(Type type, object id, object version) => new OptimisticConcurrencyException(type, id, version);

        public static OptimisticConcurrencyException For<T>(object id, object version) => For(typeof(T), id, version);
    }
}
