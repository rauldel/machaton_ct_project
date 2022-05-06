using System;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using myCT.Channels;

namespace myCT.Common.Converters
{
    public class ChannelRoleConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ChannelRoleEnum messageTransportResponseStatus = (ChannelRoleEnum)value;

            switch(messageTransportResponseStatus) {
                case ChannelRoleEnum.InventorySupply:
                    writer.WriteValue("InventorySupply");
                    break;
                case ChannelRoleEnum.ProductDistribution:
                    writer.WriteValue("ProductDistribution");
                    break;
                case ChannelRoleEnum.OrderExport:
                    writer.WriteValue("OrderExport");
                    break;
                case ChannelRoleEnum.OrderImport:
                    writer.WriteValue("OrderImport");
                    break;
                case ChannelRoleEnum.Primary:
                    writer.WriteValue("Primary");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = ((string)reader.Value);
            // string actualValue = "";

            Debug.Log("CHANNEL ROLE VALUE -> " + reader.Value);
            //return Enum.Parse(typeof(ChannelRoleEnum), enumString, true);
            return ChannelRoleEnum.Primary;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}