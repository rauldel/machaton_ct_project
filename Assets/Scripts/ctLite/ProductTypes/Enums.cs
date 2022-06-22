using System.Runtime.Serialization;

namespace ctLite.ProductTypes
{
    /// <summary>
    /// AttributeConstraint enum tells how an attribute or a set of attributes should be validated across all variants of a product.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-productTypes.html#attributeconstraint-enum"/>
    public enum AttributeConstraint
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Unique")]
        Unique,
        [EnumMember(Value = "CombinationUnique")]
        CombinationUnique,
        [EnumMember(Value = "SameForAll")]
        SameForAll
    }

    /// <summary>
    /// TextInputHint enumeration.
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-productTypes.html#textinputhint"/>
    public enum TextInputHint
    {
        [EnumMember(Value = "SingleLine")]
        SingleLine,
        [EnumMember(Value = "MultiLine")]
        MultiLine
    }
}
