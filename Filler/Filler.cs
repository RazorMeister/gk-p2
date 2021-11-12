using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GK_P2.Bitmap;

namespace GK_P2.Filler
{
    class Filler
    {
        public static void FillPolygon(
            List<Point> points, Color color, 
            AbstractBitmap bm, 
            Func<int, int, Color> getColorFunc = null,
            Func<int, int, PixelStruct> getPixelStructFunc = null
        ) {
            List<int> ind;
            int yMin, yMax;
            ind = Filler.SortVertices(points, out yMin, out yMax);

            // Algorytm scanlinii
            List<NodeAET> AET = new List<NodeAET>();

            for (int y = yMin; y <= yMax; y++) // y - numer scanlinii
            {
                // Zaktualizowanie wierzchołków
                for (int i = 0; i < ind.Count; i++)
                {
                    int curr = ind[i]; // aktualny wierzchołek
                    if (points[curr].Y == y - 1) // Wierzchołek leży na poprzedniej scanlinii
                    {
                        int prev = (ind[i] - 1); // poprzedni wierzchołek
                        if (prev < 0) prev = ind.Count - 1;

                        if (points[prev].Y > points[curr].Y) 
                            AET.Add(new NodeAET(points[prev], points[curr], y));
                        else if (points[prev].Y < points[curr].Y)
                            AET.RemoveAll(node => (node.a == points[prev] && node.b == points[curr]) || (node.a == points[curr] && node.b == points[prev]));

                        int next = (ind[i] + 1) % ind.Count; // następny wierzchołek
                        if (points[next].Y > points[curr].Y) 
                            AET.Add(new NodeAET(points[next], points[curr], y));
                        else if (points[next].Y < points[curr].Y) 
                            AET.RemoveAll(node => (node.a == points[next] && node.b == points[curr]) || (node.a == points[curr] && node.b == points[next]));
                    }
                }

                // Posortowanie w kolejności rosnących X
                AET.Sort((NodeAET a, NodeAET b) =>
                {
                    if (a.x == b.x) return 0;
                    else if (a.x < b.x) return -1;
                    else return 1;
                });

                // Wypełnienie pikseli pomiędzy kolejnymi krawędziami (0-1, 2-3, ...)
                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    int xMin = (int)AET[i].x;
                    int xMax = (int)AET[i + 1].x;

                    for (int x = xMin; x < xMax; x++)
                    {
                        if (bm.GetType() == typeof(FastBitmap))
                            bm.SetPixel(x, y, getColorFunc != null ? getColorFunc(x, y) : color);
                        else
                            ((CudaBitmap)bm).SetPixel(x, y, getPixelStructFunc(x, y));
                    }
                }

                // Uaktualnienie wartości x dla nowej scanlinii
                foreach (NodeAET node in AET)
                {
                    node.UpdateX(y);
                }
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
