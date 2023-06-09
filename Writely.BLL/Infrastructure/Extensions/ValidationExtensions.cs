using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writely.BLL.Infrastructure.Extensions
{
    public static class ValidationExtensions
    {
        public static List<string> GetErrorMessages(this ValidationResult valResult)
        {
            return valResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        public static List<string> GetErrorMessagesWithPropertyName(this ValidationResult valResult)
        {
            return valResult.Errors
                .Select(x => $"{x.PropertyName} | {x.ErrorMessage}").ToList();
        }
    }
}
