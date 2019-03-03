using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmazHomework
{
    public class Segment
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public double Length { get
            {
                double length = (X2 - X1) * (X2 - X1) +
                    (Y2 - Y1) * (Y2 - Y1);
                length = Math.Sqrt(length);
                return length;
            } }

        public bool AreEqual(Segment other)
        {
            return other.X1 == X1 && other.X2 == X2 && other.Y1 == Y1 && other.Y2 == Y2;
        }

        public void Write()
        {
            Console.WriteLine("({0}, {1})", X1, Y1);
            Console.WriteLine("({0}, {1})", X2, Y2);
        }
    }

    public class GraphicPic
    {
        List<Segment> segments;

        public GraphicPic(string filename)
        {
            var array = filename.Split();
            segments = new List<Segment>();
            for (int i = 0; i < array.Length - 3; i += 4)
            {
                var segment = new Segment()
                {
                    X1 = int.Parse(array[i]),
                    Y1 = int.Parse(array[i+1]),
                    X2 = int.Parse(array[i+2]),
                    Y2 = int.Parse(array[i+3])
                };
                segments.Add(segment);
            }
        }

        public GraphicPic()
        {
            segments = new List<Segment>();
        }

        public void Show()
        {
            foreach (var seg in segments)
                seg.Write();
        }
        public void Insert(Segment segment)
        {
            bool check = false;
            foreach (var e in segments)
                if (e.AreEqual(segment)) check = true;
            if (!check)
                segments.Add(segment);
        }

        public GraphicPic angleList()
        {
            var graphicPic = new GraphicPic();
            foreach (var e in segments)
                if ((e.X2 - e.X1) == (e.Y2 - e.Y1) ||
                    (e.X2 - e.X1) / 2 == (e.Y2 - e.Y1))
                    graphicPic.segments.Add(e);
            return graphicPic;
        }

        public GraphicPic lengthList(int a, int b)
        {
            var graphicPic = new GraphicPic();
            foreach (var e in segments)
                if (e.Length <= (b - a))
                    graphicPic.segments.Add(e);

            return graphicPic;
        }

        public void Sort()
        {

        }
    }
}
