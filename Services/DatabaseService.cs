using Dapper; // ? ORM léger pour exécuter des requêtes SQL facilement
using Microsoft.Data.Sqlite; // ? Fournit une connexion SQLite pour .NET
using MiniApiTemplate.Models; // ? Référence le modèle `EntreesDuJour`


namespace MiniApiTemplate.Services
{
    /// ? Service qui gère la connexion et les requêtes SQL avec SQLite
    public class DatabaseService
    {
        private readonly string _connectionString; // ? Stocke la chaîne de connexion SQLite

        /// ? Constructeur du service, initialise la connexion à SQLite
        public DatabaseService()
        {
            // ? Récupère le chemin du dossier où l'application s'exécute
            string basePath = Directory.GetCurrentDirectory();

            // ? Construit le chemin vers la base de données SQLite (`sqlite/data.db`)
            string dbPath = Path.Combine(basePath, "sqlite", "data.db");

            // ? Vérifie si le fichier de la base de données existe avant d'essayer de s'y connecter
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException($"La base de données SQLite est introuvable : {dbPath}");
            }

            // ? Initialise la chaîne de connexion pour SQLite
            _connectionString = $"Data Source={dbPath}";
        }

        /// ? Méthode pour récupérer les entrées d'un jour donné
        /// <param name="jour">Le jour de la semaine (0 = Dimanche, 6 = Samedi)</param>
        /// <returns>Liste des entrées du jour</returns>
        public List<EntreesDuJour> GetEntreesByDay(int jour)
        {
            using (var connection = new SqliteConnection(_connectionString)) // ? Ouvre une connexion avec SQLite
            {
                connection.Open(); // ? Établit la connexion à la base de données

                string query = "SELECT * FROM ENTREES WHERE jour = @Jour;"; // ? Requête SQL avec un paramètre sécurisé

                // ? Exécute la requête SQL et récupère les résultats sous forme de liste d'objets `EntreesDuJour`
                return connection.Query<EntreesDuJour>(query, new { Jour = jour }).AsList();
            }
        }
    }
}