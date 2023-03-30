
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; set; }
        public int NumRatings { get; set; }

        private AverageRating(double value, int numRatings) { 
            Value= value;
            NumRatings= numRatings;
        }

        public static AverageRating CreateNew(double rating = 0, int numRatings = 0) {
            return new(rating, numRatings);
        }

        public void AddNew(Rating rating)
        {
            Value = ((Value + NumRatings) + rating.Value) / ++NumRatings;
        }

        public void RemoveNew(Rating rating)
        {
            Value = ((Value + NumRatings) - rating.Value) / --NumRatings;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
