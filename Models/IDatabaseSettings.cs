﻿namespace FoodAppAPI.Models
{
    public interface IDatabaseSettings
    {
        string MenuCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string UserCollectionName { get; set; }
        public string ReviewCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
