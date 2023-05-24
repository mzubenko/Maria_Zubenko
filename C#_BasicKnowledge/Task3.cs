using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace C__BasicKnowledge
{
    public class Task3
    {
        public int ReduceDigitalRoot(int inputNumber)
        {
            while (inputNumber > 9)
            {
                int digitsSum = 0;
                while (inputNumber > 0)
                {
                    digitsSum += inputNumber % 10;
                    inputNumber /= 10;
                }
                inputNumber = digitsSum;
            }

            return inputNumber;
        }
    }

    public class TestsTask3
    {
        [Test]
        public void Task3_OneDigit_Equal()
        {
            int exampleInput = 7;
            int expectedValue = 7;
            int actualValue = new Task3().ReduceDigitalRoot(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task3_TwoDigitsOneStep_Equal()
        {
            int exampleInput = 21;
            int expectedValue = 3;
            int actualValue = new Task3().ReduceDigitalRoot(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task3_TwoDigitsTwoSteps_Equal()
        {
            int exampleInput = 78;
            int expectedValue = 6;
            int actualValue = new Task3().ReduceDigitalRoot(exampleInput);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
