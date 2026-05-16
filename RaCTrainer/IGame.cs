using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace racman
{
    public abstract class IGame
    {
        public IPS3API api { get; }

        public bool inputCheck = true;

        public float[] coords = new float[3];
        public int pid;

        public Timer InputsTimer = new Timer();

        public int selectedPositionIndex { get; set; }

        protected IGame(IPS3API api)
        {
            this.api = api;
            this.pid = api.getCurrentPID();

            if (api is Ratchetron)
            {
                ((Ratchetron)api).OpenDataChannel();
            }

            InputsTimer.Interval = (int)16.66667;
            InputsTimer.Tick += new EventHandler(CheckInputs);
        }

        public abstract void SavePosition();
        public abstract void LoadPosition();

        public virtual void SetupInputDisplayMemorySubs()
        {
            SetupInputDisplayMemorySubsButtons();
            SetupInputDisplayMemorySubsAnalogs();
        }

        protected virtual void SetupInputDisplayMemorySubsButtons() { }

        protected virtual void SetupInputDisplayMemorySubsAnalogs() { }

        public virtual void GetPlayerCoordinates() { }

        public abstract void CheckInputs(object sender, EventArgs e);
    }
}
