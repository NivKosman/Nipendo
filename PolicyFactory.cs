using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Nipendo.Evaluation.SpecificPolicies;

namespace Nipendo.Evaluation
{
    public static class PolicyFactory
    {
        public static Policy getPolicyByPolicyType(string policyJson)
        {
            Policy policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                    new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Health:
                    policy = JsonConvert.DeserializeObject<HealthPolicy>(policyJson,
                    new StringEnumConverter());
                    break;

                case PolicyType.Travel:
                    policy = JsonConvert.DeserializeObject<TravelPolicy>(policyJson,
                    new StringEnumConverter());
                    break;

                case PolicyType.Life:
                    policy = JsonConvert.DeserializeObject<LifePolicy>(policyJson,
                    new StringEnumConverter());
                    break;

                default:
                    policy = null;
                    break;
            }

            return policy;
        }
    }
}
