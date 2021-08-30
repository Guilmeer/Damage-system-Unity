# Damage-system-Unity
A Damage system with Unity's particle system

# System Explanation

The bullet particle will send a string list with the information about what it will cause to
the enemy to a function that will manage and call all functions necessary.
E.g., if the bullet sends something like:
```
string[] normalBullet = { "KnockBack", "FireDamage" };
```
It will Invoke the KnockBack function, then the FireDamage function, as shown in this Gif 
below.


## Fire Damage Gif
![Alt Text](https://github.com/Guilmeer/Damage-system-Unity/blob/9e2b04aeb3ba36529bd8b06f370cbc5b077d45f1/Gif/FireDamageShowcase.gif)

### Misc

Player is always looking at the cursor.
Left click to shoot.
