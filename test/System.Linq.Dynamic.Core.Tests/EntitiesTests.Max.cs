#if EFCORE
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
#else
using System.Data.Entity;
using EntityFramework.DynamicLinq;
#endif
using Xunit;

namespace System.Linq.Dynamic.Core.Tests
{
    public partial class EntitiesTests
    {
        [Fact]
        public void Entities_Max_Integer()
        {
            // Arrange
            PopulateTestData(2, 0);

            var expected = _context.Blogs.Select(b => b.BlogId).Max();

            // Act
            var actual = _context.Blogs.Select("BlogId").Max();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Entities_Max_Integer_Selector()
        {
            // Arrange
            PopulateTestData(2, 0);

            var expected = _context.Blogs.Max(b => b.BlogId);

            // Act
            var actual = _context.Blogs.Max("BlogId");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
