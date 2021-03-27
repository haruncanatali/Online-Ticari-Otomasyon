using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object instance)
        {
            var result = validator.Validate(instance);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
