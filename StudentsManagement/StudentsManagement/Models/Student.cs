using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentsManagement.Models
{
    [BsonIgnoreExtraElements]
    // Ignores the extra fileds received from MongoDB
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        // Due to case sensitivity BsonElement is used.
        // MongoDB uses smallcase for fields whereas C# uses Uppercase for Properties
        public string Name { get; set; }

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[] Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
