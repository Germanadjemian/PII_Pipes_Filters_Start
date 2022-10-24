using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider1 = new PictureProvider();
            IPicture picture = provider1.GetPicture("beer.jpg");
            PipeNull pipeNull= new PipeNull();
            FilterGreyscale filter2= new FilterGreyscale();
            FilterNegative filter1= new FilterNegative();

            PipeSerial pipeSerial2= new PipeSerial(filter2,pipeNull);
            PipeSerial pipeSerial1= new PipeSerial(filter1,pipeSerial2);
            pipeSerial1.Send(picture);

            IPicture image =pipeSerial1.Send(picture);
            pipeNull.Send(image);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(image, "beer.jpg");



            PictureProvider provider3 = new PictureProvider();
            IPicture picture2 = provider3.GetPicture("niño.jpg");

            PipeNull pipeNull2= new PipeNull();

            PipeSerial pipeSerial4= new PipeSerial(filter2,pipeNull2);
            //GUARDO IMAGEN CON EL FILTRO SAVEIMAGE (a saber como implementarlo)
            PipeSerial pipeSerial3= new PipeSerial(filter2,pipeSerial4);


        }
    }
}
