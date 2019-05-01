# BAMCIS Chunk Extension Method

The extension method can be used to chunk an IEnumerable into multiple lists of a specified size.

## Table of Contents
- [Usage](#usage)
- [Revision History](#revision-history)

## Usage

Import the package:

    using BAMCIS.ChunkExtensionMethod;

A simple chunking example:

    int[] numbers = new int[10000];
    
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = i;
    }

    foreach (List<int> chunk in numbers.Chunk(100))
    {
        // Do some work on the chunk
    }

As a more complex use case, if you are interacting with an API that only accepts a certain number of inputs and you need to chunk a large master list to be that size, this makes it really easy. For example, you have a list of 1,000,000 S3 objects that you need to delete. The S3 delete request only accepts 1000 objects per request. You can chunk the 1,000,000 object list into smaller lists of 1000 to provide with each delete request.

## Revision History

### 1.0.0
Initial release of the library.
