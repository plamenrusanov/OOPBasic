public class Pokemon
{
    private string pokemonName;
    private string pokemonType;
    public Pokemon()
    {

    }
    public Pokemon(string pokemonName, string pokemonType)
    {
        PokemonName = pokemonName;
        PokemonType = pokemonType;
    }
    public string PokemonType
    {
        get { return pokemonType; }
        set { pokemonType = value; }
    }

    public string PokemonName
    {
        get { return pokemonName; }
        set { pokemonName = value; }
    }

}