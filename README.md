# SIGT-CV-Back

Ce projet est crée par Marouen Ayadi, sous le thème d'un exercice pour la création d'un CV.
Ce projet .NET Core 3.1 est composé par la structure suivante : 
Un projet .NET Core SIGT.API => c'est le point d'entrée de l'application qui contient les controlleurs et les configurations.
Un Projet C# Bibliothèque de classes SIGT.DIContainerCore => un conteneur pour les injections de dépendances.
Un Projet C# Bibliothèque de classes SIGT.DTO => pour les classes DTO. 
Un Projet C# Entity framework SIGT.EFCore => contient les classes de repository pour faires les appels à la bases de donnée
Un Projet C# Entity framework SIGT.Entities => contient les entités de la base de donnée
Un Projet C# Bibliothèque de clasees SIGT.Infrastructure => contient les interfaces pour l'implémentation des services et des repositories
Un Projet C# Bibliothèque de classes SIGT.Services => pour l'implementation des services

Ce projet communique avec une base de donnée SQL Server (localDb)\MSSQLLocalDB
Ce projet expose un API /CV
Ce projet est configuré pour tester les API sous swagger

