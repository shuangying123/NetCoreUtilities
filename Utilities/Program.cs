using System;
using System.Buffers.Text;
using System.IO;
using System.Text;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {

            var message = "{ \n    \"header\": {\n\t \"ability-messagetype\": \"platformEvent\",\n\t \"eventType\": \"Abb.Ability.Device.Created\",\n\t \"version\": 1,\n\t \"correlationId\": \"0b0a1255-ba3b-4df0-b971-3de3f89fe6ee\",\n\t \"ack\": \"All\", \n\t\"target\":\"\",\n\t\"owner\":\"Son_device_of_Shuangying_Hoist/DCS800\"\n\t}, \n    \"body\":{\n        \"name\": \"shuangying's DCS800 under Hoist device\",\n        \"objectId\": \"77771255-ba3b-4df0-b971-3de3f89f1111\",\n        \"model\": \"abb.ability.device\",\n        \"type\": \"abb.ability.device.HoistDcs800@1\",    \n        \"properties\": {\n        \t\"HoistDcs800ID\": {\n           \t\t\"value\": \"7777-1111\"\n        \t},\n\t\t\"Manufacturer\":{\n           \t\t\"value\": \"ABB\"\n        \t}\n         }\n    }\n},{ \n    \"header\": {\n\t \"ability-messagetype\": \"platformEvent\",\n\t \"eventType\": \"Abb.Ability.Device.Created\",\n\t \"version\": 1,\n\t \"correlationId\": \"0b0a1255-ba3b-4df0-b971-3de3f89fe6ee\",\n\t \"ack\": \"All\", \n\t\"target\":\"\",\n\t\"owner\":\"Son_device_of_Shuangying_Hoist/DCS800\"\n\t}, \n    \"body\":{\n        \"name\": \"shuangying's DCS800 under Hoist device\",\n        \"objectId\": \"77771255-ba3b-4df0-b971-3de3f89f1111\",\n        \"model\": \"abb.ability.device\",\n        \"type\": \"abb.ability.device.HoistDcs800@1\",    \n        \"properties\": {\n        \t\"HoistDcs800ID\": {\n           \t\t\"value\": \"7777-1111\"\n        \t},\n\t\t\"Manufacturer\":{\n           \t\t\"value\": \"ABB\"\n        \t}\n         }\n    }\n},{ \n    \"header\": {\n\t \"ability-messagetype\": \"platformEvent\",\n\t \"eventType\": \"Abb.Ability.Device.Created\",\n\t \"version\": 1,\n\t \"correlationId\": \"0b0a1255-ba3b-4df0-b971-3de3f89fe6ee\",\n\t \"ack\": \"All\", \n\t\"target\":\"\",\n\t\"owner\":\"Son_device_of_Shuangying_Hoist/DCS800\"\n\t}, \n    \"body\":{\n        \"name\": \"shuangying's DCS800 under Hoist device\",\n        \"objectId\": \"77771255-ba3b-4df0-b971-3de3f89f1111\",\n        \"model\": \"abb.ability.device\",\n        \"type\": \"abb.ability.device.HoistDcs800@1\",    \n        \"properties\": {\n        \t\"HoistDcs800ID\": {\n           \t\t\"value\": \"7777-1111\"\n        \t},\n\t\t\"Manufacturer\":{\n           \t\t\"value\": \"ABB\"\n        \t}\n         }\n    }\n},{ \n    \"header\": {\n\t \"ability-messagetype\": \"platformEvent\",\n\t \"eventType\": \"Abb.Ability.Device.Created\",\n\t \"version\": 1,\n\t \"correlationId\": \"0b0a1255-ba3b-4df0-b971-3de3f89fe6ee\",\n\t \"ack\": \"All\", \n\t\"target\":\"\",\n\t\"owner\":\"Son_device_of_Shuangying_Hoist/DCS800\"\n\t}, \n    \"body\":{\n        \"name\": \"shuangying's DCS800 under Hoist device\",\n        \"objectId\": \"77771255-ba3b-4df0-b971-3de3f89f1111\",\n        \"model\": \"abb.ability.device\",\n        \"type\": \"abb.ability.device.HoistDcs800@1\",    \n        \"properties\": {\n        \t\"HoistDcs800ID\": {\n           \t\t\"value\": \"7777-1111\"\n        \t},\n\t\t\"Manufacturer\":{\n           \t\t\"value\": \"ABB\"\n        \t}\n         }\n    }\n}";


            TestCompression(message, CompressionType.GZip);

            TestCompression(message, CompressionType.Deflate);

            TestDecompress("/Users/ying/PycharmProjects/data.txt.gz", CompressionType.GZip);
        }

        private static void TestCompression(string message, CompressionType compressionType)
        {

            //压缩消息到一个文件
            var compressedMessage = Compression.execute(message, compressionType); //bytes

            var compressedFilename = "printableCompressedMessage.gz";

            FileStream file = new FileStream(compressedFilename, FileMode.Open, FileAccess.ReadWrite);
            file.Write(compressedMessage, 0, compressedMessage.Length);
            file.Close();


            //解压文件
            TestDecompress(compressedFilename, compressionType);


        }

        private static void TestDecompress(string filename, CompressionType compressionType)
        {
            using (FileStream file2 = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                var byteData = new byte[1024 * 64];
                file2.Read(byteData, 0, byteData.Length);

                var decompressedMessage = Decompression.Execute(byteData, compressionType);

                if (decompressedMessage == null)
                {
                    Console.WriteLine($"Decompress using compressionType : {compressionType} failed.");
                }
                else
                {
                    Console.WriteLine($"Decompressed using compressionType : {compressionType}. the result is \n {Encoding.UTF8.GetString(decompressedMessage)}");
                }
            }
        }
    }
}
