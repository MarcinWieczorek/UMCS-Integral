namespace MarcinWieczorek.Model {
    using System;

    public enum AreaType {
        Rectangle,
        Trapezoid,
    }

    public class SingleCount {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public int n { get; set; }
        public AreaType areaType { get; set; }
        public double area { get; set; }
        public int calculationNumber { get; set; }
        public int lowestN { get; set; }
        public double MinSquareError { get; set; }
        public mFunction f { get; set; }

        public delegate double mFunction(double x);

        public SingleCount(double x1, double x2, mFunction f) {
            this.x1 = x1;
            this.x2 = x2;
            this.f = f;
        }

        public void integrate(AreaType areaType) {
            string t;
            if(areaType == AreaType.Rectangle) {
                integrateRectangle();
                t = "rectangle";
            }
            else {
                integrateTrapezoid();
                t = "trapezoid";
            }
            Console.Out.WriteLine("Integral " + t + " [" + x1 + ", " + x2 + "] * " + n + " = " + area);
        }

        private void integrateRectangle() {
            this.area = 0;
            double step = (x2 - x1) / n;

            for(int i = 0; i < this.n; i++) {
                this.area += f(x1 + i * step) * step;
            }
        }

        private void integrateTrapezoid() {
            this.area = 0;
            double step = (x2 - x1) / n;

            for(int i = 0; i < this.n; i++) {
                area += (f(x1 + i * step) + f(x1 + (i + 1) * step)) * step / 2;
            }
        }
    }
}