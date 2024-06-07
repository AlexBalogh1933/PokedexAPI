using PokedexAPI.Models;
using System.Text.Json;

namespace PokedexAPI.Data
{
    public class PokemonRepository
    {
        private readonly List<Pokemon> _pokemon;

        public PokemonRepository()
        {
            // Read the JSON file and deserialize it into a list of messages
            var jsonData = File.ReadAllText("Data/pokemon.json");
            _pokemon = JsonSerializer.Deserialize<List<Pokemon>>(jsonData);
        }

        public Pokemon GetMessageByNumber(string number)
        {
            return _pokemon.FirstOrDefault(m => !string.IsNullOrWhiteSpace(number) && m.Number == number);
        }
    }
}
