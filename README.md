# QueueControl
## Application MAUI x Blazor pour la Gestion des Impressions sous Windows
![Stability-WIP](https://img.shields.io/badge/Stability-Travaux%20en%20cours-lightgrey.svg)
[![Join-Discord](https://img.shields.io/badge/Discord-Joindre%20le%20serveur-darkviolet.svg)](https://discord.gg/qmHVkUTn)


## Description

Cette application MAUI x Blazor pour Windows Server a été développée dans le but de créer une application .exe qui hébergera un agent Windows. Cet agent gérera une file d'attente d'impression dont les requêtes sont stockées dans une base de données. Le rôle de l'agent est de récupérer les données de la base de données et de les envoyer aux imprimantes selon le format d'impression spécifique (ZPL / EPL / PDF) et les drivers de l'imprimante.

Le but de ce projet est de combler un manque entre l'univers des applications Web et des services agissant au niveau de
l'infrastructure Windows, tels que la gestion des impressions sous Windows. 
À travers mon expérience, j'ai constaté un gros manque au niveau des impressions EPL / ZPL. 
Bien qu'il soit possible d'effectuer des envois d'impressions TCP/IP vers ce type d'imprimante avec des scripts ZPL II,
cela n'égale pas la qualité et la facilité que peut produire un driver. Par conséquent, il était nécessaire de programmer une application Windows native pour gérer les impressions avec les drivers des différentes imprimantes, car il est impossible de le faire depuis un serveur IIS.

## Fonctionnalités

- Hébergement d'un agent Windows pour la gestion des impressions.
- Support des formats d'impression ZPL, EPL et PDF.
- Intégration avec les drivers des imprimantes pour une qualité d'impression optimale.
- Interface utilisateur développée avec MAUI x Blazor.
- Stockage des requêtes d'impression dans une base de données.

### Infrastucture based on [MauiCleanTodos](https://github.com/matt-goldman/MauiCleanTodos)

## Installation

1. Clonez le repository sur votre machine locale :

    ```bash
    git clone https://github.com/ton-utilisateur/ton-repository.git
    ```

2. Allez dans le dossier du projet :

    ```bash
    cd ton-repository
    ```

3. Ouvrez le projet avec Visual Studio 2022 (ou plus récent).

4. Restaurez les packages NuGet nécessaires :

    ```bash
    dotnet restore
    ```

5. Construisez le projet :

    ```bash
    dotnet build
    ```

6. Exécutez l'application :

    ```bash
    dotnet run
    ```

## Utilisation

- Configurez les paramètres de connexion à la base de données dans le fichier `appsettings.json`.
- Lancez l'application pour démarrer l'agent Windows.
- Utilisez l'interface utilisateur pour gérer la file d'attente d'impression et surveiller les impressions en cours.

## Contribution

Les contributions sont les bienvenues ! Si vous souhaitez contribuer à ce projet, veuillez suivre les étapes suivantes :

1. Forkez le repository.
2. Clonez votre fork sur votre machine locale :

    ```bash
    git clone https://github.com/votre-utilisateur/ton-repository.git
    ```

3. Créez vos modifications localement.
4. Pushez vos modifications vers votre fork.
5. Ouvrez une Pull Request sur le repository original.

Note : Veuillez ne pas créer de nouvelles branches dans le repository principal. Utilisez vos forks personnels pour développer et tester vos modifications.

## Licence

Ce projet est sous licence Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International. Veuillez consulter le fichier `LICENSE` pour plus de détails.

## Contact

Pour toute question ou suggestion, n'hésitez pas à ouvrir une issue ou à me contacter à [william-b.lambert@pm.me](mailto:william-b.lambert@pm.me).

---

Merci d'utiliser cette application et de contribuer à son développement !