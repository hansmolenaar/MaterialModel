using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using MaterialModel.RadiantApiSdk.Property;

namespace UnitTests
{

   [TestFixture]
   public class PropertySingleValueFactoryTest

   {
      [Test]
      public void TestMethod1()
      {
         var prop = PropertySingleValueFactory.CreateYoungModulus();
         Assert.IsFalse(string.IsNullOrEmpty(prop.Name));
         Assert.IsTrue(string.IsNullOrEmpty(prop.Name));
      }
   }
}
