# Like-Vania

## Table of contents

- [Preview](#preview)
- [Description](#description)
- [Player Controls](#player-controls)
- [How To Play](#how-to-play)
- [Resources](#resources)
- [Further-Developments](#further-developments)

### Preview

https://github.com/user-attachments/assets/efa903b6-774b-4904-9ad1-4cc5f4886e92

### Description

Like-Vania is a 2D game inspired by Castlevania where the player takes control of a character. The character aims to pass from level to level while trying to collect coins and kill different kinds of enemies. Both kills and coins count up to the final score. 

### Player Controls

The main character has a fixed set of controls adapted for keyboard and mouse usage. Controller logic is, however, provided.

- **W** - climb ladder
- **A** - left movement
- **D** - right movement
- **SPACE** - jump
- **LEFT CLICK** - used to fire a projectile/bullet in the direction the character is looking

The player can fire while jumping. Projectiles do not interact with each other, but are destroyed when they hit the terrain. Mushrooms double indefinitely the height where the player jumps from. Enemies can be killed only with projectiles (jumping on them kills the character).

### How To Play

This github repository offers both a ready-to-go executable file (and its dependencies in [this folder](<Game>)), the source code, the packages and the project settings. The latter ones can be imported in Unity (2D core project) for further development.

The repository has to be downloaded and unzipped. Everything but the [**Game**](<Game>) folder can be deleted. To run the came run the *.exe* file in that folder.

### Resources

The game is build from scratch based on the following [Udemy course](https://www.udemy.com/course/unitycourse/?couponCode=OF83024E).

The game assets and/or sprites were either provided by the course as resources or downloaded from the web - [itch.io](https://itch.io/game-assets).

- [Asset 1](https://admurin.itch.io/enemy-galore-1)
- [Asset 2](https://spikerman.itch.io/heart-container)

### Further Developments

- More levels
- Improved level design
- Improved enemy logic
- New hazards
- Player abilities
- Permanent high score database storage
