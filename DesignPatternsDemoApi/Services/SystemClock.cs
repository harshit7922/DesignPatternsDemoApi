using DesignPatternsDemoApi.Interfaces;

namespace DesignPatternsDemoApi.Services;

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
