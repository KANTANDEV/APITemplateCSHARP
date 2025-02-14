namespace MiniApiTemplate.Services
{

    // ? Service d'exemple qui fournit des données statiques.
    // ? Ce service est utilisé pour illustrer l'injection de dépendance (D.I.).
    public class ExampleService
    {

        // ? Retourne une liste de données statiques pour démonstration.
        public List<string> GetExampleData()
        {
            return ["Donnée 1", "Donnée 2", "Donnée 3"];
        }
    }
}