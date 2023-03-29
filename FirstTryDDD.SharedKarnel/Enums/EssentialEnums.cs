using System.Text.Json.Serialization;

namespace FirstTryDDD.SharedKarnel.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResponseResult { None, Success, Exception, Error }
}
