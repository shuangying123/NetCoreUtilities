using System;
using System.IO;
using System.IO.Compression;

namespace Utilities
{
    public class Decompression
    {
        public static byte[] Execute(byte[] message, CompressionType compressionType)
        {
            if (compressionType.Equals(CompressionType.Deflate))
            {
                using var decompressedStream = new MemoryStream(message);
                using var deflateStream = new DeflateStream(decompressedStream, CompressionMode.Decompress);
                using var resultStream = new MemoryStream();
                deflateStream.CopyTo(resultStream);

                var decompressedMessage = resultStream.ToArray();
                return decompressedMessage;
            }

            if (compressionType.Equals(CompressionType.GZip))
            {
                using var decompressedStream = new MemoryStream(message);
                using var gZipStream = new GZipStream(decompressedStream, CompressionMode.Decompress);
                using var resultStream = new MemoryStream();
                gZipStream.CopyTo(resultStream);

                var decompressedMessage = resultStream.ToArray();
                return decompressedMessage;
            }

            return message;
        }
    }
}
