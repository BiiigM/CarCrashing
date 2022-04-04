using System.Collections.Generic;
using System.Windows.Forms;

namespace CarCrashing2
{
    public class Row
    {
        public List<Panel> Panels { get; private set; }

        public Row(Panel[] panels)
        {
            Panels = new List<Panel>();
            Panels.AddRange(panels);
        }
    }
}