namespace AdventOfCode2019.Day8
{
    using System;
    using System.Collections.Generic;

    public class EncodedSpaceImage
    {
        public EncodedSpaceImage(string imageData, int width, int height)
        {
            var layers = new List<ImageLayer>();

            var layerLength = width * height;
            var layerIndex = 0;
            while (imageData.Length >= layerLength)
            {
                layers.Add(new ImageLayer(layerIndex++, imageData.Substring(0, layerLength), width, height));
                imageData = imageData.Substring(layerLength);
            }

            Layers = new ImageLayers(layers);
            Width = width;
            Height = height;
        }

        public ImageLayers Layers { get; }

        public int Width { get; }

        public int Height { get; }
    }
}