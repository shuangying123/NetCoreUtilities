using System;
using System.Text;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {

            var message = "I am original message";
            var compressedMessage = Compression.execute(message, CompressionType.GZip);

            var decompressedMessage = Decompression.Execute(compressedMessage, CompressionType.GZip);

            Console.WriteLine($"compressed and decompressed. the result is {(Encoding.UTF8.GetString(decompressedMessage) == message ? "RIGHT" : "WRONG")}");
        }
    }
}
