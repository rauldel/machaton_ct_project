using System;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ctLite.ProductTypes;

namespace ctLite.Common.Converters {
    public class AttributeTypeConverter : JsonConverter
    {
        /// <summary>
        /// Cans the convert.
        /// </summary>
        /// <returns><c>true</c>, if convert was caned, <c>false</c> otherwise.</returns>
        /// <param name="objectType">Object type.</param>
		public override bool CanConvert(Type objectType)
		{
            return (objectType.BaseType == typeof(AttributeTypeConverter));
		}

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <returns>The json.</returns>
        /// <param name="reader">Reader.</param>
        /// <param name="objectType">Object type.</param>
        /// <param name="existingValue">Existing value.</param>
        /// <param name="serializer">Serializer.</param>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
            JObject jObject = JObject.Load(reader);

            switch ((string)jObject.GetValue("name"))
            {
                case "enum":
                    EnumType myType = new EnumType();
                    myType.Values = Helper.GetListFromJsonArray<PlainEnumValue>((JArray)jObject["values"]);
                    return myType;
                case "boolean":
                    BooleanType myBooleanType = new BooleanType();
                    return myBooleanType;
                case "text":
                    TextType myTextType = new TextType();
                    return myTextType;
                case "ltext":
                    LocalizableTextType myLocalizableTextType = new LocalizableTextType();
                    return myLocalizableTextType;
                case "lenum":
                    LocalizableEnumType myLocalizableEnumType = new LocalizableEnumType();
                    myLocalizableEnumType.Values = Helper.GetListFromJsonArray<LocalizedEnumValue>((JArray)jObject["values"]);
                    return myLocalizableEnumType;
                case "number":
                    NumberType myNumberType = new NumberType();
                    return myNumberType;
                case "money":
                    MoneyType myMoneyType = new MoneyType();
                    return myMoneyType;
                case "date":
                    DateType myDateType = new DateType();
                    return myDateType;
                case "time":
                    TimeType myTimeType = new TimeType();
                    return myTimeType;
                case "datetime":
                    DateTimeType myDateTimeType = new DateTimeType();
                    return myDateTimeType;
                case "reference":
                    ctLite.ProductTypes.ReferenceType myReferenceType = new ctLite.ProductTypes.ReferenceType();
                    Common.ReferenceType? referenceTypeId;
                    myReferenceType.ReferenceTypeId = Helper.TryGetEnumByEnumMemberAttribute<Common.ReferenceType?>((string)jObject["referenceTypeId"], out referenceTypeId) ? referenceTypeId : null;
                    return myReferenceType;
                case "set":
                    SetType mySetType = new SetType();
                    mySetType.ElementType = AttributeTypeFactory.Create(jObject["elementType"]);
                    return mySetType;
                case "nested":
                    NestedType myNestedType = new NestedType();
                    myNestedType.TypeReference = new Reference(jObject["typeReference"]);
                    return myNestedType;
                default:
                    return null;
            }

		}

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">Writer.</param>
        /// <param name="value">Value.</param>
        /// <param name="serializer">Serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
            if (value is EnumType)
            {
                EnumType myEnumType = (EnumType)value;
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "enum"));

                JArray valuesList = new JArray();
                JObject listElement;
                foreach (PlainEnumValue pev in myEnumType.Values)
                {
                    listElement = new JObject();
                    listElement.Add(new JProperty("key", pev.Key));
                    listElement.Add(new JProperty("label", pev.Label));
                    valuesList.Add(listElement);
                }
                jObject.Add(new JProperty("values", valuesList));

                jObject.WriteTo(writer);
            }
            else if (value is BooleanType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "boolean"));

                jObject.WriteTo(writer);
            }
            else if (value is TextType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "text"));

                jObject.WriteTo(writer);
            }
            else if (value is LocalizableTextType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "ltext"));

                jObject.WriteTo(writer);
            }
            else if (value is LocalizableEnumType)
            {
                LocalizableEnumType myLocalizableEnumType = (LocalizableEnumType)value;
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "lenum"));

                JArray valuesList = new JArray();
                JObject listElement;
                foreach (LocalizedEnumValue pev in myLocalizableEnumType.Values)
                {
                    listElement = new JObject();
                    listElement.Add(new JProperty("key", pev.Key));
                    listElement.Add(new JProperty("label", pev.Label));
                    valuesList.Add(listElement);
                }
                jObject.Add(new JProperty("values", valuesList));

                jObject.WriteTo(writer);
            }
            else if (value is NumberType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "number"));
                jObject.WriteTo(writer);
            }
            else if (value is MoneyType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "money"));
                jObject.WriteTo(writer);
            }
            else if (value is DateType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "date"));
                jObject.WriteTo(writer);
            }
            else if (value is TimeType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "time"));
                jObject.WriteTo(writer);
            }
            else if (value is DateTimeType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "datetime"));
                jObject.WriteTo(writer);
            }
            else if (value is ctLite.ProductTypes.ReferenceType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "reference"));
                ctLite.ProductTypes.ReferenceType myReferenceType = (ctLite.ProductTypes.ReferenceType)value;
                JObject referenceTypeId;
                if(myReferenceType.ReferenceTypeId != null)
                {
                    Debug.LogWarning("Gotta do something for parsing this correctly: " + myReferenceType.ReferenceTypeId);
                    /* referenceTypeId = new JObject(myReferenceType.ReferenceTypeId.ToJsonString());
                    jObject.Add("referenceTypeId", referenceTypeId); */
                }

                jObject.WriteTo(writer);
            }
            else if (value is SetType)
            {
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "set"));

                SetType mySetType = (SetType)value;
                jObject.Add(new JProperty("elementType", mySetType.ElementType.ToJsonString()));

                jObject.WriteTo(writer);
            }
            else if (value is NestedType)
            {
                //TODO: this is a Beta feature, not giving support by the moment (May 30th, 2019)
                JObject jObject = new JObject();
                jObject.Add(new JProperty("name", "nested"));
                jObject.WriteTo(writer);
            }
		}
	}
}
