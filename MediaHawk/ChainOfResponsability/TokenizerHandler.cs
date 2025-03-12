using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk.ChainOfResponsability
{
    public class TokenizerHandler : FileProcessorHandler
    {
        public override void Process(List<string> files)
        {
            Console.WriteLine("Tokenization process started");
            //To implement tokenization logic

            base.Process(files);
        }
    }
}
