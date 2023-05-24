using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace C__BasicKnowledge
{
    public class Task5
    {
        public string SortAndSplit(string inputString)
        {
            string upperInputString = inputString.ToUpper();
            string[] separatedString = upperInputString.Split(';');
            string[] modifiedSeparatedString = new string[separatedString.Length];

            for (int i = 0; i < separatedString.Length; i++)
            {
                modifiedSeparatedString[i] = '(' + separatedString[i].Split(':')[1] +
                    ", " + separatedString[i].Split(':')[0] + ')';
            }

            Array.Sort(modifiedSeparatedString);
            string strResult = "";

            for (int i = 0; i < modifiedSeparatedString.Length; i++)
            {
                strResult += modifiedSeparatedString[i];
            }

            return strResult;
        }
    }

    public class TestsTask5
    {
        [Test]
        public void Task5_DifferentFirstNames_Equal()
        {
            string exampleInput = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;" +
                "Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expectedValue = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)" +
                "(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            string actualValue = new Task5().SortAndSplit(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task5_SameFirstNames_Equal()
        {
            string exampleInput = "Mary:Smith;Ron:Smith;Barney:Simpson;" +
                "Betty:Tornbull;Betty:Tornbull;Albert:Brown";
            string expectedValue = "(BROWN, ALBERT)(SIMPSON, BARNEY)(SMITH, MARY)" +
                "(SMITH, RON)(TORNBULL, BETTY)(TORNBULL, BETTY)";
            string actualValue = new Task5().SortAndSplit(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
