namespace MiniApiTemplate.Models // ? Définition du namespace pour organiser les modèles
{
    /// ? Modèle représentant une entrée du jour dans un menu.
    /// ? Utilisé pour structurer les données envoyées ou reçues par l'API.
    public class EntreesDuJour
    {
        public int jour { get; set; } // ? Jour de la semaine (0 = Dimanche, 6 = Samedi)

        public required string Nom { get; set; } // ? Nom du plat (ex: "Salade César")

        public required string Description { get; set; } // ? Description du plat (ex: "Salade avec poulet et parmesan")

        public bool Vegan { get; set; } // ? Indique si le plat est végétalien (true = oui, false = non)
    }
}