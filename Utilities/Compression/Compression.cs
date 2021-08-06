using System;
using System.IO;
using System.IO.Compression;

namespace Utilities
{
    public class compression
    {
        public byte[] compression(string compressionType)
        {
            if (compressionType.Equals(CompressionType.Deflate))
            {
                using var compressedStream = new MemoryStream();
                using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                    deflateStream.Write(bytes, 0, bytes.Length);

                return compressedStream.ToArray();
            }

            if (compressionType.Equals(CompressionType.GZip))
            {
                using var compressedStream = new MemoryStream();
                using (var gZipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                    gZipStream.Write(bytes, 0, bytes.Length);

                return compressedStream.ToArray();
            }
        }
    }
}
