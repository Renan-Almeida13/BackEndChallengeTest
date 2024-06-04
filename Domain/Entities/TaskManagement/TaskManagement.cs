using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement
{
    public class TaskManagement : Entity
    {
        public string UserName { get; set; }
        public DateTime Date {  get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
