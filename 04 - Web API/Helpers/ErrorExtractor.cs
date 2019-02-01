using System.Collections.Generic;
using System.Web.Http.ModelBinding;


namespace JohnBryce
{
    public static class ErrorExtractor
    {
        public static List<PropErrors> ExtractErrors(ModelStateDictionary modelState)
        {
            List<PropErrors> errorList = new List<PropErrors>();

            foreach (var item in modelState)
            {
                PropErrors propErrors = new PropErrors();

                propErrors.property = item.Key;

                foreach (var err in item.Value.Errors)
                {
                    propErrors.errors.Add(err.ErrorMessage);
                }

                errorList.Add(propErrors);
            }
            return errorList;
        }
    }
}