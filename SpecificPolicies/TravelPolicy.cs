using System;

namespace Nipendo.Evaluation.SpecificPolicies
{
    public class TravelPolicy : Policy
    {
        public override string validationMessage()
        {
            string validationMassage = null;

            if (this.Days <= 0)
            {
                validationMassage = "Travel policy must specify Days.";
            }
            else if (this.Days > 180)
            {
                validationMassage = "Travel policy cannot be more then 180 Days.";
            }
            else if (String.IsNullOrEmpty(this.Country))
            {
                validationMassage = "Travel policy must specify country.";
            }

            return validationMassage;
        }

        public override decimal calculateRating()
        {
            decimal Rating = this.Days * 2.5m;
            if (this.Country == "Italy")
            {
                Rating *= 3;
            }

            return Rating;
        }
    }
}
