using System;
using System.Drawing;
using System.Windows.Forms;

public abstract class Exercise : TabPage {
    protected Button button;
    protected Label resultLabel;
    protected int elementOffset = 10;

    public Exercise(string name): base(name) {
        button = new Button();
        button.Text = "Calculate!";
        button.Click += new EventHandler(buttonHandler);
        button.Location = new Point(120, 100);
        Controls.Add(button);

        // Result label
        resultLabel = new Label();
        resultLabel.Location = new Point(10, 130);
        resultLabel.Width = 200;
        resultLabel.Height = 200;
        Controls.Add(resultLabel);
    }

    public abstract void buttonHandler(object sender, EventArgs e);

    public int validateInt(string parameterName, TextBox tb) {
        try {
            return Int32.Parse(tb.Text);
        }
        catch(System.Exception) {
            MessageBox.Show("Parameter " + parameterName + " must be a valid integer.");
            throw;
        }
    }

    protected TextBox addParameter(string name, double initValue) {
        Label labelK = new Label();
        labelK.Text = name + ":";
        labelK.Location = new Point(10, elementOffset);
        Controls.Add(labelK);
        TextBox tb = new TextBox();
        tb.Text = initValue + "";
        tb.Location = new Point(120, elementOffset);
        Controls.Add(tb);
        elementOffset += 20;
        return tb;
    }

    protected double functionSquare(double x) {
        return x * x;
    }

    protected double functionCube(double x) {
        return x * x * x;
    }
}