using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    class Program
    {
        public class Bug
{
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
    public string Name { get; } = "";
    public string Species { get; } = "";
    public List<string> Predators { get; } = new List<string>();
    public List<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
    public string FormalName => $"{this.Name} the {this.Species}";

    //public string FormalName
    //{
    //    get
    //    {
    //        return $"{this.Name} the {this.Species}";
    //    }
    //}

    // Class constructor
     public Bug(string name, string species, List<string> predators, List<string> prey)
    {
        this.Name = name;
        this.Species = species;
        this.Predators = predators;
        this.Prey = prey;
    }

    // Convert this method to an expression member
    public string PreyList() => string.Join(",", this.Prey);
            
    //public string PreyList()
    //{
    //    var commaDelimitedPrey = string.Join(",", this.Prey);
    //    return commaDelimitedPrey;
    //}

    // Convert this method to an expression member
    public string PredatorList() => string.Join(",", this.Predators);
    
    //public string PredatorList()
    //{
    //    var commaDelimitedPredators = string.Join(",", this.Predators);
    //     return commaDelimitedPredators;
    //}

    // Convert this to expression method
     public string Eat(string food) =>
        (this.Prey.Contains(food))
        ? $"{this.Name} ate the {food}."
        :$"{this.Name} is still hungry.";
    }

    //public string Eat(string food)
    //{
    //    if (this.Prey.Contains(food))
    //    {
    //        return $"{this.Name} ate the {food}.";
    //    }
    //    else
    //    {
    //        return $"{this.Name} is still hungry.";
    //    }
    //}
    static void Main(string[] args)
      {
            List<string> Predators = new List<string>()
            {
                "Vampire",
                "Monster",
                "Ghost",
                "Zombi"
            };
            List<string> Prey = new List<string>()
            {
                "Human",
                "Blood",
                "Brain",
                "Mouse"
            };

            Bug me = new Bug("Chie", "Human", Predators, Prey);

            Console.WriteLine(me.FormalName);
            Console.WriteLine(me.Eat("french fries"));
            Console.WriteLine(me.PredatorList());
            Console.WriteLine(me.PreyList());
        }
    }
}
