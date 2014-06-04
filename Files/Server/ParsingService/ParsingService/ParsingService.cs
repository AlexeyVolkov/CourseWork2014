using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingService
{
    [ServiceContract]
    public interface Parsing
    {
        [OperationContract]
        bool ParseThatString(string Link);
    }
    public class ParsiService:Parsing
    {
        public bool ParseThatString(string Link)
        {
            Console.WriteLine("Here we go: {0}", Link);
            return true;
        }
    }
}
