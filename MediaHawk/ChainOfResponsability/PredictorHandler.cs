using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk.ChainOfResponsability
{
    public class PredictorHandler : FileProcessorHandler
    {
        public override void Process(List<string> files)
        {
            Console.WriteLine("Prediction process started");
            //to implement

            base.Process(files);
        }
    }
}
