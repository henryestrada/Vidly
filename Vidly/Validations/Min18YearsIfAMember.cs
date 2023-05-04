using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Validations;

public class Min18YearsIfAMember : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        dynamic customer = validationContext.ObjectInstance;

        if (customer.MembershipTypeId == null || customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            return ValidationResult.Success;

        if (customer.Birthdate == null)
            return new ValidationResult("Birthdate is required.");

        var age = DateTime.Today.Year - customer.Birthdate.Year;

        return age >= 18
            ? ValidationResult.Success
            : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
    }
}
