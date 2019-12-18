using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day11.Day11Part1.PaintingRobot
{
    public class EmergencyHullPaintingRobot
    {
        private PaintingColors DefaultColor = PaintingColors.Black;
        public Dictionary<int, Dictionary<int, Panel>> Canvas;
        private Head _head;
        private List<Panel> _allPanels;

        public int NbrOfPanelsPainted => _allPanels.Count;

        public EmergencyHullPaintingRobot()
        {
            Canvas = new Dictionary<int, Dictionary<int, Panel>>();
            _head = new Head { X = 0, Y = 0, Direction = Direction.Up };
            _allPanels = new List<Panel>();
        }

        //public static EmergencyHullPaintingRobot RunIntcode()
        //{

        //}

        public string ShowDrawing()
        {
            var minX = -2; var minY = -2;
            var maxX = 2; var maxY = 2;

            var sb = new StringBuilder();
            for (var y = maxY; y >= minY; y--)
            {
                sb.AppendLine();
                for (var x = minX; x <= maxX; x++)
                {
                    var panel = Panel(x, y);
                    var isHead = IsHeadAt(x, y);
                    sb.Append(isHead
                        ? ShowHeadOnDrawing()
                        : (panel == null || panel.Color==PaintingColors.White) ? "." : "#");
                }
            }
            return sb.ToString();
        }

        public void OutputAndMove(int color, int moveDirection)
        {
            var panel = Panel(_head.X, _head.Y);
            if (panel == null)
            {
                panel = AddPanel(_head.X, _head.Y);
            }
            panel.Color = color == 0 ? PaintingColors.White : color == 1 ? PaintingColors.Black : throw new NotImplementedException();

            switch (_head.Direction)
            {
                case Direction.Up:
                    switch (moveDirection)
                    {
                        case 0: // move left
                            _head.X -= 1;
                            _head.Direction = Direction.Left;
                            break;
                        case 1: // move right
                            _head.X += 1;
                            _head.Direction = Direction.Right;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Left:
                    switch (moveDirection)
                    {
                        case 0: // move left
                            _head.Y -= 1;
                            _head.Direction = Direction.Down;
                            break;
                        case 1: // move right
                            _head.Y += 1;
                            _head.Direction = Direction.Up;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Down:
                    switch (moveDirection)
                    {
                        case 0: // move left
                            _head.X += 1;
                            _head.Direction = Direction.Right;
                            break;
                        case 1: // move right
                            _head.X -= 1;
                            _head.Direction = Direction.Left;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Right:
                    switch (moveDirection)
                    {
                        case 0: // move left
                            _head.Y += 1;
                            _head.Direction = Direction.Up;
                            break;
                        case 1: // move right
                            _head.Y -= 1;
                            _head.Direction = Direction.Down;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                default: throw new NotImplementedException($"moveDirection: from {_head.Direction}");
            }
        }

        private Panel AddPanel(int x, int y)
        {
            var panel = new Panel { X = x, Y = y };
            if (!Canvas.ContainsKey(panel.X)) Canvas[panel.X]=new Dictionary<int, Panel>();
            if (!Canvas[panel.X].ContainsKey(panel.Y))
            {
                Canvas[panel.X][panel.Y] = panel;
            }
            _allPanels.Add(panel);
            return panel;
        }

        private string ShowHeadOnDrawing()
        {
            switch (_head.Direction)
            {
                case Direction.Up:
                    return "^";
                case Direction.Right:
                    return ">";
                case Direction.Down:
                    return "v";
                case Direction.Left:
                    return "<";
                default:
                    throw new NotImplementedException();
            }
        }

        private bool IsHeadAt(int x, int y)
        {
            return (_head.X == x && _head.Y == y);
        }

        private Panel Panel(int x, int y)
        {
            if (!Canvas.ContainsKey(x)) return null;
            if (!Canvas[x].ContainsKey(y)) return null;

            return Canvas[x][y];
        }
    }
    public class Head
    {
        //public Panel Current { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
    public class Panel
    {
    public int X { get; set; }
    public int Y { get; set; }
    public PaintingColors Color { get; set; }
    }
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public enum PaintingColors
    {
        Black,
        White,
    }
}
