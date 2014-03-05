﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    class GameModeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var str = token.Value<string>();
            switch (str)
            {
                case "CLASSIC":
                    return GameMode.Classic;
                case "ODIN":
                    return GameMode.Dominion;
                case "ARAM":
                    return GameMode.Aram;
                case "TUTORIAL":
                    return GameMode.Tutorial;
                case "ONEFORALL":
                    return GameMode.OneForAll;
                case "FIRSTBLOOD":
                    return GameMode.FirstBlood;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = ((GameMode)value).ToString().ToUpper();
            serializer.Serialize(writer, result);
        }
    }
}
