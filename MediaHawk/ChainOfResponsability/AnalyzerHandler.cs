using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk.ChainOfResponsability
{
    public class AnalyzerHandler : FileProcessorHandler
    {
        public override void Process(List<string> files)
        {
            Console.WriteLine("Analysis process started");
            //To implement

            base.Process(files);
        }
    }
}
