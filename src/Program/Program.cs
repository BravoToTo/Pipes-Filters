using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            // FilterStoreImage SaveFilter = new FilterStoreImage();

            PipeNull ReturnPipe = new PipeNull();
            // PipeSerial pipe2 = new PipeSerial(new FilterNegative(), ReturnPipe);
            // PipeSerial SavePipe1 = new PipeSerial(SaveFilter, pipe2);
            // PipeSerial pipe1 = new PipeSerial(new FilterGreyscale(), SavePipe1);
            PipeSerial pipe3 = new PipeSerial(new FilterNegative(), ReturnPipe);
            PipeSerial pipe2 = new PipeSerial(new FilterGreyscale(), ReturnPipe);
            PipeFork ConditionalPipe = new PipeFork(pipe2, pipe3);

            picture = ConditionalPipe.Send(picture);
            provider.SavePicture(picture, "Final.jpg");

            // var twitter = new TwitterImage();
            // Console.WriteLine(twitter.PublishToTwitter("Beer", @"Beer_Filtered.jpg"));
            // var twitterDirectMessage = new TwitterMessage();
            // Console.WriteLine(twitterDirectMessage.SendMessage("Hola!", "1396065818"));
        }
    }
}
