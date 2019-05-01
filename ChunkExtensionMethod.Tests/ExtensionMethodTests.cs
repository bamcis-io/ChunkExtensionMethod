using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using BAMCIS.ChunkExtensionMethod;

namespace BAMCIS.ChunkListExtensionMethod.Tests
{
    public class ExtensionMethodTests
    {
        [Fact]
        public void ChunkTest()
        {
            // ARRANGE
            int[] numbers = new int[101];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            // ACT
            IEnumerable<List<int>> chunks = numbers.Chunk(10);

            // ASSERT
            Assert.Equal(11, chunks.Count());
            Assert.Equal(1, chunks.Last().Count());
            Assert.Equal(100, chunks.Last().Last());
        }

        [Fact]
        public void ChunkTooSmall()
        {
            // ARRANGE
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            // ACT
            // ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => numbers.Chunk(-1).ToList());               
        }

        [Fact]
        public void NullList()
        {
            // ARRANGE
            int[] numbers = null;

            // ACT
            // ASSERT
            Assert.Throws<ArgumentNullException>(() => numbers.Chunk(10).ToList());
        }
    }
}
