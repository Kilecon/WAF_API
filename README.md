# WAF_API

TODO :

- LOGS

- Coté factory revoir les valueOjbect

- Tokens

- Modifier la gestion d'erreurs (routes modifiés)

- Refaire les Tests Unitaires

il reste à mettre des logs, rajouter des gestions d'erreurs, modifier les factories pour avoir moins d'erreurs de mise en forme, mettre des tokens sur certaines routes et d'autres secu sur les routes, AJOUTER UNE COLLECTION POUR LES SUGGESTIONS DES JOUEURS, et des tests unitaires

suggestions : TypeName, Question, Lang, id, timestamp (GetAll getById DeleteById)
## 📌 Table of Contents :
   
I. [Badges](#🎯-badges)

II. [Presentation](#📋-presentation)

III. [Availables features](#🌟-features)

IV. [Required Configuration](#🔧-required-configuration) 

V. [Installation](#💻-installation) 

VI. [Lauch](#🌐-lauch)


## 🎯 Badges :

[![ASP.NET](https://img.shields.io/badge/Language-ASP.NET-blue)](https://dotnet.microsoft.com/fr-fr/apps/aspnet)
[![Mongo DB](https://img.shields.io/badge/Database-MongoDB-green)](https://www.mongodb.com/fr-fr)


## 📋 Presentation :

This project is an ASP.NET API designed to interact with MongoDB for challenges purposes.

## 🌟 Features :

- Creation and management of challenges
- Ranking system  
- Suggestions system 
- JWT token management  
- Swagger documentation 

## 🔧 Required Configuration :

- [Dotnet runtime sdk](https://dotnet.microsoft.com/fr-fr/download/dotnet/8.0) : You need to install .NET for the required configuration.


## 💻 Installation :

- Clone the repo with the following command :
```bash
git clone https://github.com/Darkblue5031/WAF_API
```

## 🌐 Lauch :

- Execute the following command :
```bash
cd WAF_API
dotnet run
```

### Access the API :

The entrypoints of the API are availables here : http://localhost:5000/

### Access the Swagger documentation :

Visit http://localhost:5000/swagger/index.html in your web browser to view the Swagger documentation.
