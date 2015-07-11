//Refactor the following code to use proper variable naming and simplified expressions:

//public class Size
//{
//    public double wIdTh, Viso4ina;
//    public Size(double w, double h)
//    {
//        this.wIdTh = w;
//        this.Viso4ina = h;
//    }

//    public static Size GetRotatedSize(
//        Size s, double angleOfTheFigureThatWillBeRotaed)
//    {
//        return new Size(
//            Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
//                Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina,
//            Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
//                Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);
//    }
//}

namespace RefactorClassesAndMethods
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Size GetRotatedSize(Size size, double angle)
        {
            var currentCos = Math.Abs(Math.Cos(angle));
            var currentSin = Math.Abs(Math.Sin(angle));
            var currentWidth = (currentCos * size.Width) + (currentSin * size.Height);
            var currentHeight = (currentSin * size.Width) + (currentCos * size.Height);
        
            return new Size(currentWidth, currentHeight);
        }
    }
}
