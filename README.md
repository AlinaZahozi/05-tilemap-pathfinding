# TileMap_PartA

![image](https://github.com/Computer-game-development-course/TileMap_PartA/assets/93255163/aa4dfe6e-0059-44bb-b58a-bdcb6ca22b6b)

* [Click here to play on itch.io](https://alinaandyuval.itch.io/tilemap-parta)

## Overview
* We created the game scene from the Assets/Scenes/2-player/c-click-movement.unity scene that we saw in the lecture.
* First we added the three tiles to the map (boat, goat and pickaxe).
* In order to adapt the game to the new requirements, we made changes to 2 scripts that we saw in class:
1. Assets/Scripts/2-player/KeyboardMoverByTile.cs
2. Assets/Scripts/1-tiles/AllowedTiles.cs


**KeyboardMoverByTile**

To this script we added a new method called "CheckAndModifyAllowedTiles":
![image](https://github.com/Computer-game-development-course/TileMap_PartA/assets/93255163/2b59ce6b-9b4f-4bed-b487-db958a293321)

Its job is to implement all the new functionality - that is, if the player took a boat, he will be able to move through the water.
If the player took a goat he will be able to move through the mountains and if he took a pickaxe he will turn the mountains in which he will move into grass.

**AllowedTiles**

To this script we added a new method called "Add":
![image](https://github.com/Computer-game-development-course/TileMap_PartA/assets/93255163/c16c9606-4b9c-4fd3-b634-7a81ed218c01)

Its function is to enable the dynamic addition of tiles during the game to the list of allowed tiles, which a player can pass through.
We must enable this to implement the new rules of the game.

## Support
For any assistance or to report bugs, please contact our support team at "alinush0zahozi@gmail.com"
