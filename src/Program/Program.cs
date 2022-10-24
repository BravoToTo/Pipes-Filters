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

            // --- Return Pipe needed for all sequences ---
            PipeNull ReturnPipe = new PipeNull();
            // --------------------------------------------

            // --- Save Steps Sequence ---
            // PipeSerial pipe2 = new PipeSerial(new FilterNegative(), ReturnPipe);
            // PipeSerial SavePipe1 = new PipeSerial(SaveFilter, pipe2);
            // PipeSerial pipe1 = new PipeSerial(new FilterGreyscale(), SavePipe1);
            // picture = pipe1.Send(picture);
            // ---------------------------

            // --- Conditional Pipe Sequence ---
            PipeSerial PipeNegative = new PipeSerial(new FilterNegative(), ReturnPipe);
            PipeSerial PipeGrey = new PipeSerial(new FilterGreyscale(), ReturnPipe);
            PipeFork ConditionalPipe = new PipeFork(PipeGrey, PipeNegative);
            picture = ConditionalPipe.Send(picture);
            // ---------------------------------

            // --- Save Picture To Local ---
            provider.SavePicture(picture, "Final.jpg");
            // -----------------------------

            // --- Twitter API (Publish) ---
            // var twitter = new TwitterImage();
            // Console.WriteLine(twitter.PublishToTwitter("Picture", @"FILENAME_HERE.jpg"));
            // -----------------------------
        }
    }
}
