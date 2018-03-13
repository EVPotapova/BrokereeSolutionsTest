using BrokereeSolutions.Models;
using BrokereeSolutions.Services;
using System;

namespace BrokereeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Чтобы добавить новый тип документа нужно:
             * 1. Добавить тип в DocumentTypeEnum
             * 2. Реализовать конвертер от BaseConverter
             * 3. Реализовать результирующий тип от DocumentType
             * 4. Добавить генерацию нужного конвертера в Process (выполняет роль менеджера для конвертеров)
             * 5. Добавить генерацию результирующего типа документа в BaseConverter
             */
            Process process = new Process(@"C:\BSTest\Input", DocumentTypeEnum.Binary, DocumentTypeEnum.Csv);

            var awaiter = process.ProcessFiles().GetAwaiter();

            while (!process.IsCompleted)
            {
                Console.ReadLine();
                Console.WriteLine(process.GetTasksStatuses());
            }

            Console.WriteLine("Complete!");
            Console.ReadLine();
        }


    }


}
