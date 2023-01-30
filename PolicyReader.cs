using System.IO;

namespace Nipendo.Evaluation
{
    public class PolicyReader
    {
        public string ReadPolicy()
        {
            return File.ReadAllText("policy.json"); ;
        }
    }
}
