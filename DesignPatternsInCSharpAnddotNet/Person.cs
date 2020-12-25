using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharpAnddotNet
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public sealed class PersonBuilder
    {
        private readonly List<Action<Person>> _actions = new List<Action<Person>>();

        public void AddAction(Action<Person> action)
        {
            _actions.Add(action);
        }
        public PersonBuilder Called(string name)
        {
            AddAction(p => { p.Name = name;});
            return this;
        }

        public Person Build()
        {
            var p = new Person();
            foreach (var action in _actions)
            {
                action(p);
            }

            return p;
        }
    }

    public static class NewPersonBuilder
    {
        public static PersonBuilder WorkAs(this PersonBuilder personBuilder, string position)
        {
            personBuilder.AddAction(p=>p.Position = position);
            return personBuilder;
        }
    }
}