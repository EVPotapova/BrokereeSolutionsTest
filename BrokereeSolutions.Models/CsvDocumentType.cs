using System.IO;

namespace BrokereeSolutions.Models
{

    public class CsvDocumentType : BaseDocumentType
    {
        public CsvDocumentType(string fileName) : base(fileName) { }
        public override void WriteRecord(TradeRecord record)
        {
            
            File.AppendAllText(FileName, record.ToCsvString());
        }
    }

}
