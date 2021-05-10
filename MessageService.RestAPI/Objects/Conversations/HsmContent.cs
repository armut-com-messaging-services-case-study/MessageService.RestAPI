using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessageService.RestAPI.Objects.Conversations
{
    public enum HsmLanguagePolicy
    {
        [EnumMember(Value = "deterministic")]
        Deterministic,
        [EnumMember(Value = "fallback")]
        Fallback,
    }
    public class HsmLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("policy"), JsonConverter(typeof(StringEnumConverter))]
        public HsmLanguagePolicy Policy { get; set; }
    }

    public class HsmLocalizableParameter
    {
        [JsonProperty("default")]
        public string Default { get; set; }

        [JsonProperty("currency")]
        public HsmLocalizableParameterCurrency Currency { get; set; }

        [JsonProperty("dateTime")]
        public DateTime? DateTime { get; set; }
    }

    public class HsmLocalizableParameterCurrency
    {
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }

    public class HsmContent
    {
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("templateName")]
        public string TemplateName { get; set; }

        [JsonProperty("language")]
        public HsmLanguage Language { get; set; }

        [JsonProperty("params")]
        public List<HsmLocalizableParameter> Params { get; set; }
    }
}