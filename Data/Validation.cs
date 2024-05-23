using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class RequiredIfAttribute : ValidationAttribute {
    private readonly string _propertyName;
    private readonly object _expectedValue;

    public RequiredIfAttribute(string propertyName, object expectedValue) {
        _propertyName = propertyName;
        _expectedValue = expectedValue;
    }

    protected override ValidationResult? IsValid(
        object? value, 
        ValidationContext validationContext
    ) {
        var instance = validationContext.ObjectInstance;
        var type = instance.GetType();
        var propertyValue = type?.GetProperty(_propertyName)?.GetValue(instance, null);

        if (propertyValue?.ToString() != _expectedValue.ToString()) {
            return ValidationResult.Success;
        }

        if(value == null || String.IsNullOrEmpty(value.ToString())) {
            var memberNames = new List<string>();
            if (validationContext.MemberName != null) {
                memberNames.Add(validationContext.MemberName);
            } else {
                Console.WriteLine("ValidationContext.MemberName is null");
            }
            return new ValidationResult(ErrorMessage, memberNames);
        }
        return ValidationResult.Success;
    }
}