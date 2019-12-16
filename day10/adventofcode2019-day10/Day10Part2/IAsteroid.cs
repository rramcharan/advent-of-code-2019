﻿using System.Collections.Generic;

namespace adventofcode2019_day10.Day10Part2
{
    public interface IAsteroid
    {
        bool IsAsteroid { get; }
        int X { get; }
        int Y { get; }
        string Label { get; }

        int NbrOfVisibleAsteroids { get; }
    }
}