using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise7 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;

    // GUI
    private TextBox textBoxX1;
    private TextBox textBoxX2;
    private TextBox textBoxZ;

    public Exercise7(): base("7") {
        this.sc = new SingleCount(0, 100, functionSquare);

        textBoxX1 = addParameter("x1", 0);
        textBoxX2 = addParameter("x2", 100);
        textBoxZ = addParameter("z", 2);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int z = validateInt("z", this.textBoxZ);
            int x1 = validateInt("x1", this.textBoxX1);
            int x2 = validateInt("x2", this.textBoxX2);

            sc.x1 = x1;
            sc.x2 = x2;

            // Results will be stored here
            bool foundRectangle = false;
            bool foundTrapezoid = false;

            int rectangleN = 0;
            int trapezoidN = 0;
            
            while(true) {
                sc.n = MarcinWieczorekMain.random.Next(0, 10000);

                // Rectangle
                if(!foundRectangle) {
                    sc.integrate(AreaType.Rectangle);
                    if(Math.Truncate(sc.area) % z == 0) {
                        rectangleN = sc.n;
                        foundRectangle = true;
                    }
                }

                // Trapezoid
                if(!foundTrapezoid) {
                    sc.integrate(AreaType.Trapezoid);
                    if(Math.Truncate(sc.area) % z == 0) {
                        trapezoidN = sc.n;
                        foundTrapezoid = true;
                    }
                }

                if(foundRectangle && foundTrapezoid) {
                    break;
                }
            }

            resultLabel.Text = "Rectangle: " + rectangleN
                + "\nTrapezoid: " + trapezoidN;
        }
        catch(System.Exception) {}
    }
}
