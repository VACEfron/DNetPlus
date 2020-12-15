using System;
using System.Collections.Generic;
using System.Globalization;

namespace Discord.Net
{
    internal struct RateLimitInfo
    {
        public bool IsGlobal { get; }
        public int? Limit { get; }
        public int? Remaining { get; }
        public int? RetryAfter { get; }
        public DateTimeOffset? Reset { get; }
        public TimeSpan? ResetAfter { get; }
        public string Bucket { get; }
        public TimeSpan? Lag { get; }

        internal RateLimitInfo(Dictionary<string, string> headers)
        {
            IsGlobal = headers.TryGetValue("X-RateLimit-Global", out string temp) &&
                       bool.TryParse(temp, out bool isGlobal) && isGlobal;
            Limit = headers.TryGetValue("X-RateLimit-Limit", out temp) && 
                int.TryParse(temp, NumberStyles.None, CultureInfo.InvariantCulture, out int limit) ? limit : (int?)null;
            Remaining = headers.TryGetValue("X-RateLimit-Remaining", out temp) && 
                int.TryParse(temp, NumberStyles.None, CultureInfo.InvariantCulture, out int remaining) ? remaining : (int?)null;
            Reset = headers.TryGetValue("X-RateLimit-Reset", out temp) && 
                double.TryParse(temp, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double reset) ? DateTimeOffset.FromUnixTimeMilliseconds((long)(reset * 1000)) : (DateTimeOffset?)null;
            RetryAfter = headers.TryGetValue("Retry-After", out temp) &&
                int.TryParse(temp, NumberStyles.None, CultureInfo.InvariantCulture, out int retryAfter) ? retryAfter : (int?)null;
			ResetAfter = headers.TryGetValue("X-RateLimit-Reset-After", out temp) &&
                double.TryParse(temp, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double resetAfter) ? TimeSpan.FromMilliseconds((long)(resetAfter * 1000)) : (TimeSpan?)null;
            Bucket = headers.TryGetValue("X-RateLimit-Bucket", out temp) ? temp : null;
            Lag = headers.TryGetValue("Date", out temp) &&
                DateTimeOffset.TryParse(temp, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset date) ? DateTimeOffset.UtcNow - date : (TimeSpan?)null;
        }
    }
}
