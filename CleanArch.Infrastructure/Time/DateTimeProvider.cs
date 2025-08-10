
using CleanArch.Application.Common.Abstractions;

namespace CleanArch.Infrastructure.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}