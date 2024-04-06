using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Go.ALPR.Sri.Tests
{

    public partial class frmPicture : Form
    {
        public string Titulo { get; set; }

        public string Path { get; set; }

        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        public frmPicture()
        {
            InitializeComponent();
        }

        private void frmPicture_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;
            picCamara.Image = Image.FromFile(Path);
        }

        private void picCamara_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            panning = true;
            startingPoint = new Point(e.Location.X - movingPoint.X,
                                      e.Location.Y - movingPoint.Y);
        }

        private void picCamara_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
            Cursor = Cursors.Default;
        }

        private void picCamara_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                movingPoint = new Point(e.Location.X - startingPoint.X,
                                        e.Location.Y - startingPoint.Y);
                picCamara.Invalidate();
            }
        }

        private void picCamara_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(picCamara.Image, movingPoint);
        }
    }
}
