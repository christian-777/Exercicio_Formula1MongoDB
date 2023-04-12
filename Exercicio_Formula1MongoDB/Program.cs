using Exercicio_Formula1MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var basededados = mongo.GetDatabase("Formula1");
        var collections = basededados.GetCollection<BsonDocument>("Pilotos");
        var documents = collections.Find(new BsonDocument()).ToList();

        Console.WriteLine("nome: ");
        string n= Console.ReadLine();

        Console.WriteLine("Abreviacao: ");
        string a = Console.ReadLine();

        Console.WriteLine("numero: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("equipe: ");
        string t = Console.ReadLine();

        Console.WriteLine("pais: ");
        string c = Console.ReadLine();

        Console.WriteLine("data de nascimento: ");
        string b = Console.ReadLine();

        Driver d = new(n, a, num, t, c, b);

        /*Console.WriteLine("informe o nome do piloto: ");
        var p= Console.ReadLine();

        var filtro = Builders<BsonDocument>.Filter.Regex("Driver", p);

        var piloto = collections.Find(filtro).FirstOrDefault();

        Console.WriteLine(piloto);

        Console.WriteLine("informe o nome da equipe: ");
        var e = Console.ReadLine();

        filtro = Builders<BsonDocument>.Filter.Regex("Team", e);

        var pilotos = collections.Find(filtro).ToList();

        foreach(var driver in pilotos)
        {
            Console.WriteLine(driver);
        }*/

    }
}