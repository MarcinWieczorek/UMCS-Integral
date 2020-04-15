using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise1 : Exercise {
    private const double validIntegral = 333333.333333;
    private SingleCount sc;

    // GUI
    private TextBox textBoxM;
    private TextBox textBoxZ;

    public Exercise1(): base("1") {
        this.sc = new SingleCount(0, 100, functionSquare);
        this.textBoxM = addParameter("m", 10);
        this.textBoxZ = addParameter("z", 5);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int m = validateInt("m", this.textBoxM);
            int z = validateInt("z", this.textBoxZ);
            double targetDiff = validIntegral * (z / 100.0);
            resultLabel.Text = "";
            
            for(int mi = 0; mi < m; mi++) {
                sc.n = MarcinWieczorekMain.random.Next(10, 100000);

                sc.integrate(AreaType.Rectangle);
                if(Math.Abs(validIntegral - sc.area) < targetDiff) {
                    resultLabel.Text += "Rectangle: " + sc.area + "\n";
                }

                sc.integrate(AreaType.Trapezoid);
                if(Math.Abs(validIntegral - sc.area) < targetDiff) {
                    resultLabel.Text += "Trapezoid: " + sc.area + "\n";
                }
            }
        }
        catch(System.Exception) {}
    }
}