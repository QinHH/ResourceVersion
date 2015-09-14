using System.IO;

namespace ResourceVersion
{
    public class EncoderStream
    {
        static public void Encoder(string outPath,Stream stream)
        {
            using (FileStream fileStream = File.Create(outPath))
            {
                SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
                encoder.WriteCoderProperties(fileStream);

                fileStream.Write(System.BitConverter.GetBytes(stream.Length), 0, 8);

                encoder.Code(stream, fileStream, stream.Length, -1, null);
            }
        }
    }
}
