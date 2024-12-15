// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class MemoryAllocator
{
    static void Main()
    {
        Console.WriteLine("Allocating memory in 1GB blocks...");

        List<byte[]> memoryBlocks = new List<byte[]>();
        int blockSize = 1024 * 1024 * 1024; // 1GB in bytes
        int allocatedBlocks = 0;

        try
        {
            while (true)
            {
                var block = new byte[blockSize];
                for (int i = 0; i < block.Length; i++) block[i] = 1; // Touch each byte
                memoryBlocks.Add(block);
                allocatedBlocks++;
                Console.WriteLine($"Allocated {allocatedBlocks} GB of memory...");
            }
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Out of memory! Stopping allocation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press Enter to release memory...");
        Console.ReadLine();

        // Release memory
        memoryBlocks.Clear();
        GC.Collect();
        Console.WriteLine("Memory released. Exiting program.");
    }
}

