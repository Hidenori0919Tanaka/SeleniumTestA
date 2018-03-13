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

        private string mongoName = ConfigurationSettings.AppSettings["MongoDatabaseName"];
        private string mongoUserName = ConfigurationSettings.AppSettings["MongoUsername"];
        private string mongoPassword = ConfigurationSettings.AppSettings["MongoPassword"];
        private string mongoPort = ConfigurationSettings.AppSettings["MongoPort"];
        private string mongoHost = ConfigurationSettings.AppSettings["MongoHost"];
        private string collectionName = "";

        public MongoDbManager()
        {
            //string dbConnectString = ConfigurationSettings.AppSettings["MongoDatabaseName"];
            //string dbConnectString = ConfigurationSettings.AppSettings["MongoUsername"];
            //string dbConnectString = ConfigurationSettings.AppSettings["MongoPassword"];
            //string dbConnectString = ConfigurationSettings.AppSettings["MongoPort"];
            //string dbConnectString = ConfigurationSettings.AppSettings["MongoHost"];

            // MongoClientの初期化
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(mongoHost, int.Parse(mongoPort)),
                ServerSelectionTimeout = TimeSpan.FromSeconds(5)
            };
            settings.SslSettings = new SslSettings();
            settings.UseSsl = true;
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(mongoName, mongoUserName);
            MongoIdentityEvidence evidence = new PasswordEvidence(mongoPassword);

            settings.Credentials = new List<MongoCredential>()
    {
      new MongoCredential("SCRAM-SHA-1", identity, evidence)
    };
            this.client = new MongoClient(settings);
        }
        //public MongoDbManager()
        //{
        //    //string connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];

        //    //MongoClientSettings settings = MongoClientSettings.FromUrl(
        //    //  new MongoUrl(connectionString)
        //    //);
        //    //settings.SslSettings =
        //    //  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        //    //var mongoClient = new MongoClient(settings);
        //}

        public async Task<bool> CreateCollection()
        {
            IMongoDatabase mongoDatabase =
              this.client.GetDatabase(mongoName);

            await mongoDatabase.CreateCollectionAsync("Collection");

            return true;
        }
    }
}