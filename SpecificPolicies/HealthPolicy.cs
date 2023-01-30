using System;

namespace Nipendo.Evaluation.SpecificPolicies
{
    public class HealthPolicy : Policy
    {
        public override string validationMessage()
        {
            bool isValid= !String.IsNullOrEmpty(this.Gender);
            return isValid ? null : "Health policy must specify Gender";
        }

        public override decimal calculateRating()
        {
            return this.Gender == "Male" ? 900m : 1000m;
        }
    }
}
