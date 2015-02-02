/////////////////////////////////////////////
//
// Created by: Austin Felipe
// Created at: 02/02/2015
// Objective: Join the Redify's team
//
/////////////////////////////////////////////
using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using ReadifyChallenge.ComplexTypes;

namespace ReadifyChallenge
{
    public class RedPill : IRedPill
    {
        /// <summary>
        /// Returns the token created by Redify
        /// </summary>
        /// <returns>A guid representing the token</returns>
        public Guid WhatIsYourToken()
        {
            return new Guid("6e2f42f7-ae23-4045-853e-e5fb5122b617");
        }

        /// <summary>
        /// The method execute a Fibonacci's sequence using the defined param, which defines 
        /// how many times the method will execute the sequence
        /// 
        /// An ArgumentOutOfRangeException is dispatched when the param is bigger than 92
        /// </summary>
        /// <param name="n">How many times the method will run the Fibonacci's sequence (Max 92)</param>
        /// <returns>a long containing the found solution</returns>
        public long FibonacciNumber(long n)
        {
            if (n > 92)
            {
                throw new FaultException<ArgumentOutOfRangeException>(
                    new ArgumentOutOfRangeException("s", "Value cannot be null."),
                    "Fib(>92) will cause a 64-bit integer overflow. " + Environment.NewLine + "Parameter name: n"
                    );
            }

            long a = 0;
            long b = 1;
            while (n-- > 1)
            {
                long t = a;
                a = b;
                b += t;
            }
            return b;
        }

        /// <summary>
        /// The method defines the triangule shape using the params
        /// 
        /// TriangleType.Equilateral = The sides have the same value
        /// TriangleType.Isosceles = Just 2 sides are equal
        /// TriangleType.Scalene = Each side is different from each other
        /// 
        /// It returns TriangleType.Error when the sides are invalid values (less than or equal 0) or 
        /// you cannot complete a triangule
        /// </summary>
        /// <param name="a">First side of the triangule</param>
        /// <param name="b">Second side of the triangule</param>
        /// <param name="c">Third side of the triangule</param>
        /// <returns>TriangleType value</returns>
        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Error;
            }
            else if (a + b <= c || a + c <= b || b + c <= a)
            {
                return TriangleType.Error;
            }

            int[] sides = new int[3] { a, b, c };

            if (sides.Distinct().Count() == 1)
            {
                return TriangleType.Equilateral;
            }
            else if (sides.Distinct().Count() == 2)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

        /// <summary>
        /// The method reverses the string passed in the param without change de word's order
        /// 
        /// Use example
        ///     s = Austin Felipe
        ///     returns = nitsuA epileF
        ///     
        /// An ArgumentNullException is dispatched when the param 's' is null
        /// </summary>
        /// <param name="s">String to be reversed</param>
        /// <returns>The 's' param reversed</returns>
        public string ReverseWords(string s)
        {
            if (s == null)
            {
                throw new FaultException<ArgumentNullException>(new ArgumentNullException("s", "Value cannot be null."), "Value cannot be null. " + Environment.NewLine + "Parameter name: s");
            }
            string[] stringArr = s.Split(' ');

            for (int i = 0; i < stringArr.Length; i++)
            {
                stringArr[i] = String.Join("", stringArr[i].Reverse());
            }

            return String.Join(" ", stringArr);
        }
    }
}
