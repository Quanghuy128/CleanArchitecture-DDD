using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastucture.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;  
    }
}
