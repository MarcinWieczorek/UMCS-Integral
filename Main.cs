using System;
using System.Drawing;
using System.Windows.Forms;
using MarcinWieczorek.Model;

public class MarcinWieczorekMain : Form {
    public static Random random = new Random();

    static public void Main() {
        Application.Run(new MarcinWieczorekMain());
    }

    public MarcinWieczorekMain() {
        this.Size = new Size(420, 360);

        // Tabs
        TabControl tc = new TabControl();
        tc.Name = "Select Exercise";
        tc.Size = new Size(400, 320);
        tc.TabIndex = 0;

        tc.TabPages.Add(new Exercise1());
        tc.TabPages.Add(new Exercise2());
        tc.TabPages.Add(new Exercise3());
        tc.TabPages.Add(new Exercise4());
        tc.TabPages.Add(new Exercise5());
        tc.TabPages.Add(new Exercise6());
        tc.TabPages.Add(new Exercise7());
        tc.TabPages.Add(new Exercise8());
        Controls.Add(tc);
    }
}
