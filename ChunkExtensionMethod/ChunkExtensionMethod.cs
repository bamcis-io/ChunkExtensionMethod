using System;
using System.Collections.Generic;
using System.Linq;

namespace BAMCIS.ChunkExtensionMethod
{
    /// <summary>
    /// Extension method class for the chunk list method
    /// </summary>
    public static class ChunkExtensionMethod
    {
        /// <summary>
        /// Chunks an IEnumerable into multiple lists of a specified size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The IEnumerable to chunk</param>
        /// <param name="chunkSize">The size of the chunks to produce</param>
        /// <returns>An IEnumerable of lists that are the specified chunk size, except for the
        /// last chunk which will be the size of the remaining items</returns>
        public static IEnumerable<List<T>> Chunk<T>(this IEnumerable<T> input, int chunkSize)
        {
            if (chunkSize <= 0) 
            {
                throw new ArgumentOutOfRangeException("chunkSize", "The chunk size must be greater than 0.");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Any())
            {
                IEnumerator<T> enumerator = input.GetEnumerator();
                List<T> returnList = new List<T>(chunkSize);
                int counter = 0;

                while (enumerator.MoveNext())
                {
                    if (counter >= chunkSize)
                    {
                        yield return returnList;
                        returnList = new List<T>();
                        counter = 0;
                    }

                    returnList.Add(enumerator.Current);
                    counter++;
                }

                yield return returnList;
            }
        }
    }
}
