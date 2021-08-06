using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Utilities
{
    public class Compression
    {
        public static byte[] execute(string body, CompressionType compressionType)
        {

            var bytes = Encoding.UTF8.GetBytes(body);
            byte[] compressedBytes = bytes;
            if (compressionType.Equals(CompressionType.Deflate))
            {
                using var compressedStream = new MemoryStream();
                using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                    deflateStream.Write(bytes, 0, bytes.Length);

                compressedBytes = compressedStream.ToArray();
            }

            if (compressionType.Equals(CompressionType.GZip))
            {
                using var compressedStream = new MemoryStream();
                using (var gZipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                    gZipStream.Write(bytes, 0, bytes.Length);
                compressedBytes = compressedStream.ToArray();
            }

            return compressedBytes;
        }
    }
}
