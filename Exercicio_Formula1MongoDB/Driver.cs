using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Exercicio_Formula1MongoDB
{
    internal class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string?  Name { get; set; }
        public string? Abbreviation { get; set; }
        public int Number{ get; set; }
        public string? Team { get; set; }
        public string? Country { get; set; }
        public string? BirthDate { get; set; }

        public Driver(string? name, string? abbreviation, int number, string? team, string? country, string? birthDate)
        {
            Name = name;
            Abbreviation = abbreviation;
            Number = number;
            Team = team;
            Country = country;
            BirthDate = birthDate;
        }
    }
}
