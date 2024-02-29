using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        // bu kod hata verdi

        //public static void Validate(IValidator validator, object entity)
        //{
        //    var result = validator.Validate(entity);

        //    if (result.Errors.Count > 0)
        //    {
        //        throw new ValidationException(result.Errors);
        //    }
        //}

        public static void Validate<T>(IValidator<T> validator, T entity)
        {
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
