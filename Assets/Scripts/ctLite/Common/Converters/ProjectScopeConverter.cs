using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using UnityEngine;

namespace ctLite.Common.Converters
{
    /// <summary>
    /// Custom converter for the LocalizedString class.
    /// </summary>
    public class ProjectScopeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ProjectScope messageTransportResponseStatus = (ProjectScope)value;

            switch (messageTransportResponseStatus)
            {
                case ProjectScope.ManageProject:
                    writer.WriteValue("manage_project");
                    break;
                case ProjectScope.ManageProducts:
                    writer.WriteValue("manage_products");
                    break;
                case ProjectScope.ViewProducts:
                    writer.WriteValue("view_products");
                    break;
                case ProjectScope.ManageOrders:
                    writer.WriteValue("manage_orders");
                    break;
                case ProjectScope.ViewOrders:
                    writer.WriteValue("view_orders");
                    break;
                case ProjectScope.ManageCustomers:
                    writer.WriteValue("manage_customers");
                    break;
                case ProjectScope.ViewCustomers:
                    writer.WriteValue("view_customers");
                    break;
                case ProjectScope.ManageProfile:
                    writer.WriteValue("manage_my_profile");
                    break;
                case ProjectScope.ManageTypes:
                    writer.WriteValue("manage_types");
                    break;
                case ProjectScope.ViewTypes:
                    writer.WriteValue("view_types");
                    break;
                case ProjectScope.ManagePayments:
                    writer.WriteValue("manage_payments");
                    break;
                case ProjectScope.ViewPayments:
                    writer.WriteValue("view_payments");
                    break;
                case ProjectScope.CreateAnonymousToken:
                    writer.WriteValue("create_anonymous_token");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = ((string)reader.Value).Split(':')[0];
            string actualName = "";

            switch(enumString)
            {
                case "manage_project":
                    actualName = "ManageProject";
                    break;
                case "manage_products":
                    actualName = "ManageProducts";
                    break;
                case "view_products":
                    actualName = "ViewProducts";
                    break;
                case "manage_orders":
                    actualName = "ManageOrders";
                    break;
                case "view_orders":
                    actualName = "ViewOrders";
                    break;
                case "manage_customers":
                    actualName = "ManageCustomers";
                    break;
                case "view_customers":
                    actualName = "ViewCustomers";
                    break;
                case "manage_my_profile":
                    actualName = "ManageProfile";
                    break;
                case "manage_types":
                    actualName = "ManageTypes";
                    break;
                case "view_types":
                    actualName = "ViewTypes";
                    break;
                case "manage_payments":
                    actualName = "ManagePayments";
                    break;
                case "view_payments":
                    actualName = "ViewPayments";
                    break;
                case "create_anonymous_token":
                    actualName = "CreateAnonymousToken";
                    break;

            }

            return Enum.Parse(typeof(ProjectScope), actualName, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
