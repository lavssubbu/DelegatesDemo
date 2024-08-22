using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConcept
{
    public delegate void DelEvent();
    internal class Publisher
    {
        public event DelEvent SampEvent; //Event created

        public void Initiate()
        {
            Console.WriteLine("Event Started");
            RaiseEvent();
        }
        public void RaiseEvent()
        {
          SampEvent?.Invoke(); //call the subscriber
       }

    }
}
