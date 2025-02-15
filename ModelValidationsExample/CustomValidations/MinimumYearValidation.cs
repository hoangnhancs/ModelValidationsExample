using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidations
{
    public class MinimumYearValidation : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000; //default 2000
        public string DefaultErrMessage { get; set; } = "Year must be greater than {0}";
        //parameterless contructor
        public MinimumYearValidation()
        {

        }
        //parameterized constructor
        public MinimumYearValidation(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            if (value != null)
            {
                DateTime date = Convert.ToDateTime(value);
                if (date.Year < MinimumYear)
                {
                    //return new ValidationResult("Minimum year allowed is 2000");
                    //return new ValidationResult(ErrorMessage); //if ErrMess null -> err, must use below return
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrMessage, MinimumYear)); //if u use this case, u can define error messsage in clas person
                    //use string format because this is CUSTOM validation, if not format, system don't know dynamic input variable
                    //if u use system validation, it has format. U don't need to farmat string
                    //if Errmess == null, return defaultmess
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
