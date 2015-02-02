using System;
using System.ServiceModel;
using ReadifyChallenge.ComplexTypes;

namespace ReadifyChallenge
{
    /// <summary>
    /// IRedPill interface which contains the service contracts
    /// </summary>
    [ServiceContract(Namespace="http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        [OperationContract]
        Guid WhatIsYourToken();

        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);
    }
}
