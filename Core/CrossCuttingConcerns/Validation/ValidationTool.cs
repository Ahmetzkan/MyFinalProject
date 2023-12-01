using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            
            var result = validator.Validate(context);
            if (!result.IsValid) //Geçersizse
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
