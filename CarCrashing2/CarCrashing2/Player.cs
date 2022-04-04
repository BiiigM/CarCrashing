using System.Drawing;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace CarCrashing2
{
    public class Player
    {
        public Row lastRow { get; set; }
        public int positon { get; private set; }
        private Timer GameLoop;
        private Game _game;

        public Player(Row lastRow, Timer gameLoop, Game game)
        {
            this.lastRow = lastRow;
            GameLoop = gameLoop;
            _game = game;
        }

        public void Spawn()
        {
            lastRow.Panels[this.lastRow.Panels.Count/2].BackColor = Color.Red;
            positon = this.lastRow.Panels.Count / 2;
        }

        public void Move(int move)
        {
            if(positon + move < 0 || positon + move >= lastRow.Panels.Count) 
                return;
            
            foreach (Panel lastRowPanel in lastRow.Panels)
            {
                if(lastRowPanel.BackColor == Color.Green) return;
            }
            
            foreach (Panel lastRowPanel in lastRow.Panels)
            {
                lastRowPanel.BackColor = Color.Gray;
            }
            
            lastRow.Panels[positon + move].BackColor = Color.Red;
            positon += move;
        }

        public void Collision(Obstacle lastObstacle)
        {
            if (lastObstacle.freeSpot == positon || lastObstacle.freeSpot2 == positon) return;
            GameLoop.Stop();
            DialogResult dr = MessageBox.Show($"Game Over\nScore: {_game.Score}", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            if (dr == DialogResult.Retry)
            {
                _game.Reset();
            }
            else
            {
                _game.Close();
            }
        }
    }
}