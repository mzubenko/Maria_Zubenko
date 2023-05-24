using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace C__BasicKnowledge
{
    public class Task1
    {
        public List<object> FiltersStringsOutOfList(List<object> list)
        {
            foreach (object item in list.ToList())
            {
                if ((item is String) || (item is Char)) list.Remove(item);
            }
            return list;
        }

    }

    public class TestsTask1
    {
        [Test]
        public void Task1_Chars_Equal()
        {
            List<object> exampleInput = new List<object>() { 1, 2, 'a', 'b' };
            List<int> expected = new List<int>() { 1, 2 };
            List<object> actual = new Task1().FiltersStringsOutOfList(exampleInput);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Task1_CharAndString_Equal()
        {
            List<object> exampleInput = new List<object>() { 1, 2, 'a', "bc", 0, 15 };
            List<int> expected = new List<int>() { 1, 2, 0, 15 };
            List<object> actual = new Task1().FiltersStringsOutOfList(exampleInput);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
