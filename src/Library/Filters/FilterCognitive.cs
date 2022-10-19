using System;
using System.IO;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y revisa si hay una cara presente.
    /// </remarks>
    public class FilterCognitive
    {
        /// Un filtro que revisa si hay una cara presente.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>true/false dependiendo de si se encuentra una cara o no.</returns>
        public bool Filter(IPicture image)
        {
            IPicture result = image.Clone();
            PictureProvider p = new PictureProvider();
            p.SavePicture(result, "hasFace.jpg");
            
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize("hasFace.jpg");

            File.Delete("hasFace.jpg");

            if (cog.FaceFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
