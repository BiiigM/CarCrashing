using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Timers;

namespace CarCrashing
{
    public partial class Form1 : Form
    {
        byte playerPosition;
        Random rnd = new Random();
        List<Panel> panels = new List<Panel>();
        Dictionary<Timer, int> timers = new Dictionary<Timer, int>();
        const int timerInterval = 1000;
        bool canPause = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MovePlayer);

            init();
        } 
        
        public void init()
        {
            label1.Visible = false;
            canPause = false;
            Timer secondRow = new Timer();
            secondRow.AutoReset = false;
            secondRow.Interval = timerInterval * 2;
            secondRow.Elapsed += (sender, args) => SpawnObstacle();
            secondRow.Elapsed += (sender, args) => canPause = true;
            secondRow.Elapsed += (sender, args) => label1.Visible = true;
            secondRow.Start();

            SpawnPlayer();
            SpawnObstacle();

            panels.Add(panel16);
            panels.Add(panel15);
            panels.Add(panel14);
            panels.Add(panel13);
            panels.Add(panel12);
            panels.Add(panel11);
            panels.Add(panel10);
            panels.Add(panel9);
            panels.Add(panel8);
            panels.Add(panel7);
            panels.Add(panel6);
            panels.Add(panel5);
            panels.Add(panel4);
            panels.Add(panel3);
            panels.Add(panel2);
            panels.Add(panel1);
        }

        private void SpawnPlayer()
        {
            playerPosition = 3;
            UpdatePlayerPanel();
        }

        private void MovePlayer(object sender, KeyEventArgs e)
        {
            if (panel1.BackColor.Equals(Color.Green) || panel2.BackColor.Equals(Color.Green) || panel3.BackColor.Equals(Color.Green) || panel4.BackColor.Equals(Color.Green))
            {
                return;
            }
            if((e.KeyCode == Keys.D) || (e.KeyCode == Keys.Right))
            {
                if(playerPosition < 4)
                {
                    playerPosition++;
                }
            }
            if ((e.KeyCode == Keys.A) || (e.KeyCode == Keys.Left))
            {
                if (playerPosition > 1)
                {
                    playerPosition--;
                }
            }

            if (e.KeyCode == Keys.Escape && canPause)
            {
                Credits();
            }

            UpdatePlayerPanel();
        }

        private void UpdatePlayerPanel()
        {
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel3.BackColor = Color.FromArgb(224, 224, 224);
            panel4.BackColor = Color.FromArgb(224, 224, 224);

            switch (playerPosition)
            {
                case 1:
                    panel1.BackColor = Color.Red;
                    break;
                case 2:
                    panel2.BackColor = Color.Red;
                    break;
                case 3:
                    panel3.BackColor = Color.Red;
                    break;
                case 4:
                    panel4.BackColor = Color.Red;
                    break;
            }
        }

        private void SpawnObstacle()
        {
            Timer atimer = new Timer();
            atimer.Interval = timerInterval;
            atimer.AutoReset = true;
            atimer.Elapsed += GameLoop;
            timers.Add(atimer, 4);
            atimer.Start();

            panel13.BackColor = Color.Green;
            panel14.BackColor = Color.Green;
            panel15.BackColor = Color.Green;
            panel16.BackColor = Color.Green;

            RandomGen();
        }

        private void RandomGen()
        {
            int random = rnd.Next(0, 100);

            if (random <= 25)
            {
                panel13.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if(random >= 25 && random <= 50)
            {
                panel14.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if (random >= 50 && random <= 75)
            {
                panel15.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if (random >= 75 && random <= 100)
            {
                panel16.BackColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void MoveObstacle(int line, Timer timer)
        {
            switch (line)
            {
                case 4:
                    MoveDown(line);
                    break;
                case 8:
                    MoveDown(line);
                    break;
                case 12:
                    MoveDown(line);
                    break;
                case 16:
                    MoveDown(line);
                    UpdatePlayerPanel();
                    break;
            }
            timers.Remove(timer);
            timers.Add(timer, line == 16 ? 4 : line + 4);
        }

        private void MoveDown(int line)
        {
            int freeSpot = 0;
            for (int i = line - 4; i < line; i++)
            {
                if (!panels[i].BackColor.Equals(Color.Green))
                {
                    freeSpot = i;
                }
                panels[i].BackColor = Color.FromArgb(224, 224, 224);
            }

            if (line == 16)
            {
                line = 0;
            }

            for (int i = line; i < line + 4; i++)
            {
                if(i == freeSpot + 4)
                {
                    continue;
                }
                panels[i].BackColor = Color.Green;
            }

            if (line == 0)
            {
                RandomGen();
            }

            if (line == 12)
            {
                Colusion(freeSpot);
            }
        }

        private void GameLoop(object sender, ElapsedEventArgs args)
        {
            int line;
            timers.TryGetValue(sender as Timer, out line);
            MoveObstacle(line, sender as Timer);
        }

        private void Colusion(int freeSpot)
        {
            int pos = playerPosition * -1 + 12;

            if (pos != freeSpot)
            {
                foreach (var timer in timers.Keys)
                {
                    timer.Stop();
                }

                timers.Clear();

                DialogResult result = MessageBox.Show("Game Over", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if(result == DialogResult.Retry)
                {
                    foreach (var panel in panels)
                    {
                        panel.BackColor = Color.FromArgb(224, 224, 224);
                    }

                    panels.Clear();
                    init();
                }
                if(result == DialogResult.Cancel)
                {
                    Invoke(new Action(() => this.Close()));
                }
            }
        }

        private void Credits()
        {
            foreach (var timer in timers.Keys)
            {
                timer.Stop();
            }

            timers.Clear();

            DialogResult result = MessageBox.Show("Made by: RussiaPlayer\nHelper: Taucher2003", "Credits", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                foreach (var panel in panels)
                {
                    panel.BackColor = Color.FromArgb(224, 224, 224);
                }

                panels.Clear();
                init();
            }
        }
    }
}
