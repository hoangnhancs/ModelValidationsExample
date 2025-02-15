using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.Models;
using ModelValidationsExample.CustomModelBinders;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        
        [Route("register/")]
        //[Bind(nameof(Person.PersonName), nameof(Person.Email),nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string? UserAgent) //binding truoc, validation sau
        {
            if(!ModelState.IsValid)
            {
                //List<String> errors = new List<String>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach(var error in value.Errors)
                //    {
                //        errors.Add(error.ErrorMessage);
                //    }
                //}
                //String.Join(", ", errors);

                List<String> errors = ModelState.Values.SelectMany(value => value.Errors).
                    Select(err => err.ErrorMessage).ToList();
                //List<ModelErrorCollection> t = ModelState.Values.Select(x => x.Errors).ToList();

                return BadRequest($"Validation fail!!! {String.Join(", ", errors)}");
            }
            return Content($"{person}, {UserAgent}");
        }
    }
}
