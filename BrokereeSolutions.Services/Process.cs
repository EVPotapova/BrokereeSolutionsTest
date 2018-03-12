using BrokereeSolutions.Models;
using BrokereeSolutions.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrokereeSolutions.Services
{
    public static class Helper
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(
  this IEnumerable<T> source,
  int count)
        {
            return source
              .Select((x, y) => new { Index = y, Value = x })
              .GroupBy(x => x.Index / count)
              .Select(x => x.Select(y => y.Value).ToList())
              .ToList();
        }
    }
    public class Process//TODO: Interface
    {
        TasksQueue TasksQueue { get; set; }
        string InputDirectory { get; set; }
        DocumentTypeEnum ResultType { get; set; }



        public Process(string input, DocumentTypeEnum result)
        {
            InputDirectory = input;
            ResultType = result;
        }

        public async Task ProcessBinaryFiles()//TODO: сделать универсальным
        {
            TasksQueue = new TasksQueue();
            TasksQueue.Tasks = new List<BaseTask>();


            try
            {
                var files = Directory.EnumerateFiles(InputDirectory);
                var groups = files.Split(files.Count() / 5);

                foreach (var gr in groups)
                    for (int i = 0; i < gr.Count(); i++)
                    {
                        var filePath = gr.ElementAt(i);
                        BaseConventer converter = new BinaryConverter(filePath, ResultType);
                        BaseTask bTask = new BaseTask
                        {
                            FileName = Path.GetFileName(filePath)
                        };


                        if (i != 0)//TODO: queue
                        {
                            var lastTask = TasksQueue.Tasks.FirstOrDefault(t => t.FileName.Equals(Path.GetFileName(gr.ElementAt(i - 1)))).SystemTask;
                            bTask.SystemTask = lastTask.ContinueWith(_ => converter.ReadAndWrite());

                        }
                        else
                        {
                            bTask.SystemTask = Task.Run(() => converter.ReadAndWrite());

                        }
                        TasksQueue.Tasks.Add(bTask);
                    }



            }
            catch (AggregateException e)
            {
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    //TODO: Message
                }
            }
        }

        public void GetTaskStatus(int id)
        {
            var task = TasksQueue.Tasks.FirstOrDefault(t => t.SystemTask.Id == id);


            Console.WriteLine(task.SystemTask.Id + " - " + task.FileName + " - " + task.SystemTask.Status);
        }

        public void GetTasksStatuses()
        {
            foreach (var task in TasksQueue.Tasks)
            {
                Console.WriteLine(task.SystemTask.Id + " - " + task.FileName + " - " + task.SystemTask.Status);
            }
        }


    }
}
