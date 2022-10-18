using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            PipeNull ReturnPipe = new PipeNull();

            PipeSerial pipe2 = new PipeSerial(new FilterNegative(), ReturnPipe);
            // PipeFork Fork1 = new PipeFork(pipe2, ReturnPipe);
            PipeSerial pipe1 = new PipeSerial(new FilterGreyscale(), pipe2);

            picture = pipe1.Send(picture);
            provider.SavePicture(picture, @"Beer_Filtered.jpg");
        }
    }
}
