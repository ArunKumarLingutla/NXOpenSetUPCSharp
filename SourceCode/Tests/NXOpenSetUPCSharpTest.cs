using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NXOpenSetupCSharpTest
{
    [TestFixture]
    public class NXOpenSetUPCSharpTest
    {
        [Test]
        public void Test_ToolInitialization()
        {
            string rootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            //string rootDirectory1 = TestContext.CurrentContext.TestDirectory;
        }
    }
}
