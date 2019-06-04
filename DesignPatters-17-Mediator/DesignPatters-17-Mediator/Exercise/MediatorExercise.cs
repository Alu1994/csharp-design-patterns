using System;
using static System.Console;

namespace DesignPatters_17_Mediator.Exercise
{
    public class MediatorExercise
    {
        static void Main(string[] args)
        {
            var mediator = new MediatorMat();
            var participant = new ParticipantMat(mediator);
            var participant2 = new ParticipantMat(mediator);
            var participant3 = new ParticipantMat(mediator);
            var participant4 = new ParticipantMat(mediator);

            // It will print 3 times, because we are excluding the object itself 'participant' and using 1 'mediator' for the 4 objects which the are using the 'mediator' byref, 
            // so in the end it will print 3 times 'olá 10'
            participant.Say(10);
        }
    }

    public class ParticipantMat
    {
        private readonly MediatorMat mediator;
        public int Value { get; set; }

        public ParticipantMat(MediatorMat mediator)
        {
            this.mediator = mediator;
            // Remove All Events/Delegates
            // mediator.RemoveAllEvents(mediator);
            mediator.Alert += Mediator_Alert;
        }

        private void Mediator_Alert(object sender, int e)
        {
            if (sender != this)
            {
                Value += e;
                WriteLine($"Olá {Value}");
            }
        }

        public void Say(int n)
        {
            mediator.Broadcast(this, n);
        }
    }

    public class MediatorMat
    {
        public void Broadcast(object sender, int n)
        {
            Alert?.Invoke(sender, n);
        }

        public Delegate[] GetInvocationList()
        {
            return Alert?.GetInvocationList();
        }

        public void RemoveAllEvents(MediatorMat mediator)
        {
            if (mediator.GetInvocationList() != null)
                foreach (var @delegate in mediator.GetInvocationList())
                    mediator.RemoveEvent(@delegate);
        }

        public void RemoveEvent(Delegate @delegate)
        {
            if(Alert != null)
                RemoveEvent((EventHandler<int>)@delegate);
        }

        private void RemoveEvent(EventHandler<int> @event)
        {
            Alert -= @event;
        }        

        public event EventHandler<int> Alert;
    }
}