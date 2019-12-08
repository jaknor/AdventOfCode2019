namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;

    public class EncodedSpaceImage
    {
        public EncodedSpaceImage(string imageData, int width, int height)
        {
            var layers = new List<ImageLayer>();

            var layerLength = width * height;
            while (imageData.Length >= layerLength)
            {
                layers.Add(new ImageLayer(imageData.Substring(0, layerLength), width, height));
                imageData = imageData.Substring(layerLength);
            }

            Layers = layers;
            Width = width;
            Height = height;
        }

        public List<ImageLayer> Layers { get; }

        public int Width { get; }

        public int Height { get; }
    }
}