
namespace LearnQuickOnline.Configure
{
    public class MongoDBConfig
    {
        public string Database { get; set; } = "QuickLearnSpace";
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString 
        {
            get 
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
        public string ConnectionStringTest
        {
            get 
            {
                return $@"mongodb+srv://admin:learnquick.online@cluster0-xbjvr.mongodb.net/test?retryWrites=true&w=majority";
            }
        }
    }

    public class ServerConfig
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
    }
}