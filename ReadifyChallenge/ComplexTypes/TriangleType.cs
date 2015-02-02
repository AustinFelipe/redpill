using System.Runtime.Serialization;

namespace ReadifyChallenge.ComplexTypes
{
    /// <summary>
    /// Returns a complex type that is used to define the triangule shapes
    /// </summary>
    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType
    {
        [EnumMember]
        Error,

        [EnumMember]
        Equilateral,

        [EnumMember]
        Isosceles,

        [EnumMember]
        Scalene
    }
}