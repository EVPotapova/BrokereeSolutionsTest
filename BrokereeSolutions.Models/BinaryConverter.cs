using System.IO;

namespace BrokereeSolutions.Models
{
    public class BinaryConverter : BaseConverter
    {
        public BinaryConverter(string fileName, DocumentTypeEnum resultType) : base(fileName, resultType) { }
        public override void ReadAndWrite()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    TradeRecord record = new TradeRecord
                    {
                        id = reader.ReadInt32(),
                        account = reader.ReadInt32(),
                        volume = reader.ReadDouble(),
                        comment = reader.ReadString()
                    };

                    Result.WriteRecord(record);
                }
            }
        }
    }
}
