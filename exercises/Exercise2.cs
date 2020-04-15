using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise2 : Exercise {
    private int x1 = 0;
    private int x2 = 100;
    private const double validIntegral = 25000000;
    private SingleCount sc;

    // GUI
    private TextBox textBoxZ;

    public Exercise2(): base("2") {
        this.sc = new SingleCount(x1, x2, functionCube);
        this.textBoxZ = addParameter("z", 5);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int z = validateInt("z", this.textBoxZ);
            int rectangleN = 0;
            int trapezoidN = 0;
            bool foundRectangle = false;
            bool foundTrapezoid = false;
            double targetDiff = validIntegral * (z / 100.0);

            for(int ni = 1; ni < 100000; ni++) {
                sc.n = ni;

                if(!foundRectangle) {
                    sc.integrate(AreaType.Rectangle);
                    
                    if(Math.Abs(sc.area - validIntegral) == targetDiff) {
                        foundRectangle = true;
                        rectangleN = sc.n;
                    }
                }

                if(!foundTrapezoid) {
                    sc.integrate(AreaType.Trapezoid);
                    
                    if(Math.Abs(sc.area - validIntegral) == targetDiff) {
                        foundTrapezoid = true;
                        trapezoidN = sc.n;
                    }
                }

                if(foundRectangle && foundTrapezoid) {
                    break;
                }
            }

            if(foundRectangle && foundTrapezoid) {
                resultLabel.Text = "Rectangle: " + rectangleN + "\nTrapezoid: " + trapezoidN;
            }
            else {
                resultLabel.Text = "Failed to find the result. Please change your parameters.";
            }
        }
        catch(System.Exception) {}
    }
}