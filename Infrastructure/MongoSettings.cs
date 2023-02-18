namespace Infrastructure
{
    public class MongoSettings
    {
        public string ConnectionURI { get; private set; } = "";
        public string DatabaseName { get; private set; } = "";
        public string CollectionName { get; private set; } = "";
    }
}