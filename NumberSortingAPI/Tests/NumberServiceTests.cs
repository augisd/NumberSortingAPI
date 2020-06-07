using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSortingAPI.Services;
using NumberSortingAPI.Storage;

namespace NumberSortingAPI.Tests
{
    [TestClass]
    public class NumberServiceTests
    {
        private readonly INumbersService _numbersService;

        public NumberServiceTests()
        {
            FileStorage fileStorage = new FileStorage();
            _numbersService = new NumbersService(fileStorage);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CannotGetNumbersWithoutFile()
        {
            // Arrange
            if (File.Exists("results.txt"))
            {
                File.Delete("results.txt");
            }
            
            // Act
            _numbersService.GetNumbers();
        }

        [TestMethod]
        public void CanWriteNumbers()
        {
            // Arrange
            int[] actualArray = { 1, 2, 3, 4, 5 };
            
            // Act
            _numbersService.WriteNumbers(actualArray);
            
            // Assert
            Assert.IsTrue(File.Exists("results.txt"));
        }

        [TestMethod]
        public void CanGetNumbers()
        {
            // Arrange
            int[] expectedArray = { 1, 2, 3, 4, 5 };
            _numbersService.WriteNumbers(expectedArray);
            
            // Act
            int[] actualArray = _numbersService.GetNumbers();
            
            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void CanSortNumbers()
        {
            // Arrange
            int[] actualArray = { 3, 0, -3, -1, 2, 1, -2 };
            int[] expectedArray = { -3, -2, -1, 0, 1, 2, 3 };
            
            // Act
            _numbersService.SortNumbers(actualArray);
            
            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}