using System.Collections.Generic;

namespace Infrastructure.Services.Analytics
{
    public interface IAnalyticEvent
    {
        string GetKey();
        Dictionary<string, object> GetParameters();
        Dictionary<string, string> GetStringParameters();
        bool IsHaveParameters { get; }
    }
}
