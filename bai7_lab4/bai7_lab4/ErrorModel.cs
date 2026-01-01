using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai7_lab4
{
    public class ErrorModel
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class ApiErrorDetail
    {
        [JsonProperty("msg")]
        public string JsonMessage { get; set; }

        [JsonProperty("detail")]
        public string JsonDetail { get; set; }

        [JsonProperty("loc")]
        public List<string> Location { get; set; }

        [JsonProperty("type")]
        public string ErrorType { get; set; }

        public string GetDisplayMessage()
        {
            string baseMessage = !string.IsNullOrEmpty(JsonMessage) ? JsonMessage : JsonDetail;

            if (string.IsNullOrEmpty(baseMessage))
            {
                return "Lỗi chi tiết không xác định.";
            }

            if (Location != null && Location.Count >= 2)
            {
                string fieldName = Location.LastOrDefault();
                return $"{baseMessage} (Trường: {fieldName})";
            }

            return baseMessage;
        }
    }
}
