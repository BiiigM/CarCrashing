using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarCrashing2
{
    public class Obstacle
    {
        public Row FirstRow { get; set; }
        public int freeSpot { get; set; }
        public int freeSpot2 { get; set; }
        public int positon { get; set; }
        private Random rnd;
        private Dictionary<int, Row> _rows;
        private bool twoFreespots;
        public bool killBool { get; private set; }

        public Obstacle(Dictionary<int, Row> rows)
        {
            FirstRow = rows[0];
            _rows = rows;
            positon = 0;
        }

        public void Generate()
        {
            RandomGen();
            foreach (Panel panel in FirstRow.Panels)
            {
                if (panel.Name.Contains(freeSpot + "") || (panel.Name.Contains(freeSpot2 + "") && twoFreespots))
                    continue;
                panel.BackColor = Color.Green;
            }
        }

        private void RandomGen()
        {
            freeSpot = -1;
            freeSpot2 = -1;
            
            rnd = new Random();

            if (FirstRow.Panels.Count > 5)
            {
                freeSpot = rnd.Next(0, FirstRow.Panels.Count);
                freeSpot2 = rnd.Next(0, FirstRow.Panels.Count);
                twoFreespots = true;
            }
            else if (FirstRow.Panels.Count <= 5)
            {
                freeSpot = rnd.Next(0, FirstRow.Panels.Count);
                twoFreespots = false;
            }
        }

        public void Move()
        {
            foreach (Panel panel in _rows[positon].Panels)
            {
                if(panel.BackColor.Equals(Color.Red))
                    continue;
                panel.BackColor = Color.Gray;
            }

            if (positon >= _rows.Count - 1)
            {
                Kill();
                return;
            }

            positon++;
            
            foreach (Panel panel in _rows[positon].Panels)
            {
                if (panel.Name.Contains(freeSpot + "") || (panel.Name.Contains(freeSpot2 + "") && twoFreespots))
                    continue;
                panel.BackColor = Color.Green;
            }
        }

        private void Kill()
        {
            killBool = true;
        }
    }
}