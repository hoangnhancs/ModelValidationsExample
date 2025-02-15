using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ModelValidationsExample.CustomValidations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelValidationsExample.Models
{

    public class Person : IValidatableObject
    {
        //[FromQuery]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be beetween {2} and {1} characters long.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "{0} should contain only alphabets and space")]
        public string? PersonName { get; set; }

        //[FromRoute]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string? Email { get; set; }

        [Display(Name = "Phone number")]
        [Phone(ErrorMessage = "{0} is invalid")]
        //[ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string? Password { get; set; }

        [Display(Name = "Comfirm password")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} is not match")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} value: must in range {1} and {2}")]
        public double? Price { get; set; }

        [MinimumYearValidation(2000, ErrorMessage = "Year must be greater than {0}")]
        //[MinimumYearValidation(2005)]
        //[MinimumYearValidation]
        //[BindNever]
        public DateTime? DateofBirth { get; set; }

        [MinimumYearValidation(2000, ErrorMessage = "Year must be greater than {0}")]
        [DateRangeValidator("ToDate", ErrorMessage = "'From date': {0} should be smaller than or equal to 'To date': {1}")]

        public DateTime? FromDate { get; set; }

        //[DateRangeValidator("FromDate", ErrorMessage = "'From date': {0} should be smaller than or equal to 'To date': {1}")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<String?> Tags { get; set; } = new List<string?>();

        public override string ToString()
        {
            return $"Person Information - " +
                $"Person name: {PersonName}, " +
                $"Email: {Email}, " +
                $"Phone: {Phone}, " +
                $"Password: {Password}, " +
                $"Confirm Password: {ConfirmPassword}, " +
                $"Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if (!DateofBirth.HasValue && !Age.HasValue)
            {
                yield return new ValidationResult("Either of Date of Birth and Age must be supplied", new[] { nameof(DateofBirth) });
            }
        }
    }
}
