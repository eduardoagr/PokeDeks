using System.Collections.Generic;

namespace PokeDex.Model {
    public class Result {
        public string name { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
    }

    public class RootObj {
        public List<Result> results { get; set; }
    }
}
