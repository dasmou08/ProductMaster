using NUnit.Framework;
using ProductMasterDetails.Data;
using ProductMasterDetails.Models;
using ProductMasterDetails.Utility;
using System.Collections.Generic;
using System.Linq;

namespace ProductTestProject
{
    public class Tests
    {
           

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            HelperClass hpcls = new HelperClass();
            var result = hpcls.compareprice(10, 100);
            Assert.AreEqual(true, result);
        }

       
    }
}