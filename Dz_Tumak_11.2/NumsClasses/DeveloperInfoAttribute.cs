using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
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
