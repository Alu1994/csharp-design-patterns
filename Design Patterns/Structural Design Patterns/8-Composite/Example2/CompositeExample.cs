using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static System.Console;

namespace DesignPatterns_8_Composite.Example2
{
    public class CompositeExample__NeuronNetworks__RedesNeurais
    {
        static void Mains(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            neuron1.ConnectTo(layer2);
            neuron2.ConnectTo(layer1);
            neuron2.ConnectTo(layer2);

            layer1.ConnectTo(layer2);
            layer2.ConnectTo(layer2);
        }
    }
    public static class ExtensionsMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other))
                return;

            foreach (var from in self)
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;

        public Neuron()
        {
            In = new List<Neuron>();
            Out = new List<Neuron>();
        }

        //public void ConnectTo(Neuron other)
        //{
        //    Out.Add(other);
        //    other.In.Add(this);
        //}

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }
}
