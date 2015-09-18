using System.IO;

namespace ResourceVersion
{
    public class EncoderStream
    {
        static public void Encoder(string outPath,Stream stream)
        {
            string strTempPath = Path.GetTempPath() + "/temp.t";
            MemoryStream ms = stream as MemoryStream;
            File.WriteAllBytes(strTempPath, ms.ToArray());

            SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
            using (FileStream rstream = File.OpenRead(strTempPath))
            {
                using (FileStream comperssionStream = File.Create(outPath))
                {
                    encoder.WriteCoderProperties(comperssionStream);

                    comperssionStream.Write(System.BitConverter.GetBytes(stream.Length), 0, 8);

                    encoder.Code(rstream, comperssionStream, rstream.Length, -1, null);
                }
            }

            File.Delete(strTempPath);
        }
    }
}
