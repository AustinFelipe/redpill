using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadifyChallenge.ComplexTypes;
using System;
using System.ServiceModel;

namespace ReadifyChallenge.Tests
{
    [TestClass]
    public class RedPillTest
    {
        private Uri baseAddress = new Uri("http://localhost:3303/RedPill.svc");
        private IRedPill client;

        #region Initialize and Cleanup
        [TestInitialize]
        public void Setup()
        {
            var factory = new ChannelFactory<IRedPill>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            client = factory.CreateChannel();
        }

        [TestCleanup]
        public void TearDown()
        {
            if (client != null)
                ((ICommunicationObject)client).Close();
        }
        #endregion

        #region WhatIsYourToken tests

        [TestMethod]
        public void WhatIsYourToken_MustReturnMyToken()
        {
            Assert.AreEqual(client.WhatIsYourToken(), new Guid("6e2f42f7-ae23-4045-853e-e5fb5122b617"), 
                "WhatIsYourToken returned a different token.");
        }

        #endregion

        #region FibonacciNumber tests

        [TestMethod]
        public void FibonacciNumber_MustReturnTheCorrectNumber()
        {
            Assert.AreEqual(client.FibonacciNumber(3), 2, "FibonacciNumber returned a incorrect value when 3 was passed");
            Assert.AreEqual(client.FibonacciNumber(42), 267914296, "FibonacciNumber returned a incorrect value when 42 was passed");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ArgumentOutOfRangeException>))]
        public void FibonacciNumber_MustReturnExceptionWhenBiggerThan92()
        {
            try
            {
                client.FibonacciNumber(93);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsTrue(e.Message.Contains("Fib(>92) will cause a 64-bit integer overflow. Parameter name: n"), 
                    "MustReturnExceptionWhenBiggerThan92 returned a differente message error.");
                throw e;
            }
        }

        #endregion

        #region WhatShapeIsThis

        [TestMethod]
        public void WhatShapeIsThis_MustReturnTriangleTypeError()
        {
            Assert.AreEqual(client.WhatShapeIsThis(0, 1, 2), TriangleType.Error,
                "MustReturnTriangleTypeError did not return an Error when 0, 1, 2 was passed.");
            Assert.AreEqual(client.WhatShapeIsThis(4, 1, 2), TriangleType.Error,
                "MustReturnTriangleTypeError did not return an Error when 4, 1, 2 was passed.");
        }

        [TestMethod]
        public void WhatShapeIsThis_MustReturnTriangleTypeIsosceles()
        {
            Assert.AreEqual(client.WhatShapeIsThis(2, 1, 2), TriangleType.Isosceles,
                "MustReturnTriangleTypeIsosceles did not return an Isosceles when 2, 1, 2 was passed.");
            Assert.AreEqual(client.WhatShapeIsThis(4, 4, 6), TriangleType.Isosceles,
                "MustReturnTriangleTypeIsosceles did not return an Isosceles when 4, 4, 6 was passed.");
        }

        [TestMethod]
        public void WhatShapeIsThis_MustReturnTriangleTypeScalene()
        {
            Assert.AreEqual(client.WhatShapeIsThis(2, 4, 3), TriangleType.Scalene,
                "MustReturnTriangleTypeScalene did not return an Scalene when 2, 4, 3 was passed.");
            Assert.AreEqual(client.WhatShapeIsThis(4, 5, 6), TriangleType.Scalene,
                "MustReturnTriangleTypeScalene did not return an Scalene when 4, 5, 6 was passed.");
        }

        #endregion

        #region ReverseWords tests

        [TestMethod]
        public void ReverseWords_MustReturnAReversedString()
        {
            Assert.AreEqual(client.ReverseWords("Austin Felipe"), "nitsuA epileF",
                "MustReturnAReversedString returned an incorrect value.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ArgumentNullException>))]
        public void ReverseWords_MustReturnExceptionWhenTheStringIsNull()
        {
            try
            {
                client.ReverseWords(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.Message.Contains("Value cannot be null. Parameter name: s"),
                    "MustReturnExceptionWhenTheStringIsNull returned a differente message error.");
                throw e;
            }
        }

        #endregion
    }
}
