namespace MiniApiTemplate.Models // ? Définition du namespace pour organiser les modèles
{
    /// ? Modèle représentant un exemple de données.
    /// ? Utilisé pour structurer les données envoyées ou reçues par l'API.
    public class ExampleModel
    {
        public int Id { get; set; } // ? Identifiant unique de l'objet

        public required string Name { get; set; } // ? Nom de l'objet (obligatoire grâce à `required`)
    }
}