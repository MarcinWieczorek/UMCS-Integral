using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise5 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;
    private SingleCount sc2;

    // GUI
    private TextBox textBoxK;

    public Exercise5(): base("5") {
        sc = new SingleCount(0, 0, functionCube);
        sc2 = new SingleCount(0, 0, functionSquare);
        textBoxK = addParameter("k", 1);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int k = validateInt("k", this.textBoxK);
            int n = (int) Math.Pow(10, k);
            sc.n = n;
            sc2.n = n;

            bool foundRectangle = false;
            bool foundTrapezoid = false;

            double rectangleX1F1 = 0, rectangleX2F1 = 0;
            double rectangleX1F2 = 0, rectangleX2F2 = 0;
            double trapezoidX1F1 = 0, trapezoidX2F1 = 0;
            double trapezoidX1F2 = 0, trapezoidX2F2 = 0;
            
            while(true) {
                sc.x1 = MarcinWieczorekMain.random.Next(0, 100);
                sc.x2 = MarcinWieczorekMain.random.Next(0, 100);
                sc2.x1 = MarcinWieczorekMain.random.Next(0, 100);
                sc2.x2 = MarcinWieczorekMain.random.Next(0, 100);

                if(!foundRectangle) {
                    sc.integrate(AreaType.Rectangle);
                    sc2.integrate(AreaType.Rectangle);

                    if(sc.area == sc2.area
                            && sc.x1 != sc2.x1
                            && sc.x2 != sc2.x2) {
                        foundRectangle = true;
                        rectangleX1F1 = sc.x1;
                        rectangleX2F1 = sc.x1;
                        rectangleX1F2 = sc2.x2;
                        rectangleX2F2 = sc2.x2;
                    }
                }

                if(!foundTrapezoid) {
                    sc.integrate(AreaType.Trapezoid);
                    sc2.integrate(AreaType.Trapezoid);

                    if(sc.area == sc2.area
                            && sc.x1 != sc2.x1
                            && sc.x2 != sc2.x2) {
                        foundTrapezoid = true;
                        trapezoidX1F1 = sc.x1;
                        trapezoidX2F1 = sc.x1;
                        trapezoidX1F2 = sc2.x2;
                        trapezoidX2F2 = sc2.x2;
                    }
                }

                if(foundRectangle && foundTrapezoid) {
                    break;
                }
            }

            if(foundRectangle && foundTrapezoid) {
                resultLabel.Text =
                    "Rectangle f1: " + rectangleX1F1 + ", " + rectangleX2F1
                    + "\nRectangle f2: " + rectangleX1F2 + ", " + rectangleX2F2
                    + "\nTrapezoid f1: " + trapezoidX1F1 + ", " + trapezoidX2F1
                    + "\nTrapezoid f2: " + trapezoidX1F2 + ", " + trapezoidX2F2;
            }
            else {
                resultLabel.Text = "Failed to find the result. Please change your parameters.";
            }
        }
        catch(System.Exception) {}
    }
}
