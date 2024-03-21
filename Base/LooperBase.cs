using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Base
{
    internal abstract class LooperBase
    {
        private bool _stopped = false;

        /// <summary>
        /// Runs the loop until stopped
        /// </summary>
        /// <returns>Number of cycles ran</returns>
        public void Run()
        {
            Setup();

            while (!_stopped)
            {
                Loop();
            }
        }

        public abstract void Setup();

        /// <summary>
        /// Loops indefinitely until Stop() is called
        /// </summary>
        public abstract void Loop();

        protected void Stop()
        {
            _stopped = true;
        }
    }
}
