# 📌 Mini API Template - C# / .NET

🚀 Mini API en C# avec ASP.NET Core, SQLite et Swagger

Ce projet est un exemple d’API REST en C# utilisant ASP.NET Core. Il inclut :

- ✔ Un contrôleur (HomeController.cs) avec plusieurs routes.
- ✔ Une base de données SQLite (DatabaseService.cs) pour stocker les entrées du jour.
- ✔ Un système d’injection de dépendances pour séparer la logique métier.
- ✔ Swagger pour documenter et tester l’API.
- ✔ Un middleware CORS (CorsConfig.cs) pour autoriser les requêtes externes.

## 📂 Structure du projet

```/MiniApiTemplate
 ├── MiniApiTemplate.csproj      # Fichier de projet .NET
 ├── Program.cs                  # Point d'entrée de l'application
 ├── README.md                   # Documentation du projet
 ├── Controllers/                 # 📂 Contient les contrôleurs API
 │    ├── HomeController.cs       # 🎯 Contrôleur principal de l'API
 ├── Models/                      # 📂 Contient les modèles de données
 │    ├── ExampleModel.cs         # 📝 Exemple de modèle simple
 │    ├── EntreesDuJour.cs        # 📝 Modèle pour les entrées du jour
 ├── Services/                    # 📂 Contient la logique métier
 │    ├── ExampleService.cs       # ⚙️ Service pour données fictives
 │    ├── DatabaseService.cs      # ⚙️ Service pour SQLite
 ├── Config/                      # 📂 Contient les configurations globales
 │    ├── CorsConfig.cs           # 🔧 Configuration des CORS
 ├── sqlite/                      # 📂 Contient la base de données SQLite
 │    ├── data.db                 # 🗄 Fichier SQLite de stockage des données
 ├── appsettings.json             # ⚙️ Fichier de configuration de l'application
```

## 🛠 2. Installation et configuration

### 📌 Prérequis

- .NET SDK installé [Télécharger ici](https://dotnet.microsoft.com/en-us/download)

- SQLite installé [Télécharger ici](https://www.sqlite.org/download.html)

### 📌 Installation du projet

1️⃣ Cloner le projet

2️⃣ Installer les dépendances :

```
dotnet restore
```

## 🚀 3. Lancer l’API

```
dotnet run
```

📌 L’API sera accessible à http://localhost:5109 🚀

### 📌 Tester l’API avec Swagger

Ouvre http://localhost:5000/swagger pour voir et tester les routes.

📌 Compiler et générer l’exécutable

```
dotnet build
```

📌 Publier en production

```
dotnet publish -c Release -o out
```
