using _2DGame.Levels.LevelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.PathFinding
{
    class MatrixNode
    {
        class MatrixNode
        {
            public int fr = 0, to = 0, sum = 0;
            public int x, y;
            public MatrixNode parent;

            public static MatrixNode AStar(Tile[,] matrix, int fromX, int fromY, int toX, int toY)
            {
                // in this version an element in a matrix can move left/up/right/down in one step, two steps for a diagonal move.

                //the keys for greens and reds are x.ToString() + y.ToString() of the MatrixNode 
                Dictionary<string, MatrixNode> greens = new Dictionary<string, MatrixNode>(); //open 
                Dictionary<string, MatrixNode> reds = new Dictionary<string, MatrixNode>(); //closed 

                MatrixNode startNode = new MatrixNode { x = fromX, y = fromY };
                string key = startNode.x.ToString() + startNode.y.ToString();
                greens.Add(key, startNode);

                Func<KeyValuePair<string, MatrixNode>> smallestGreen = () =>
                {
                    KeyValuePair<string, MatrixNode> smallest = greens.ElementAt(0);

                    foreach (KeyValuePair<string, MatrixNode> item in greens)
                    {
                        if (item.Value.sum < smallest.Value.sum)
                            smallest = item;
                        else if (item.Value.sum == smallest.Value.sum
                                && item.Value.to < smallest.Value.to)
                            smallest = item;
                    }

                    return smallest;
                };


                //add these values to current node's x and y values to get the left/up/right/bottom neighbors
                List<KeyValuePair<int, int>> fourNeighbors = new List<KeyValuePair<int, int>>()
                                            { new KeyValuePair<int, int>(-1,0),
                                              new KeyValuePair<int, int>(0,1),
                                              new KeyValuePair<int, int>(1, 0),
                                              new KeyValuePair<int, int>(0,-1) };

                int maxY = matrix.GetLength(0);
                if (maxY == 0)
                    return null;
                int maxX = maxY;

                while (true)
                {
                    if (greens.Count == 0)
                        return null;

                    KeyValuePair<string, MatrixNode> current = smallestGreen();
                    if (current.Value.x == toX && current.Value.y == toY)
                        return current.Value;

                    greens.Remove(current.Key);
                    reds.Add(current.Key, current.Value);

                    foreach (KeyValuePair<int, int> plusXY in fourNeighbors)
                    {
                        int nbrX = current.Value.x + plusXY.Key;
                        int nbrY = current.Value.y + plusXY.Value;
                        string nbrKey = nbrX.ToString() + nbrY.ToString();
                        if (nbrX <= 0 || nbrY <= 0 || nbrX >= maxX || nbrY >= maxY
                            || matrix[nbrY, nbrX].TileType == Tile.Type.Platform
                            || reds.ContainsKey(nbrKey))
                            continue;

                        if (greens.ContainsKey(nbrKey))
                        {
                            MatrixNode curNbr = greens[nbrKey];
                            int from = Math.Abs(nbrX - fromX) + Math.Abs(nbrY - fromY);
                            if (from < curNbr.fr)
                            {
                                curNbr.fr = from;
                                curNbr.sum = curNbr.fr + curNbr.to;
                                curNbr.parent = current.Value;
                            }
                        }
                        else
                        {
                            MatrixNode curNbr = new MatrixNode { x = nbrX, y = nbrY };
                            curNbr.fr = Math.Abs(nbrX - fromX) + Math.Abs(nbrY - fromY);
                            curNbr.to = Math.Abs(nbrX - toX) + Math.Abs(nbrY - toY);
                            curNbr.sum = curNbr.fr + curNbr.to;
                            curNbr.parent = current.Value;
                            greens.Add(nbrKey, curNbr);
                        }
                    }
                }
            }
        }
}
