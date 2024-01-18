using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    public class PokemonDetalhesAPI{
        public string name { get; set; }
    }

    public class Propriedades{ 
        public int height { get; set; }
        public int weight { get; set; }
        public List<Habilidades> abilities { get; set; }
    }

    public class Habilidades{
        public Ability ability { get; set; }
    }

    public class Ability{
        public string name { get; set; }
    }
}