using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ContactFormView : SmartBaseClass {
    public ContactFormView() : base("") { }
    public ContactFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string DisplayName { get; set; } = "";

    [RequiredIfNoContact(ErrorMessage = "At least one contact method is required")]
    public string Email { get; set; } = "";

    [RequiredIfNoContact(ErrorMessage = "At least one contact method is required")]
    public string Phone { get; set; } = "";
}

public class RequiredIfNoContact : ValidationAttribute {
    protected override ValidationResult? IsValid(
        object? value, 
        ValidationContext validationContext
    ) {
        var contactForm = validationContext.ObjectInstance as ContactFormView;
        if(
            !string.IsNullOrWhiteSpace(contactForm?.Email)
            && !string.IsNullOrWhiteSpace(contactForm?.Phone)
        ) {
            return ValidationResult.Success;
        }

        var memberNames = new List<string>();
        if(validationContext.MemberName == nameof(ContactFormView.Email)
            && string.IsNullOrWhiteSpace(contactForm?.Email)) {
            memberNames.Add(nameof(ContactFormView.Email));
        } else if(validationContext.MemberName == nameof(ContactFormView.Phone)
            && string.IsNullOrWhiteSpace(contactForm?.Phone)) {
            memberNames.Add(nameof(ContactFormView.Phone));
        }
        return new ValidationResult(ErrorMessage, memberNames);
    }
}