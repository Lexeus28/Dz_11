using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BuilderOrganizationInfoAttribute : Attribute
    {
        public string builderName { get; }
        public string organization { get; }

        public BuilderOrganizationInfoAttribute(string builderName, string organization)
        {
            this.builderName = builderName;
            this.organization = organization;
        }
    }
}
