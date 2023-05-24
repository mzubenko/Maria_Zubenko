using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C__BasicKnowledge
{
    public class Task2
    {
        public char FirstNonRepeatingLetter(string inputString)
        {
            foreach (char target in inputString)
            {
                foreach (char element in inputString)
                {
                    if (inputString.IndexOf(element) ==
                        inputString.ToLower().LastIndexOf(element.ToString().ToLower()))
                        return element;
                }

            }
            return ' ';
        }
    }

    public class TestsTask2
    {
        [Test]
        public void Task2_Lowercase_Equal()
        {
            string exampleInput = "stress";
            char expectedValue = 't';
            char actualValue = new Task2().FirstNonRepeatingLetter(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task2_BothCases_Equal()
        {
            string exampleInput = "STress";
            char expectedValue = 'T';
            char actualValue = new Task2().FirstNonRepeatingLetter(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task2_AllRepeating_Equal()
        {
            string exampleInput = "ssttrreess";
            char expectedValue = ' ';
            char actualValue = new Task2().FirstNonRepeatingLetter(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
