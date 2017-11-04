using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuizTest
{
    [TestClass]
    public class DataStructureTest
    {
        [TestMethod]
        public void FindTwoSumTest()
        {
            List<FindTwoSumTestCase> cases = new List<FindTwoSumTestCase>()
            {
                new FindTwoSumTestCase() {
                    List = new int[] { 1, 3, 5, 7, 9 },
                    Target = 10,
                    ExpectedResult = true
                },
                new FindTwoSumTestCase() {
                    List = new int[] { 1, 3, 5, 7, 9 },
                    Target = 11,
                    ExpectedResult = false
                },
                new FindTwoSumTestCase()
                {
                    List = new int[100000],  // init value: 0
                    Target = 0,
                    ExpectedResult = true
                },
                new FindTwoSumTestCase()
                {
                    List = new int[1000],  // init value: 0
                    Target = 1,
                    ExpectedResult = false
                }

            };


            

            Stopwatch timer = new Stopwatch();
            foreach (FindTwoSumTestCase c in cases)
            {
                timer.Restart();
                Assert.AreEqual(
                    Quiz.DataStructure.FindTwoSum.IsMatch(c.List, c.Target),
                    c.ExpectedResult);

                //
                // NOTE: 運算效能驗證，必須在 1ms 的時間內完成該筆 test case。
                //
                Assert.IsTrue(timer.Elapsed < TimeSpan.FromMilliseconds(1));
            }
        }
    }




    public class FindTwoSumTestCase
    {
        public int[] List;
        public int Target;
        public bool ExpectedResult;
    }
}
