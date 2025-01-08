namespace WAF_API_HotReloads
{
    internal class Program
    {
            static async Task Main(string[] args)
            {
                // MongoDB Connection
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("test");

                // Initialize Repositories
                var baseRepository = new BaseRepository<DareDto>(database);
                var rankingRepository = new RankingRepository(database);

                // Watch for changes and update ratings dynamically
                rankingRepository.WatchForChanges(database, baseRepository);

                Console.WriteLine("Listening for changes...");
                await Task.Delay(-1); // Keep the program running
            }
        }
    }

