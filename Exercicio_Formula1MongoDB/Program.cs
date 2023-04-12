using Exercicio_Formula1MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var basededados = mongo.GetDatabase("Formula1");
        var collections = basededados.GetCollection<BsonDocument>("Pilotos");
        var documents = collections.Find(new BsonDocument()).ToList();

        Console.WriteLine("informe o nome: ");
        string n = Console.ReadLine();

        var pilot = collections.Find(Builders<BsonDocument>.Filter.Regex("Driver", n)).First();

        Console.WriteLine(pilot);

        var driver = BsonSerializer.Deserialize<Driver>(pilot);

        Console.WriteLine("informe o novo numero: ");
        int num = int.Parse(Console.ReadLine());

        collections.UpdateOne(Builders<BsonDocument>.Filter.Eq("Driver", n), Builders<BsonDocument>.Update.Set("No", num));

        collections.FindOneAndDelete(Builders<BsonDocument>.Filter.Eq("Driver", n));

        #region Uteis
        //Console.WriteLine("informe o nome do piloto");
        //string n = Console.ReadLine();

        //var filter = Builders<BsonDocument>.Filter.Regex("Driver", n);

        //var p = collections.Find(filter).FirstOrDefault();

        //var piloto= BsonSerializer.Deserialize<Driver>(p);

        //Console.WriteLine(piloto.ToString());

        /*Console.WriteLine("nome: ");
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

        Console.WriteLine(d.ToString());

        var dr = new BsonDocument
        {
            {"Driver", d.Name},
            {"Abbreviation", d.Abbreviation},
            {"No", d.Number},
            {"Team", d.Team},
            {"Country", d.Country},
            {"Date of Birth", d.BirthDate}
        };

        Console.WriteLine(dr);

        collections.InsertOne(dr);*/

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
        #endregion
    }
}