﻿using Newtonsoft.Json;
using System;

namespace Discord.Net.Converters
{
    public class PermissionTargetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(PermissionTarget);
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "member":
                    return PermissionTarget.User;
                case "role":
                    return PermissionTarget.Role;
                default:
                    throw new JsonSerializationException("Unknown permission target");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((PermissionTarget)value)
            {
                case PermissionTarget.User:
                    writer.WriteValue("member");
                    break;
                case PermissionTarget.Role:
                    writer.WriteValue("role");
                    break;
                default:
                    throw new JsonSerializationException("Invalid permission target");
            }
        }
    }
}