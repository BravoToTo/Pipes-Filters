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
            FilterStoreImage SaveFilter = new FilterStoreImage();

            PipeNull ReturnPipe = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(new FilterNegative(), ReturnPipe);
            PipeSerial SavePipe1 = new PipeSerial(SaveFilter, pipe2);
            PipeSerial pipe1 = new PipeSerial(new FilterGreyscale(), SavePipe1);

            picture = pipe1.Send(picture);
            provider.SavePicture(picture, "Beer_Filtered.jpg");
        }
    }
}
