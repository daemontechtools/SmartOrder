using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ContactFormView : SMARTBaseClassView {
    public ContactFormView(string LinkID) : base(LinkID) {}

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
            !string.IsNullOrEmpty(contactForm?.Email)
            && !string.IsNullOrEmpty(contactForm?.Phone)
        ) {
            return ValidationResult.Success;
        }

        var memberNames = new List<string>();
        if(validationContext.MemberName == nameof(ContactFormView.Email)
            && string.IsNullOrEmpty(contactForm?.Email)) {
            memberNames.Add(nameof(ContactFormView.Email));
        } else if(validationContext.MemberName == nameof(ContactFormView.Phone)
            && string.IsNullOrEmpty(contactForm?.Phone)) {
            memberNames.Add(nameof(ContactFormView.Phone));
        }
        return new ValidationResult(ErrorMessage, memberNames);
    }
}