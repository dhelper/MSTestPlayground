using System.Collections;

namespace MSTestPlayground
{
    class MyClassComparer : IComparer
    {
        private const int ObjectsAreEqual = 0;

        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return ObjectsAreEqual;
            }

            if (!(x is MyClass myClass1) || !(y is MyClass myClass2))
            {
                return -1;
            }

            return myClass1.MyInt == myClass2.MyInt && 
                   myClass1.MyString == myClass2.MyString ? ObjectsAreEqual : 1;
        }
    }
}