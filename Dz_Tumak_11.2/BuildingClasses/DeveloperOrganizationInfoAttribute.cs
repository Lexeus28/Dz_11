using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Tumak_11._2.BuildingClasses
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperOrganizationInfoAttribute : Attribute
    {
        public string developerName { get; }
        public string organization { get; }

        public DeveloperOrganizationInfoAttribute(string developerName, string organization)
        {
            this.developerName = developerName;
            this.organization = organization;
        }
    }
}
