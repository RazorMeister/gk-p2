using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GK_P2.Bitmap;

namespace GK_P2.Filler
{
    public static class Filler
    {
        public static void FillPolygon(
            List<Point> points, 
            Action<int, int> callback
        ) {
            int yMin, yMax;
            List<int> ind = Filler.SortVertices(points, out yMin, out yMax);
            List<NodeAET> AET = new List<NodeAET>();

            for (int y = yMin; y <= yMax; y++)
            {
                for (int i = 0; i < ind.Count; i++)
                {
                    int curr = ind[i];

                    if (points[curr].Y == y - 1)
                    {
                        int prev = (ind[i] - 1);
                        if (prev < 0) prev = ind.Count - 1;

                        if (points[prev].Y < points[curr].Y)
                            AET.RemoveAll(node =>
                                (node.A == points[prev] && node.B == points[curr]) || (node.A == points[curr] && node.B == points[prev])
                            );
                        else if (points[prev].Y > points[curr].Y)
                            AET.Add(new NodeAET(points[prev], points[curr], y));


                        int next = (ind[i] + 1) % ind.Count;

                        if (points[next].Y < points[curr].Y)
                            AET.RemoveAll(node =>
                                (node.A == points[next] && node.B == points[curr]) || (node.A == points[curr] && node.B == points[next])
                            );
                        else if (points[next].Y > points[curr].Y)
                            AET.Add(new NodeAET(points[next], points[curr], y));
                    }
                }


                AET.Sort((NodeAET a, NodeAET b) => a.X.CompareTo(b.X));

                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    int xMin = (int)AET[i].X;
                    int xMax = (int)AET[i + 1].X;

                    for (int x = xMin; x < xMax; x++)
                        callback(x, y);
                }

                AET.ForEach(node => node.SetX(y));
            }
        }

        private static List<int> SortVertices(List<Point> points, out int yMin, out int yMax)
        {
            List<int> sortedIndexes = new List<int>();
            
            for (int i = 0; i < points.Count(); i++)
                sortedIndexes.Add(i);

            sortedIndexes.Sort((int a, int b) => points[a].Y.CompareTo(points[b].Y));

            yMin = points[sortedIndexes[0]].Y;
            yMax = points[sortedIndexes.Last()].Y;

            return sortedIndexes;
        }
    }
}
