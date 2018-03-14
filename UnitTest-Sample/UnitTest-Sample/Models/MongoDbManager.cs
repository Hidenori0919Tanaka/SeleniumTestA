using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Driver.Core;

namespace UnitTest_Sample.Models
{
    public partial class MongoDbManager
    {
        private MongoClient client = null;

        private string mongoName = ConfigurationManager.AppSettings["MongoDatabaseName"];
        private string mongoUserName = ConfigurationManager.AppSettings["MongoUsername"];
        private string mongoPassword = ConfigurationManager.AppSettings["MongoPassword"];
        private string mongoPort = ConfigurationManager.AppSettings["MongoPort"];
        private string mongoHost = ConfigurationManager.AppSettings["MongoHost"];
        //private string collectionName = "";

        public MongoDbManager()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(mongoHost, int.Parse(mongoPort));
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(mongoName, mongoUserName);
            MongoIdentityEvidence evidence = new PasswordEvidence(mongoPassword);

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
        }

        //    public MongoDbManager()
        //    {
        //        // MongoClientの初期化
        //        var settings = new MongoClientSettings
        //        {
        //            Server = new MongoServerAddress(mongoHost, int.Parse(mongoPort)),
        //            ServerSelectionTimeout = TimeSpan.FromSeconds(5)
        //        };
        //        settings.SslSettings = new SslSettings();
        //        settings.UseSsl = true;
        //        settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

        //        MongoIdentity identity = new MongoInternalIdentity(mongoName, mongoUserName);
        //        MongoIdentityEvidence evidence = new PasswordEvidence(mongoPassword);

        //        settings.Credentials = new List<MongoCredential>()
        //{
        //  new MongoCredential("SCRAM-SHA-1", identity, evidence)
        //};
        //        this.client = new MongoClient(settings);
        //    }
        //public MongoDbManager()
        //{
        //    string connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];

        //    MongoClientSettings settings = MongoClientSettings.FromUrl(
        //      new MongoUrl(connectionString)
        //    );
        //    settings.SslSettings =
        //      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        //    var mongoClient = new MongoClient(settings);
        //}

        public async Task<bool> CreateCollection()
        {
            IMongoDatabase mongoDatabase =
              this.client.GetDatabase(mongoName);

            await mongoDatabase.CreateCollectionAsync("hogeDoc");

            return true;
        }
    }
}