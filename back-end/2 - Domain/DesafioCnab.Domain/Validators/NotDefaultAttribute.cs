using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DesafioCnab.Domain.Entities.Validators;

[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
[ExcludeFromCodeCoverage]
public class NotDefaultAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = "The {0} field must not have the default value";
    public NotDefaultAttribute() : base(DefaultErrorMessage) { }

    public override bool IsValid(object value)
    {
        //NotDefault doesn't necessarily mean required
        if (value is null)
        {
            return true;
        }

        var type = value.GetType();
        if (type.IsValueType)
        {
            var defaultValue = Activator.CreateInstance(type);
            return !value.Equals(defaultValue);
        }

        // non-null ref type
        return true;
    }
}