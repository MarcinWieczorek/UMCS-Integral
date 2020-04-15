using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise4 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;

    // GUI
    private TextBox textBoxK;
    private TextBox textBoxZ;
    private TextBox textBoxX1;
    private TextBox textBoxX2;

    public Exercise4(): base("4") {
        this.sc = new SingleCount(0, 0, functionCube);
        textBoxK = addParameter("k", 4);
        textBoxZ = addParameter("z", 13);
        textBoxX1 = addParameter("x1", 0);
        textBoxX2 = addParameter("x2", 100);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int k = validateInt("k", this.textBoxK);
            int z = validateInt("z", this.textBoxZ);
            int x1 = validateInt("x1", this.textBoxX1);
            int x2 = validateInt("x2", this.textBoxX2);

            sc.n = (int) Math.Pow(10, k);
            
            sc.x1 = x1;
            sc.x2 = x2;

            // Results will be stored here
            bool foundRectangle = false;
            bool foundTrapezoid = true;
            double rectangleX1 = 0, rectangleX2 = 0;
            double trapezoidX1 = 0, trapezoidX2 = 0;
            
            for(int i = 0; i < sc.n; i++) {
                sc.integrate(AreaType.Rectangle);
                if(Math.Truncate(sc.area) % z == 0) {
                    rectangleX1 = sc.x1;
                    rectangleX2 = sc.x2;
                    foundRectangle = true;
                }

                // Trapezoid
                sc.integrate(AreaType.Trapezoid);
                if(Math.Truncate(sc.area) % z == 0) {
                    trapezoidX1 = sc.x1;
                    trapezoidX2 = sc.x2;
                    foundTrapezoid = true;
                }

                if(foundRectangle && foundTrapezoid) {
                    break;
                }

                sc.x1 += 1;
                sc.x2 -= 1;

                if(sc.x1 > x2 || sc.x2 < x1) {
                    break;
                }
            }

            resultLabel.Text = "Rectangle: " + rectangleX1 + ", " + rectangleX2
                + "\nTrapezoid: " + trapezoidX1 + ", " + trapezoidX2;
        }
        catch(System.Exception) {}
    }
}
