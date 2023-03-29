# Stamina Tweaks

Changes stamina usage when out of combat (checks if enemies are within ~6 meters) so that it doesn't feel like cheating. Affects every tool (like axes, pickaxes, cultivator etc.) and every activity (like running, swimming etc.). Also changes stamina usage when encumbered.

## Mod page on Nexus Mods

(https://www.nexusmods.com/valheim/mods/2051)

## Fetaures

Stamina Usage:

If you are out of combat (no enemies within ~6 meters) using axes (includes one handed and two-handed variants), pickaxes, the cultivator, the hoe, the hammer and the fishing rod won't use any stamina. (Charging the fishing rod still uses stamina but reeling it in doesn't).

If you are out of combat (no enemies within ~6 meters) running, jumping, sneaking, dodging, swimming, being encumbered won't use any stamina.


Stamina regeneration:

If your stamina isn't full doing the above actions would momentarily pause regeneration because there's no code for it in the vanilla game. To circumvent this inconvenience, I've made the below changes:

If you are out of combat (no enemies within ~6 meters) and your stamina isn't full, doing the above actions won't pause regeneration but will instead proc a slower regeneration rate until you stop doing the above actions (like swimming, chopping trees etc.). If you are not doing the above actions the regeneration rate will return to normal. Doesn't affect two-handed axes.


## Installation

1. Download and install BepInExPack Valheim.
2. Download the mod and drop its .dll file in \BepInEx\plugins.

Credits to the Valheim Plus team for their Valheim Plus mod and socastix for their Stamina Overhaul mod as their code helped immensely.

## License

[GNU GPLv3](https://choosealicense.com/licenses/gpl-3.0/)
