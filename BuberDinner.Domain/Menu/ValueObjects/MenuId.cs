using BuberDinner.Domain.Common.Models;
using System.Security.Cryptography.X509Certificates;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }
        private MenuId(Guid value) {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
