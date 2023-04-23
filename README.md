# THROWN TO THE WOLVES

The game was built using Unity with the goal to use my own assets from 3D Models to Scripts written in C# using the Game Engine Unity.
It started in 2018 and I worked on it through 2020 in my spare time.

## Physics Objects

https://user-images.githubusercontent.com/119373753/233814735-1c34de18-c9b9-4295-9166-aa3fd34cb03e.mp4

Provided randomized speeds at which a boulder would spawn, then generated a particle effect when the velocity below the object had enough force. Set timer for objects to break and start the cycle over again.

https://user-images.githubusercontent.com/119373753/233815020-c5b51098-5c95-498c-a332-a455fc557111.mp4

A first attempt at making objects float on water when their mass is light enough.

https://user-images.githubusercontent.com/119373753/233815180-246a9d3d-26a4-4168-a4ed-1c68db80251f.mp4

Demonstrating the basic of a downward Z direction to force snapping on an object moving at higher speeds.

https://user-images.githubusercontent.com/119373753/233815144-b2705dbc-9d06-4e33-ab7b-b074d4f68c61.mp4

Testing out overriding a character animation system and blending it with camera positioning movements, then generating pulling force on the character on tagged objects.

## Technical Systems

https://user-images.githubusercontent.com/119373753/233815027-42c9fc11-02d7-4a03-a857-0614d9f75539.mp4

Developed a system for both non-playable characters and enemies to have different appearances upon spawning into the world. This would determine things like clothing meshes, palette swaps of skin/eyes, hair styles/colors and even weapons. Additionally, enemies were given a variety of levels (1-3) depending on the player's progression, so weapons and clothing palettes may update or lock down a range of equipment suitable for the progression level.


https://user-images.githubusercontent.com/119373753/233815493-8eedbc53-508e-4a51-a02d-08183aa0e9e6.mp4


The inventory system was created to allow elemental resistances and benefits to equipment swapping. The inventory reads the player's equipment and display different icons and text based on the attributes of the objects.


https://user-images.githubusercontent.com/119373753/233815512-daa751c0-132b-48d9-b450-af6b9cc674ce.mp4


The character's head and eyes will start tracking objects that are marked as interesting objects. In this case a dragonfly is nearby while the character is not in motion, the character is going to be observing movement nearby.


## Animations



https://user-images.githubusercontent.com/119373753/233815114-9214a7cb-5c80-4a04-ab16-884d8a8ddc86.mp4

General character animation test.

https://user-images.githubusercontent.com/119373753/233815118-4b1e456d-1941-4522-a178-3865f900ef91.mp4

Ghost being animated and drinking milk.

https://user-images.githubusercontent.com/119373753/233815260-ad300650-d97f-4d7b-90f0-23b0ef5f6d3b.mp4

Start of the project, a randomized chance of fire creating an agressive tree that when attempted to chop, will eat the player's axe.
