using System.IO;

namespace BrokereeSolutions.Models
{
    public abstract class BaseConventer
    {
        public BaseConventer(string fileName, DocumentTypeEnum resultType)
        {
            this.FileName = fileName;
            switch (resultType)
            {
                case DocumentTypeEnum.Csv:
                    var newName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".csv");
                    Result = new CsvDocumentType(newName);
                    break;
                default:
                    //TODO: ???
                    break;
            }
        }

        public abstract void ReadAndWrite();
        public string FileName { get; set; }
        public BaseDocumentType Result { get; set; }

    }
}
