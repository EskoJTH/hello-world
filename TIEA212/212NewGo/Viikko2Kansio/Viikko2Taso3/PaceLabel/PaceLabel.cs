using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaceLabel
{
    public partial class PaceLabel: Label
    {
        public delegate void EventHandlerTextChanged(object sender, EventArgs e);
        public event EventHandlerTextChanged paceChangeCheck;

        private ErrorProvider error = new ErrorProvider();
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; RaiseTextChangedEvent(); }
        }

        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = value; RaiseTextChangedEvent(); }
        }


        public PaceLabel()
        {
            InitializeComponent();
            paceChangeCheck += tarkastaSisalto;
        }

        protected virtual void RaiseTextChangedEvent()
        {
            // Raise the event by using the () operator.
            if (paceChangeCheck != null)
                paceChangeCheck(this, new EventArgs());
        }

        private void tarkastaSisalto(object sender, EventArgs e)
        {
            double minuutit = time.TotalMinutes;
            double luku = minuutit/distance;
                error.SetError(this, "");
                e.Cancel = false;
                this.BackColor = Color.White;
                if (luku<5)
                {
                    
                }
            


        }
    }
}
