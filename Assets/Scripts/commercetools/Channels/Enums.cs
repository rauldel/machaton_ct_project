using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace myCT.Channels
{
    /// <summary>
    /// ChannelRoleEnum enumeration.
    /// </summary>
    /// <see href="https://docs.commercetools.com/http-api-projects-channels.html#channelroleenum"/>

    public enum ChannelRoleEnum
    {
        [EnumMember(Value = "InventorySupply")]
        InventorySupply,
        [EnumMember(Value = "ProductDistribution")]
        ProductDistribution,
        [EnumMember(Value = "OrderExport")]
        OrderExport,
        [EnumMember(Value = "OrderImport")]
        OrderImport,
        [EnumMember(Value = "Primary")]
        Primary
    }
}
