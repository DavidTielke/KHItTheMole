using System;
using System.Drawing;
using System.Windows.Forms;
using HitTheMole.Properties;

namespace HitTheMole
{
    public partial class MoleMain2 : Form
    {
        public readonly DoublePanel _panel;
        private bool _maximized;

        public MoleMain2()
        {
            _panel = new DoublePanel();
            _panel.Dock = DockStyle.Fill;
            _panel.Paint += Zeichnen;
            _panel.MouseDown += Schiessen;
            _panel.MouseMove += MausWirdBewegt;
            _panel.MouseUp += MaustasteLosgelassen;
            Controls.Add(_panel);

            KeyDown += TasteGedrückt;
            _maximized = true;
            InitializeComponent();

            Cursor.Hide();
        }

        private void MaustasteLosgelassen(object sender, MouseEventArgs e)
        {
            Game.MouseUp(e.X, e.Y);
        }

        private void MausWirdBewegt(object sender, MouseEventArgs e)
        {
            Game.MouseMove(e.X, e.Y);
        }

        private void NeuZeichnen(object sender, EventArgs e)
        {
            _panel.Invalidate();
        }
        private void Zeichnen(object sender, PaintEventArgs e)
        {
            Game.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game.Initialize(_panel);
            Game.Timer.Tick += NeuZeichnen;
            Game.Start();
        }
        
        private void Schiessen(object sender, MouseEventArgs e)
        {
            Game.MouseDown(new Point(e.X, e.Y));
            _panel.Invalidate();
        }
        
        private void TasteGedrückt(object sender, KeyEventArgs e)
        {
            Game.KeyDown(e.KeyCode);

            if (e.KeyCode != Keys.F11) return;
            if (_maximized)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Fixed3D;
                _panel.Invalidate();
                _maximized = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
                _panel.Invalidate();
                _maximized = true;
            }
        }
    }
}