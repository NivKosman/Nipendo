using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace Nipendo.Evaluation
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            // log start rating
            Console.WriteLine("Starting rate.");
            Console.WriteLine("Loading policy.");
                 
            PolicyReader policyReader = new PolicyReader();
            Policy policy = PolicyFactory.getPolicyByPolicyType(policyReader.ReadPolicy());

            if(policy==null)
            {
                Console.WriteLine("Unknown policy type");
            }
            else
            {
                Console.WriteLine($"Rating {policy.Type} Policy");
                Console.WriteLine("Validating policy.");

                string validationMessage = policy.validationMessage();
                if(!string.IsNullOrEmpty(validationMessage))
                {
                    Console.WriteLine(validationMessage);
                }
                else
                {
                    Rating=policy.calculateRating();
                }

            }
         
            Console.WriteLine("Rating completed.");
        }
    }
}
