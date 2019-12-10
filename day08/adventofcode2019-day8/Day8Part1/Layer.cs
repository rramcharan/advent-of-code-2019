using System.Text;

namespace adventofcode2019_day8.Day8Part1
{
    public class Layer
    {
        private int _width;
        private int _height;
        public int[] Map { get; private set; }
        public int[] CountDigits { get; private set; }
        /// <summary>
        /// Number of the layer. Layer numbers start with '1'
        /// </summary>
        public int LayerNumber { get; private set; }

        public Layer(int layerNumber, int width, int height)
        {
            LayerNumber = layerNumber;
            _width = width;
            _height = height;
            Map = new int[_width * _height];
            CountDigits = new int[10];
            for (var idx = 0; idx < 10; idx++) CountDigits[idx] = 0;
        }

        public void AddDigit(int idx, int digit)
        {
            Map[idx] = digit;
            CountDigits[digit]++;
        }

        public string ToText()
        {
            var sb = new StringBuilder();
            for (var idx = 0; idx < _width * _height; idx++)
            {
                sb.Append($"{Map[idx]}");
                if ((idx + 1) % _width == 0)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}