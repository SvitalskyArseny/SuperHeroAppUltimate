using System.Text.Json.Serialization;

namespace SuperHeroProject.infrastructure.model
{
    public record AppearanceResponse
    {
        [JsonPropertyName("gender")] public string Gender { get; init; }
        [JsonPropertyName("race")] public string Race { get; init; }
        [JsonPropertyName("eyeColor")] public string EyeColor { get; init; }
        [JsonPropertyName("hairColor")] public string HairColor { get; init; }
        [JsonPropertyName("height")] public string[] Height { get; init; }
        [JsonPropertyName("weight")] public string[] Weight { get; init; }
    }
}