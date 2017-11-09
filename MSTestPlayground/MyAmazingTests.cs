using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestPlayground
{ 
    [TestClass]
    public class MyAmazingTests
    {
        [TestMethod]
        public void CheckForEquality()
        {
            var myClass = new ClassUnderTest();
            var result = myClass.SomeMethodINeedToCheck();

            var expected = new MyClass(1, "some string1");

            Assert.That.AreEqual(expected, result, new MyClassComparer());
        }

        [TestMethod]
        public void CheckForEqualityLambda()
        {
            var myClass = new ClassUnderTest();
            var result = myClass.SomeMethodINeedToCheck();

            var expected = new MyClass(1, "some string1");

            Assert.That.AreEqual(expected, result, 
                (myClass1, myClass2) => 
                myClass1.MyInt == myClass2.MyInt && myClass1.MyString == myClass2.MyString);
        }
    }

    public class ClassUnderTest
    {
        public MyClass SomeMethodINeedToCheck()
        {
            return new MyClass(1, "some string");
        }
    }

    public class MyClass
    {
        public int MyInt { get; }
        public string MyString { get; }

        public MyClass(int myInt, string myString)
        {
            MyInt = myInt;
            MyString = myString;
        }

        public override string ToString()
        {
            return $"{nameof(MyInt)}: {MyInt}, {nameof(MyString)}: {MyString}";
        }
    }
}
