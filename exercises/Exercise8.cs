using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise8 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;

    // GUI
    private TextBox textBoxZ;

    public Exercise8(): base("8") {
        this.sc = new SingleCount(0, 100, f);
        textBoxZ = addParameter("z", 0);
    }

    private double f(double x) {
        return Math.Cos(x);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int z = validateInt("z", this.textBoxZ);
            resultLabel.Text = "Result: ";
        }
        catch(System.Exception) {}
    }
}
