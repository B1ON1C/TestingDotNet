using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace xUnitAdvanced.Attributes
{
    public class TestBeforeAfterAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            base.Before(methodUnderTest);
        }
        public override void After(MethodInfo methodUnderTest)
        {
            base.After(methodUnderTest);
        }
    }
}
