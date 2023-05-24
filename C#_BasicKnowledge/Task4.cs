using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace C__BasicKnowledge
{
    public class Task4
    {
        public int FindSumOfTarget(int[] inputArray, int targetNumber)
        {
            int pairCounter = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] + inputArray[j] == targetNumber)
                        pairCounter++;
                }
            }
            return pairCounter;
        }
    }

    public class TestsTask4
    {
        [Test]
        public void Task4_Target5_Equal()
        {
            int[] exampleInputArray = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };
            int exampleInputTarget = 5;
            int expectedValue = 4;
            int actualValue = new Task4().FindSumOfTarget(exampleInputArray, exampleInputTarget);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Task4_Target4_Equal()
        {
            int[] exampleInputArray = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };
            int exampleInputTarget = 4;
            int expectedValue = 3;
            int actualValue = new Task4().FindSumOfTarget(exampleInputArray, exampleInputTarget);
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
