using System;

namespace SimpleTest
{
    class Program
    {
        static void _Main(string[] args)
        {
            //write code to verify if list is working correctly

            var list = new LinkedList<int>();
            //Test 1. Add Item 
            TestAdd(list);


            //test 2. Item at index 1 should be 20
            TestIndexGetSet(list);


            //Test 3. Should throw exception for invalid index
            var v = list[100];
            Console.WriteLine($"list[100]---> {v}");//this line shouldn't be printed.


            //test 4. We can remove an item from the list
            TestRemoveItem(list, 0);

            //test 5. search an item in the list
            TestItemIndex(list, 20);

        }

        private static void TestRemoveItem(LinkedList<int> list, int index)
        {
            var v = list.Remove(index);
            Console.WriteLine($"Item removed from {index} is {v}");
        }

        private static void TestItemIndex(LinkedList<int> list, int value)
        {
            int index = list.IndexOf(value);
            Console.WriteLine($"index of {value} is {index}");
        }

        private static void TestIndexGetSet(LinkedList<int> list)
        {
            Console.WriteLine($"list[1]={list[1]}");
            list[1] = 100;
            Console.WriteLine($"list[1]={list[1]}");
        }

        private static void TestAdd(LinkedList<int> list)
        {
            //we can add a number items ot the list
            list.Add(10);
            list.Add(20);
            list.Add(30);
            //how do I verify that item is successfully added?
            Console.WriteLine($"Total Items: {list.Count}");
        }
    }
}
