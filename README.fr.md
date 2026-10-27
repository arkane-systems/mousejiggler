# Mouse Jiggler (version française)

Mouse Jiggler est un petit utilitaire qui simule des mouvements de souris afin d'empêcher le système de passer à l'état inactif.

## Installation

Avec Winget ou Chocolatey :

- `winget install ArkaneSystems.MouseJiggler`
- `choco install mouse-jiggler --version=3.1.0`

Ou en téléchargeant l'archive depuis la page des versions :

- https://github.com/arkane-systems/mousejiggler/releases

## Utilisation de base

Après avoir lancé `MouseJiggler.exe` :

- cochez « Mouvement ? » pour démarrer le mouvement, décochez pour l'arrêter ;
- cochez « Paramètres... » pour afficher le panneau de paramètres ;
- vous pouvez aussi basculer le mouvement à tout moment avec <kbd>Ctrl</kbd>+<kbd>Maj</kbd>+<kbd>J</kbd>.

Modes disponibles : Normal, Zen, Circle (cercle), Linear (linéaire).

## Options de ligne de commande

- `-j, --jiggle` : démarrer avec le mouvement activé
- `-m, --minimized` : démarrer réduit
- `-o, --mode <mode>` : choisir le mode de mouvement
- `-r, --random` : activer la variation aléatoire de l'intervalle
- `-s, --seconds <secondes>` : définir l'intervalle en secondes
- `-d, --distance <distance>` : définir le multiplicateur de distance
- `-g, --settings` : démarrer avec le panneau de paramètres affiché
- `-l, --respect-locked-state` : suspendre le mouvement tant que la session est verrouillée
- `--stop-jiggling` : demander à l'instance en cours d'arrêter le mouvement, puis quitter (ne démarre pas l'application)
- `--version` : afficher la version
- `-?, -h, --help` : afficher l'aide

## Arrêt programmé

Mouse Jiggler n'a pas de minuterie d'arrêt intégrée : le Planificateur de tâches de Windows le fait très bien, et `--stop-jiggling` permet de le piloter proprement. L'option trouve l'instance en cours, décoche « Mouvement ? » puis quitte, sans démarrer une seconde instance. S'il n'y a pas d'instance en cours, elle ne fait rien et se termine avec un code de sortie non nul.

Par exemple, pour arrêter le mouvement tous les jours à 17 h 00 :

```
schtasks /create /tn "Stop Mouse Jiggler" /tr "\"C:\Path\To\MouseJiggler.exe\" --stop-jiggling" /sc daily /st 17:00
```

## Remarque

Ce fichier est une présentation en français ; la documentation de référence est en anglais dans `README.md`.
