using Microsoft.AspNetCore.Mvc; // ? Permet de créer des contrôleurs API
using MiniApiTemplate.Services; // ? Référence les services pour la logique métier
using MiniApiTemplate.Models; // ? Référence les modèles de données


namespace MiniApiTemplate.Controllers // ? Namespace pour organiser les contrôleurs
{
    /// ? Contrôleur principal qui gère les routes de l'API.
    /// ? Il fournit des endpoints pour des tests et l'accès aux données.
    [ApiController] // ? Indique que cette classe est un contrôleur API
    [Route("api/[controller]")] // ? Définit la route de base : /api/home
    public class HomeController : ControllerBase
    {
        private readonly ExampleService _service; // ? Service pour gérer des données fictives
        private readonly DatabaseService _dbService; // ? Service pour interagir avec la base de données SQLite

        /// ? Constructeur du contrôleur, injecte les services nécessaires
        public HomeController(ExampleService service, DatabaseService dbService)
        {
            _service = service; // ? Initialise ExampleService
            _dbService = dbService; // ? Initialise DatabaseService
        }

        /// ? Endpoint qui renvoie un message de bienvenue.
        /// <returns>Un objet JSON contenant un message</returns>
        [HttpGet] // ? Route : GET /api/home
        [ProducesResponseType(200, Type = typeof(string))] // ? Indique que la réponse est un string avec code HTTP 200
        public IActionResult Get()
        {
            return Ok(new { message = "Bienvenue sur mon API en C# !" }); // ? Retourne un message JSON
        }

        /// ? Endpoint qui retourne une liste de données d'exemple.
        /// <returns>Liste de chaînes de caractères</returns>
        [HttpGet("data")] // ? Route : GET /api/home/data
        [ProducesResponseType(200, Type = typeof(List<string>))] // ? Indique que la réponse est une liste de chaînes
        public IActionResult GetData()
        {
            var data = _service.GetExampleData(); // ? Appelle le service ExampleService pour récupérer des données
            return Ok(data); // ? Retourne la liste des données
        }

        /// ? Endpoint qui retourne les entrées d'un jour donné depuis SQLite.
        /// <param name="jour">Le jour de la semaine (0 = Dimanche, 6 = Samedi)</param>
        /// <returns>Liste des entrées du jour</returns>
        [HttpGet("entrees/{jour}")] // ? Route : GET /api/home/entrees/{jour}
        [ProducesResponseType(200, Type = typeof(List<EntreesDuJour>))] // ? Réponse attendue : liste des entrées
        [ProducesResponseType(400)] // ? Indique une erreur si la requête est invalide
        [ProducesResponseType(500)] // ? Indique une erreur interne du serveur
        public IActionResult GetEntreesByDay(int jour)
        {
            if (jour < 0 || jour > 6) // ? Vérifie si le jour est valide (entre 0 et 6)
            {
                return BadRequest(new { message = "Le jour doit être compris entre 0 et 6." }); // ? Retourne une erreur 400
            }

            var entrees = _dbService.GetEntreesByDay(jour); // ? Appelle le service DatabaseService pour récupérer les entrées du jour
            return Ok(entrees); // ? Retourne la liste des entrées sous format JSON
        }
    }
}