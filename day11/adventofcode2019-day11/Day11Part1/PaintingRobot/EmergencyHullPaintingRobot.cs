using adventofcode2019_day11.Day11Part1.Enums;
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
        public IntCodeComputer Computer { get; private set; }

        public int NbrOfPanelsPainted => _allPanels.Count;

        public EmergencyHullPaintingRobot()
        {
            Canvas = new Dictionary<int, Dictionary<int, Panel>>();
            _head = new Head { X = 0, Y = 0, Direction = Direction.Up };
            _allPanels = new List<Panel>();
            MinX = -1;
            MaxX = 1;
            MinY = -1;
            MaxY = 1;
        }

        //public static EmergencyHullPaintingRobot RunIntcode()
        //{

        //}

        public string ShowDrawing()
        {
            var sb = new StringBuilder();
            for (var y = MaxY+1; y >= MinY-1; y--)
            {
                sb.AppendLine();
                for (var x = MinX-1; x <= MaxX+1; x++)
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

        public void OutputAndMove(long color, long moveDirection)
        {
            OutputAndMove(Convert.ToInt32(color), Convert.ToInt32(moveDirection));
        }
        
        public void OutputAndMove(int color, int moveDirection)
        {
            OutputAndMove((PaintingColors)color, (Direction)moveDirection);
        }

        public void OutputAndMove(PaintingColors color, Direction moveDirection)
        {
            //Console.WriteLine($"Move: {moveDirection}");
            var panel = Panel(_head.X, _head.Y);
            if (panel == null)
            {
                panel = AddPanel(_head.X, _head.Y);
            }
            panel.Color = color;// = color == Colors. ? PaintingColors.White : color == 1 ? PaintingColors.Black : throw new NotImplementedException();

            switch (_head.Direction)
            {
                case Direction.Up:
                    switch (moveDirection)
                    {
                        case Direction.Left:
                            _head.X -= 1;
                            _head.Direction = Direction.Left;
                            break;
                        case Direction.Right:
                            _head.X += 1;
                            _head.Direction = Direction.Right;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Left:
                    switch (moveDirection)
                    {
                        case Direction.Left:
                            _head.Y -= 1;
                            _head.Direction = Direction.Down;
                            break;
                        case Direction.Right:
                            _head.Y += 1;
                            _head.Direction = Direction.Up;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Down:
                    switch (moveDirection)
                    {
                        case Direction.Left:
                            _head.X += 1;
                            _head.Direction = Direction.Right;
                            break;
                        case Direction.Right:
                            _head.X -= 1;
                            _head.Direction = Direction.Left;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                case Direction.Right:
                    switch (moveDirection)
                    {
                        case Direction.Left:
                            _head.Y += 1;
                            _head.Direction = Direction.Up;
                            break;
                        case Direction.Right:
                            _head.Y -= 1;
                            _head.Direction = Direction.Down;
                            break;
                        default: throw new NotImplementedException($"moveDirection: {moveDirection}");
                    }
                    break;
                default: throw new NotImplementedException($"moveDirection: from {_head.Direction}");
            }
            //Console.WriteLine(ShowDrawing());
        }

        public static EmergencyHullPaintingRobot Process(long[] intCode)
        {
            var paintingRobot = new EmergencyHullPaintingRobot();
            paintingRobot.RunCode(intCode);
            return paintingRobot;
        }

        private void RunCode(long[] intCode)
        {
            Computer = IntCodeComputer.Create("PaintingRobot", intCode);
            do
            {
                Computer.Process();

                if (Computer.Output.Count > 0)
                {
                    if (Computer.Output.Count == 2)
                    {
                        OutputAndMove(Computer.Output[0], Computer.Output[1]);
                        Computer.Output.Clear();
                    }
                    else
                    {
                        throw new Exception($"Unexpected number of output (${Computer.Output.Count})received from int-computer.");
                    }
                }
                if (Computer.IsHalted)
                {
                    break;
                }
                if (Computer.IsWaitingForInput)
                {
                    var panel = Panel(_head.X, _head.Y);
                    var color = (panel==null)? PaintingColors.White : panel.Color;
                    var input = (color == PaintingColors.Black) ? 1L : 0L;
                    Computer.AddInput(input);

                }
            } while (!Computer.IsHalted);

        }

        private Panel AddPanel(int x, int y)
        {
            if (x < MinX) MinX = x;
            if (x > MaxX) MaxX = x;
            if (y < MinY) MinY = y;
            if (y > MaxY) MaxY = y;

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
        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }
        public int MaxY { get; private set; }
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
}
