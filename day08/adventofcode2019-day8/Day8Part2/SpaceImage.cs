using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019_day8.Day8Part2
{
    public class SpaceImage
    {
        private int _width;
        private int _height;
        public Dictionary<int, Layer> Layers { get; private set; }

        private SpaceImage(int width, int height, int[] digits)
        {
            if (width <= 0) throw new ArgumentException($"Width shouls be at least 1.", nameof(width));
            if (height <= 0) throw new ArgumentException($"Height shouls be at least 1.", nameof(height));
            if (digits.Length == 0) throw new ArgumentException($"No digits specified.", nameof(digits));

            if ((digits.Length % (width * height)) != 0)
                throw new Exception($"dimension {width} x {height} != {digits.Length}");

            _width = width;
            _height = height;
            Layers = new Dictionary<int, Layer>();

            SetLayers(digits);
        }

        public Layer LayerWithLeast(int digit)
        {
            var sortedLayers = Layers.Values.OrderBy(l => l.CountDigits[digit]).ToArray();
            var first = sortedLayers[0];
            if (first.CountDigits[digit] >= sortedLayers[1].CountDigits[digit])
                throw new Exception($"Layer with the least number of '{digit}' digits not found.");

            return first;
        }

        private void SetLayers(int[] digits)
        {
            var countOnLayer = _width * _height;
            for (var idx = 0; idx < digits.Length; idx += countOnLayer)
            {
                var layer = new Layer(Layers.Count + 1, _width, _height);
                Layers.Add(Layers.Count, layer);
                for (var idx2 = 0; idx2 < countOnLayer; idx2++)
                    layer.AddDigit(idx2, digits[idx + idx2]);
            }
        }

        public static SpaceImage Load(int width, int height, string text)
        {
            var digits = new List<int>();
            foreach (char c in text)
            {
                digits.Add(Convert.ToInt32(c - 48));
            }
            return Load(width, height, digits.ToArray());
        }
        public static SpaceImage Load(int width, int height, int[] digits)
        {
            var image = new SpaceImage(width, height, digits);
            return image;
        }

        public int AntiCorruptionNumber()
        {
            var layer = LayerWithLeast(0);
            var nbrOf1 = layer.CountDigits[1];
            var nbrOf2 = layer.CountDigits[2];

            return nbrOf1 * nbrOf2;
        }
    }
}