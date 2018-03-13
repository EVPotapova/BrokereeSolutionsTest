using System.IO;

namespace BrokereeSolutions.Models
{
    public abstract class BaseConverter
    {
        public BaseConverter(string fileName, DocumentTypeEnum resultType)
        {
            FileName = fileName;
            string newName;
            
            switch (resultType)
            {
                case DocumentTypeEnum.Csv:
                    newName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".csv");
                    Result = new CsvDocumentType(newName);
                    break;
                default:
                    //TODO: Test purposes
                    newName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".csv");
                    Result = new CsvDocumentType(newName);
                    break;
            }
        }

        public abstract void ReadAndWrite();
        public string FileName { get; set; }
        public BaseDocumentType Result { get; set; }

    }
}
