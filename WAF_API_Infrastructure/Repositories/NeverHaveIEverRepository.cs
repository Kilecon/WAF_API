﻿namespace WAF_API_Infrastructure.Repositories
{
    using MongoDB.Driver;
    using WAF_API_Application.Services.NeverHaveIEverService;
    using WAF_API_Domain.NeverHaveIEver.Dtos;

    public class NeverHaveIEverRepository(IMongoDatabase database) : BaseRepository<NeverHaveIEverDto>(database), INeverHaveIEverRepository
    {
        
    }

}