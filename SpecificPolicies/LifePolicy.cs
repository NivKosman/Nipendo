using System;

namespace Nipendo.Evaluation.SpecificPolicies
{
    public class LifePolicy : Policy
    {
        public override string validationMessage()
        {
            string validationMassage = null;
            if (this.DateOfBirth == DateTime.MinValue)
            {
                validationMassage="Life policy must include Date of Birth.";
            }
            else if (this.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                validationMassage = "Max eligible age for coverage is 100 years.";
            }
            else if(this.Amount == 0)
            {
                validationMassage = "Life policy must include an Amount.";
            }

            return validationMassage;
        }

        public override decimal calculateRating()
        {
            int age = DateTime.Today.Year - this.DateOfBirth.Year;

            if (this.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < this.DateOfBirth.Day ||
                DateTime.Today.Month < this.DateOfBirth.Month)
            {
                age--;
            }

            decimal Rating = this.Amount * age / 200;
            if (this.IsSmoker)
            {
                Rating *= 2;
            }

            return Rating;
        }
    }
}
