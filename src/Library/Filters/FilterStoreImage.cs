using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterStoreImage : IFilter
    {
        private int iteration = 1;
        /// Un filtro que retorna el negativo de la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en negativo.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            PictureProvider p = new PictureProvider();
            p.SavePicture(result, $"Step{this.iteration}.jpg");
            this.iteration++;

            return result;
        }
    }
}
