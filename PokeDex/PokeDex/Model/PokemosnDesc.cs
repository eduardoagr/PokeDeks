using System.Collections.Generic;

namespace PokeDex.Model {

    public class Abilities {
        public IList<string> normal { get; set; }
        public IList<string> hidden { get; set; }
    }

    public class Family {
        public int id { get; set; }
        public int evolutionStage { get; set; }
        public IList<string> evolutionLine { get; set; }
    }

    public class PokeDescription {
        public string number { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public IList<string> types { get; set; }
        public Abilities abilities { get; set; }
        public IList<string> eggGroups { get; set; }
        public IList<double> gender { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public Family family { get; set; }
        public bool starter { get; set; }
        public bool legendary { get; set; }
        public bool mythical { get; set; }
        public bool ultraBeast { get; set; }
        public bool mega { get; set; }
        public int gen { get; set; }
        public string sprite { get; set; }
        public string description { get; set; }
    }

}
