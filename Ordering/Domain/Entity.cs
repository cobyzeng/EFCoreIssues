namespace Ordering.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }


        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }

            return item.Id == Id;
        }

        private int? _hashCode;

        public override int GetHashCode()
        {
            if (IsTransient())
            {
                return base.GetHashCode();
            }

            if (!_hashCode.HasValue)
            {
                // XOR for random distribution
                // see (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                _hashCode = Id.GetHashCode() ^ 31;
            }

            return _hashCode.Value;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
