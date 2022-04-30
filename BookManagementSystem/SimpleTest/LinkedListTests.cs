using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleTest
{
    public class LinkedListTests
    {
        LinkedList<int> list;
        public LinkedListTests()
        {
            list = new LinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
        }

        [Fact]
       public void TestListAdd()
        {
            
            if(list.Count!=3)
                throw new Exception("Item Add failed. Result should be 3");

        }

        [Fact]
        public void IndexerCanModifyTheValueAtValidIndex()
        {
            list[1] = 40;

            Assert.Equal(40, list[1]);

        }

        [Fact]
        public void IndexerCanGetValueFromValidIndex()
        {
            //Arrange --> done in constructor          

            //Act
            var value = list[1];           

            //Assert
            Assert.Equal(20, value); //I expect value to be 20 on index[1]

        }

        [Fact]
        public void IndexOfCanReturnIndexOfAvaialbleItem()
        {
            var index = list.IndexOf(20);

            Assert.Equal(1, index);
        }

        [Fact]
        public void IndexOfReturnsMinusOneForUnAvaiableItem()
        {
            Assert.Equal(-1, list.IndexOf(100));
        }


        [Fact]
        public void IndexGetShouldFailForInvalidIndex()
        {
            int index = 100;
            try
            {
                var value = list[index];
                //if you reach here test has failed as excepion was not thrown
                Assert.True(false, "Excepted exception was not thrown");
            }catch(IndexOutOfRangeException ex)
            {
                
                Assert.Contains($"invalid index {index}", ex.Message);
            }
            
        }

        [Fact]
        public void IndexSetShouldFailForInvalidIndex()
        {
            int index = 100;

             var ex = Assert.Throws<IndexOutOfRangeException>(() =>
             {
                 //Act here
                 list[index] = 1; //this will not happen
             });

            Assert.Contains($"invalid index {index}", ex.Message);

        }

        [Fact]
        public void RemoveShouldRemoveTheItemFromList()
        {
            //Act
            var value = list.Remove(1); //removes a valid value

            //Assert
            Assert.Equal(20, value);
            Assert.Equal(-1, list.IndexOf(value));
            Assert.Equal(2, list.Count);
        }


    }
}
