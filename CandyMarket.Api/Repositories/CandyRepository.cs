using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using System.Data.SqlClient;
using Dapper;

namespace CandyMarket.Api.Repositories
{
    public class CandyRepository : ICandyRepository
    {
        string _connectionString = "Server=localhost;Database=CandyMarketAPI;Trusted_Connection=True;";

        public IEnumerable<Candy> GetAllCandy()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var candies = db.Query<Candy>("Select * From Candy");

                return candies.AsList();
            }
        }

        public Candy Get(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from Candy
                            where Candy.Id = @candyId";

                var candy = db.QueryFirst<Candy>(sql, new { candyId = id });
                return candy;
            }
        }

        public Candy UpdateCandy(UpdateCandyDto updatedCandy, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [Candy]
                                SET [Name] = @name
                                    ,[Flavor] = @flavor
                                    ,[Price] = @price
                                output inserted.*
                                    WHERE id = @id";

                updatedCandy.Id = id;

                var candy = db.QueryFirst<Candy>(sql, updatedCandy);

                return candy;
            }
        }

        public bool AddCandy(AddCandyDto newCandy)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                throw new NotImplementedException();
                //var sql = @"INSERT INTO [dbo].[Candy]
                //                       ([Name]
                //                       ,[Flavor]
                //                       ,[Price])
                //                    output inserted.*
                //                    VALUES
                //                       (@name
                //                       ,@flavor
                //                       ,@price)";
                //return db.QueryFirst<Candy>(sql, newCandy);
            }
        }
 

        public bool EatCandy(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"delete 
                            from Candy 
                            where [id] = @id";

                return db.Execute(sql, new { id }) == 1;

            }
        }

        public bool DonateCandy(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"update Candy 
                            set isDonated = 1
                            where [id] = @id";

                return db.Execute(sql, new { id }) == 1;

            }
        }


    }
}
