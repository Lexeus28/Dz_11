using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Tumak_11._2.NumsClasses
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperInfoAttribute : Attribute
    {
        public string developerName { get; }
        public string date { get; }

        public DeveloperInfoAttribute(string developerName, string date)
        {
            this.developerName = developerName;
            this.date = date;
        }
    }
}
