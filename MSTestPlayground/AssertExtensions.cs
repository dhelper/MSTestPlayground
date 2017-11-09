using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestPlayground
{
    public delegate bool CompareFunc<in T>(T obj1, T obj2);

    public static class AssertExtensions
    {
        public static void AreEqual<T>(this Assert assert, T expected, T actual, IComparer comparer)
        {
            CollectionAssert.AreEqual(
                new[] { expected }, 
                new[] { actual }, comparer, 
                $"\nExpected: <{expected}>.\nActual: <{actual}>.");
        }

        public static void AreEqual<T>(this Assert assert, T expected, T actual, CompareFunc<T> compareFunc)
        {
            var comparer = new LambdaComparer<T>(compareFunc);

            CollectionAssert.AreEqual(
                new[] { expected }, 
                new[] { actual }, comparer, 
                $"\nExpected: <{expected}>.\nActual: <{actual}>.");
        }
    }
}