using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoolTimer
{
    public class TimerModel
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private object? _backgroundMusic;


        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }          
        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = value; }
        }
        public int Seconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }
        public object? BackgroundMusic
        {
            get { return _backgroundMusic; }
            set { _backgroundMusic = value; }
        }
    }
}
