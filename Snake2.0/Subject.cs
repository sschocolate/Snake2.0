using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void add(Observer observer)
        {
            _observers.Add(observer);
        }

        public void remove(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void notify()
        {
            foreach(Observer obs in _observers)
            {
                obs.update();
            }
        }
    }
}
