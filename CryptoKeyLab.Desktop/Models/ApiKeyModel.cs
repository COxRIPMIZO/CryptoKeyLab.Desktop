using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoKeyLab.Desktop.Models
{
    public class ApiKeyModel
    {
        public string ApiKey { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public int UsageCount { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public int RateLimitPerMinute { get; set; } = 0;
    };
}
