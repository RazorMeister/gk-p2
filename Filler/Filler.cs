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
            List<int> ind;
            int yMin, yMax;
            ind = Filler.SortVertices(points, out yMin, out yMax);

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

                        if (points[prev].Y > points[curr].Y) 
                            AET.Add(new NodeAET(points[prev], points[curr], y));
                        else if (points[prev].Y < points[curr].Y)
                            AET.RemoveAll(node => 
                                (node.a == points[prev] && node.b == points[curr]) || (node.a == points[curr] && node.b == points[prev])
                            );

                        int next = (ind[i] + 1) % ind.Count;

                        if (points[next].Y > points[curr].Y) 
                            AET.Add(new NodeAET(points[next], points[curr], y));
                        else if (points[next].Y < points[curr].Y) 
                            AET.RemoveAll(node => 
                                (node.a == points[next] && node.b == points[curr]) || (node.a == points[curr] && node.b == points[next])
                            );
                    }
                }

                
                AET.Sort((NodeAET a, NodeAET b) =>
                {
                    if (a.x == b.x) return 0;
                    if (a.x < b.x) return -1;
                    return 1;
                });

                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    int xMin = (int)AET[i].x;
                    int xMax = (int)AET[i + 1].x;

                    for (int x = xMin; x < xMax; x++)
                        callback(x, y);
                }

                foreach (NodeAET node in AET)
                    node.UpdateX(y);
            }
        }

        private static List<int> SortVertices(List<Point> points, out int yMin, out int yMax)
        {
            List<int> sortedIndexes = new List<int>();
            for (int i = 0; i < points.Count(); i++)
                sortedIndexes.Add(i);

            sortedIndexes.Sort((int idx1, int idx2) =>
            {
                if (points[idx1].Y == points[idx2].Y) return 0;
                if (points[idx1].Y < points[idx2].Y) return -1;
                return 1;
            });

            yMin = points[sortedIndexes[0]].Y;
            yMax = points[sortedIndexes[sortedIndexes.Count - 1]].Y;

            return sortedIndexes;
        }
    }
}
