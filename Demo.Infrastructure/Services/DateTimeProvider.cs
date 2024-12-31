using Demo.Application.Common.Interfaces.Services;


//提供当前时间
namespace Demo.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
