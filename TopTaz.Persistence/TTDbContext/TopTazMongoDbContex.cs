﻿using MongoDB.Driver;
using System;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.VisitorAgg;

namespace TopTaz.Persistence.TTDbContext
{
    public class TopTazMongoDbContext<TEntity> : IMongoServiceConnection<TEntity>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<TEntity> _mongoCollection;

        public TopTazMongoDbContext(string defaultConnection = "VisitorDb")
        {
            var mongoClient = new MongoClient();
            _mongoDatabase = mongoClient.GetDatabase(defaultConnection);
        }

        public IMongoCollection<TEntity> GetConnection(string connection = "VisitorDb")
        {
            if (_mongoCollection == null || _mongoDatabase.DatabaseNamespace.DatabaseName != connection)
            {
                _mongoCollection = _mongoDatabase.GetCollection<TEntity>(GetCollectionName());
            }
            return _mongoCollection;
        }

        private string GetCollectionName()
        {
            return typeof(TEntity).Name;
        }
    }
}