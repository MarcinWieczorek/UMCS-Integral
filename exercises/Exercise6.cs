using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MarcinWieczorek.Model;

public class Exercise6 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;
    private SingleCount sc2;

    // GUI
    private TextBox textBoxM;
    private TextBox textBoxK;

    public Exercise6(): base("6") {
        sc = new SingleCount(0, 0, functionCube);
        sc2 = new SingleCount(0, 0, functionSquare);
        textBoxM = addParameter("m", 10);
        textBoxK = addParameter("k", 3);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int m = validateInt("m", this.textBoxM);
            int k = validateInt("k", this.textBoxK);

            int n = (int) Math.Pow(10, k);
            sc.n = n;
            sc2.n = n;

            double resultRectangle = 9999999;
            double resultTrapezoid = 9999999;

            for(int i = 0; i < m; i++) {
                sc.x1 = (int) MarcinWieczorekMain.random.Next(0, 100);
                sc.x2 = (int) MarcinWieczorekMain.random.Next(0, 100);               
                sc2.x1 = (int) MarcinWieczorekMain.random.Next(0, 100);
                sc2.x2 = (int) MarcinWieczorekMain.random.Next(0, 100);               

                sc.integrate(AreaType.Rectangle);
                sc2.integrate(AreaType.Rectangle);
                double diff = Math.Abs(sc.area - sc2.area);
                if(diff < resultRectangle) {
                    resultRectangle = diff;
                }

                sc.integrate(AreaType.Trapezoid);
                sc2.integrate(AreaType.Trapezoid);
                diff = Math.Abs(sc.area - sc2.area);
                if(diff < resultTrapezoid) {
                    resultTrapezoid = diff;
                }
            }

            resultLabel.Text = "Rectangle: " + resultRectangle
                + "\nTrapezoid: " + resultTrapezoid;
        }
        catch(System.Exception) {}
    }
}
