using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace PhotoPortal.WebCore.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static List<KeyValuePair<string, List<string>>> CollectErrors(this ModelStateDictionary modelState)
        {
            var errors = modelState.ToList().Select(p =>
                        new KeyValuePair<string, List<string>>(
                            p.Key,
                            p.Value.Errors.Select(e => e.ErrorMessage).ToList())).ToList();

            return errors;
        }
    }
}
