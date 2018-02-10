using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace UnitTest_Sample.Models
{
    public partial class MongoDbManager
    {
        public MongoDbManager()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];

            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
        }
    }
}