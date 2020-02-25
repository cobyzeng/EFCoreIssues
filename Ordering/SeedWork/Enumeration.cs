using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ordering.SeedWork
{
    public abstract class Enumeration : IComparable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected Enumeration()
        {
        }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;
            var fields = typeof(T).GetFields(flags);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;
            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
