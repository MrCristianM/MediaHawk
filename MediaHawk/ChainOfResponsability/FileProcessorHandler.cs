using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk.ChainOfResponsability
{
    public abstract class FileProcessorHandler
    {
        protected FileProcessorHandler nextHandler;

        public void SetNext(FileProcessorHandler next)
        {
            nextHandler = next;
        }
        public virtual void Process(List<string> files)
        {
            nextHandler?.Process(files);
        }
        
    }
}
