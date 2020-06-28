using System;

namespace MapTiler
{
    [Serializable]
    public class Point
    {
        public int x;
        public int y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public Point (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Origin ()
        {
            return new Point();
        }

        public static Point Up ()
        {
            return new Point(0, 1);
        }

        public static Point Down()
        {
            return new Point(0, -1);
        }

        public static Point Left()
        {
            return new Point(-1, 0);
        }

        public static Point Right()
        {
            return new Point(1, 0);
        }

        public static Point operator+ (Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator- (Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
    }
}
