namespace BrokereeSolutions.Models
{
    public abstract class BaseDocumentType
    {
        public BaseDocumentType(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; set; }

        public abstract void WriteRecord(TradeRecord record);
    }
}
