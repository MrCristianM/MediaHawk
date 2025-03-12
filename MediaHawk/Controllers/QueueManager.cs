using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk.Controllers
{
    public class QueueManage
    {
        private Queue<string> FileQueue = new Queue<string>();

        public void Enqueue(string filePath)
        {
            FileQueue.Enqueue(filePath);
        }


        public string Dequeue()
        {
            return FileQueue.Count > 0 ? FileQueue.Dequeue() : null;
        }

        public bool IsEmpty()
        {
            return FileQueue.Count == 0;
        }

    }
}
