using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidations
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        string OtherPropertyName { get; set; }
        //public DateRangeValidatorAttribute() { }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName; 
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);

            if (value != null)
            {
                DateTime from_date = (DateTime)value;

                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherProperty != null)
                {
                    DateTime to_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                    //validationContext.ObjectInstance bao gom cac thuoc tinh ma minh da khai bao, nhu email, price,...
                    if (to_date < from_date)
                    {
                        return new ValidationResult(String.Format(ErrorMessage, from_date, to_date), new[] {validationContext.MemberName});
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;   
            }
            return null;
        }
    }
}
