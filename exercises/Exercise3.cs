using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class Exercise3 : Exercise {
    private const double validIntegral = 0;
    private SingleCount sc;

    // GUI
    private TextBox textBoxX1;
    private TextBox textBoxX2;

    public Exercise3(): base("3") {
        this.sc = new SingleCount(0, 100, functionSquare);
        textBoxX1 = addParameter("x1", 0);
        textBoxX2 = addParameter("x2", 100);
    }

    public override void buttonHandler(object sender, EventArgs e) {
        try {
            int x1 = validateInt("x1", this.textBoxX1);
            int x2 = validateInt("x2", this.textBoxX2);
            // double targetDiff = validIntegral * (z / 100.0);
            
            // for(int mi = 0; mi < m; mi++) {
            //     sc.n = MarcinWieczorekMain.random.Next(10, 100000);
            //     sc.integrate(AreaType.Rectangle);
            //     Console.Out.WriteLine("Result:" + sc.area);
            // }

            resultLabel.Text = "Result: ";
        }
        catch(System.Exception) {}
    }
}
