namespace DynamicArrayTestProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task03;
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDefaultCtor()
        {
            var dynamicArr = new DynamicArray<int>();
            Assert.AreEqual(8, dynamicArr.Capacity);
            Assert.AreEqual(0, dynamicArr.Length);
        }

        [TestMethod]
        public void TestCtorWithParam()
        {
            var dynamicArr = new DynamicArray<int>(10);
            Assert.AreEqual(10, dynamicArr.Capacity);
            Assert.AreEqual(0, dynamicArr.Length);
        }

        [TestMethod]
        public void TestCtorWithCollection()
        {
            int[] tmpArr = { 1, 2, 3, 4, 5 };
            var dynamicArr = new DynamicArray<int>(tmpArr);
            Assert.AreEqual(13, dynamicArr.Capacity);
            Assert.AreEqual(5, dynamicArr.Length);
            Assert.AreEqual(1, dynamicArr[0]);

            var dynamicArr2 = new DynamicArray<int>(dynamicArr);
            Assert.AreEqual(13, dynamicArr2.Capacity);
            Assert.AreEqual(5, dynamicArr2.Length);
            Assert.AreEqual(1, dynamicArr2[0]);
        }

        [TestMethod]
        public void TestAddMethod()
        {
            var dynamicArr = new DynamicArray<int>();
            for (int i = 0; i < 9; i++)
            {
                dynamicArr.Add(i);
            }

            Assert.AreEqual(8, dynamicArr[8]);
        }

        [TestMethod]
        public void TestAddRangeMethod()
        {
            var dynamicArr = new DynamicArray<int>();
            var tmpArr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                {
                    dynamicArr.Add(i);
                }

                tmpArr[i] = i;
            }

            dynamicArr.AddRange(tmpArr);
            Assert.AreEqual(0, dynamicArr[5]);
        }

        [TestMethod]
        public void TestInsertMethod()
        {
            var dynamicArr = new DynamicArray<int>();
            var actual = dynamicArr.Insert(0, 1);
            Assert.AreEqual(true, actual);
            Assert.AreEqual(1, dynamicArr[0]);

            actual = dynamicArr.Insert(-1, 1);
            Assert.AreEqual(false, actual);

            for (int i = 0; i < 9; i++)
            {
                dynamicArr.Add(i);
            }

            actual = dynamicArr.Insert(8, 1);
            Assert.AreEqual(1, dynamicArr[8]);
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            var dynamicArr = new DynamicArray<int>();

            for (int i = 0; i < 9; i++)
            {
                dynamicArr.Add(i);
            }

            var actual = dynamicArr.Remove(0);
            Assert.AreEqual(true, actual);
            Assert.AreEqual(1, dynamicArr[0]);
        }
    }
}