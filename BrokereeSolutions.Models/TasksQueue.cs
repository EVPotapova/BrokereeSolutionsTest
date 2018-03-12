using BrokereeSolutions.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokereeSolutions.Models
{
    public class TasksQueue
    {
        public List<BaseTask> Tasks { get; set; }
        public int QueueCapacity { get; set; }
    }

    public class BaseTask
    {
        public string FileName { get; set; }
        public Task SystemTask { get; set; }
        public Exception Error { get; set; }
    }
}
