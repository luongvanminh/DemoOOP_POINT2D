using System;

namespace DemoPoint2D
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Point2D p2D = new Point2D(1, 1);
            bool val = p2D.isOrigin();

            Console.WriteLine($"kiem tra p2D nam o goc toa do: {val}");

            p2D.Move(0, 0);
            val = p2D.isOrigin();
            Console.WriteLine($"kiem tra p2D nam o goc toa do: {val}");

            /*
            Line mLine = new Line(new Point2D(0, 5), new Point2D(5, 0));
            mLine.Center().PrintPoint();
            //mLine.PrintLine();

            Triangle mTriangle = new Triangle(
                new Point2D(0, 5),
                new Point2D(3, -4),
                new Point2D(-3, -4)
                );

            mTriangle.Center().PrintPoint();
            */

            Shape mShape;
            mShape = new Shape();
            int code = 0;
            while (code != 3)
            {
                Console.WriteLine("Vui long chon loai (1)line (2)trigangle (3)exit:");
                code = Int32.Parse(Console.ReadLine());
                switch (code)
                {
                    case 1:
                        mShape = new Line(new Point2D(0, 5), new Point2D(5, 0));
                        break;
                    case 2:
                        mShape = new Triangle(
                                            new Point2D(0, 5),
                                            new Point2D(3, -4),
                                            new Point2D(-3, -4)
                                            );
                        break;
                    default:
                        code = 3;
                        break;
                }
            }
            mShape.Center().PrintPoint();
        }

    }

    class Point2D
    {

        private double _x;  // the x field
        public double X
        {
            get => _x;
            set => _x = value;
        }

        private double _y;  // the x field
        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public Point2D(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;

            isOrigin = () => X == 0 && Y == 0 ? true : false;
            // isOrigin = delegate() {
            //       return X == 0 && Y == 0 ? true : false;
            // };

            Move = (double newX, double newY) =>
            {
                X = newX;
                Y = newY;
            };
        }

        //public bool isOrigin()
        //{
        //    if (X == 0 && Y == 0)
        //        return true;
        //    return false;
        //}

        public Func<double, double, bool> isOrigin2Agr = (double X, double Y) => X == 0 && Y == 0 ? true : false;
        public Func<bool> isOrigin;
        public Action<double, double, Point2D> MovePoint = (double x, double y, Point2D p) =>
        {
            p.X = x;
            p.Y = y;
        };

        public Action<double, double> Move;

        //{
        //    if (X == 0 && Y == 0)
        //        return true;
        //    return false;
        //};

        public void PrintPoint()
        {
            Console.WriteLine($"Toa doa x={X} y={Y}");
        }
    }

    class Line : Shape
    {
        private Point2D A;
        private Point2D B;

        public Line()
        {
            A = new Point2D();
            B = new Point2D();
        }

        public Line(Point2D p1, Point2D p2)
        {
            A = p1;
            B = p2;
        }

        public override Point2D Center()
        {
            return new Point2D((A.X+B.X) / 2, (A.Y+B.Y) / 2);
        }

        public void PrintLine()
        {
            A.PrintPoint();
            B.PrintPoint();
        }
    }

    class Triangle : Shape
    {
        private Point2D A;
        private Point2D B;
        private Point2D C;

        public Triangle()
        {
            A = new Point2D();
            B = new Point2D();
            C = new Point2D();
        }

        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            A = p1;
            B = p2;
            C = p3;
        }

        public override Point2D Center()
        {
            return new Point2D((A.X + B.X + C.X) / 3, (A.Y + B.Y + C.Y) / 3);
        }
    }

    class Shape
    {

        public virtual Point2D Center()
        {

            return new Point2D();
        }
    }
}
