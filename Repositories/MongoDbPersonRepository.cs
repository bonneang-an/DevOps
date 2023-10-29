using MongoDB.Bson;
using MongoDB.Driver;
using Student.Entities;

namespace Repositories
{
    public class MongoDbPersonRepository : IPersonRepository
    {
        private const string databaseName = "Student";
        private const string collectionName = "Person";
        private readonly IMongoCollection<Person> peopleCollection;
        private readonly FilterDefinitionBuilder<Person> filterBuilder = Builders<Person>.Filter;
        public MongoDbPersonRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database =  mongoClient.GetDatabase(databaseName);
            peopleCollection = database.GetCollection<Person>(collectionName);
        }
        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id , id);
            await peopleCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
           return await peopleCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Person?> GetPersonAsync(Guid id)
        {
            var filter = filterBuilder.Eq(x => x.Id , id);
            return await peopleCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InsertAsync(Person person)
        {
            await peopleCollection.InsertOneAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            var filter = filterBuilder.Eq(e => e.Id ,person.Id);
           await peopleCollection.ReplaceOneAsync(filter,person);
        }
    }
}