using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverProblems;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRoverTest
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestMethod1()
        {

            MarsRover roboticRover = new MarsRover();
            List<string> result = new List<string>();

            Dictionary<ArrayList, List<string>> myList = new Dictionary<ArrayList, List<string>>();
            myList.Add(new ArrayList { 1, 2, "N" }, new List<string> { "L", "M", "L", "M", "L", "M", "L", "M", "M" });
            myList.Add(new ArrayList { 3, 3, "E" }, new List<string> { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" });


            List<string> expectOutPut = new List<string> { "1 3 N", "5 1 E" };
            result = roboticRover.MarsRoverMove(myList);

            CollectionAssert.AreEquivalent(expectOutPut, result);




        }
    }
}
