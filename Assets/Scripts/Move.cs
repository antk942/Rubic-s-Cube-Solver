using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RubicsCubeNS;

namespace MoveNS {
    public struct Move
    {
        public Vector2Int direction;
        public int line;
        public RubicsCube.Sides side;

        public Move(Vector2Int direction, int line, RubicsCube.Sides side)
        {
            this.direction = direction;
            this.line = line;
            this.side = side;
        }
    }
}
