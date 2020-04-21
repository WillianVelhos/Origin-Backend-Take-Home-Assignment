using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RiskProfile.Web.DataAnnotations
{
    public class RiskAnswersAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var answers = value as IList<int>;

            return answers?.Count == 3 && answers.All(x => x == 0 || x == 1);
        }
    }
}
