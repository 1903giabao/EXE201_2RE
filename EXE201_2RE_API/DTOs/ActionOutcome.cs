using System.Text.Json.Serialization;

namespace EXE201_2RE_API.DTOs
{
    public class ActionOutcome
    {
        [JsonPropertyName("Result")]
        public object? Result { get; set; }
        [JsonPropertyName("IsSuccess")]
        public bool IsSuccess { get; set; } = true;
        [JsonPropertyName("Message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("Value")]
        public string Value { get; set; } = string.Empty;
    }
}
