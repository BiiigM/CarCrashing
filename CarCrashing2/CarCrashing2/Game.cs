using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace CarCrashing2
{
    public partial class Game : Form
    {
        public int _height { get; set; }
        public int _width { get; set; }

        private readonly Dictionary<int, Row> _rows = new Dictionary<int, Row>();
        public Player Player { get; private set; }
        public List<Obstacle> Obstacles { get; private set; }
        private Row lastRow;
        public Timer GameLoop { get; set; }
        
        public int Score { get; set; }
        
        public Game(int height, int width)
        {
            InitializeComponent();

            this._height = height;
            this._width = width;

            this.KeyDown += KeyPressed;
            this.KeyPreview = true;

            Obstacles = new List<Obstacle>();
            Score = 0;
            
            GameLoop = new Timer();
            GameLoop.Interval = 1000;
            GameLoop.Elapsed += GameLoopElapsed;
            GameLoop.Start();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    Player.Move(-1);
                    break;
                case Keys.Right:
                case Keys.D:
                    Player.Move(1);
                    break;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            PlayGroundSetup();
            lastRow = _rows[_height - 1];

            Obstacle obstacle = new Obstacle(_rows);
            obstacle.Generate();
            Obstacles.Add(obstacle);
            
            Player = new Player(lastRow, GameLoop, this);
            Player.Spawn();
        }

        private void GameLoopElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var obstacle in Obstacles)
            {
                obstacle.Move();
            }

            if (Obstacles[0].positon == _height - 1)
            {
                Player.Collision(Obstacles[0]);
            }
            
            if (Obstacles[0].killBool)
            {
                Obstacles.Remove(Obstacles[0]);
                Score++;
            }
            
            if (Obstacles[Obstacles.Count - 1].positon.Equals(2))
            {
                Obstacle obstacle = new Obstacle(_rows);
                obstacle.Generate();
                Obstacles.Add(obstacle);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < _rows.Count; i++)
            {
                foreach (var panel in _rows[i].Panels)
                {
                    panel.BackColor = Color.Gray;
                }
            }
            
            Obstacles.Clear();
            Player.Spawn();
            
            Obstacle obstacle = new Obstacle(_rows);
            obstacle.Generate();
            Obstacles.Add(obstacle);
            
            GameLoop.Start();
        }

        private void PlayGroundSetup()
        {
            //Create the Panels
            for (int i = 0; i < _height; i++)
            {
                CreateRow(i);
            }
            
            //Setup the size and location of all Panels
            containerControl1.Height = _height * 55 + 45;
            containerControl1.Width = _width * 55 + 22;
            
            this.Height = containerControl1.Height + 50;
            this.Width = containerControl1.Width + 100;

            containerControl1.Location = new Point((this.Width/2) - (containerControl1.Width/2), (this.Height/2) - (containerControl1.Height/2));
        }

        private void CreateRow(int i)
        {
            Panel[] panels = new Panel[_width];
            for (int j = 0; j < _width; j++)
            {
                Panel panel = new Panel {Size = new Size(55, 55)};
                panel.SetBounds(5 + j * panel.Width, 5 + i * panel.Height, 50, 50);
                panel.Name = j + "";
                panel.BackColor = Color.Gray;
                panels[j] = panel;
                containerControl1.Controls.Add(panel);
            }
            Row row = new Row(panels);
            _rows.Add(i, row);
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoop.Stop();
        }
    }
}