# Game Economy

This file tries to document the current game economics, and damage/heal balance as well as the reasoning behind it.

## Current stats

### Player

| Attribute   | Value |
| ----------- | ----- |
| Base Health | 3     |
| Phaser DMG  | 2     |
| Laser DMG   | 5     |
| Cannon DMG  | -     |

### Bee

| Attribute   | Value |
| ----------- | ----- |
| Base Health | 7     |
| Bee DMG     | 1     |
| Bee Loot    | 7     |

### Consumables

| Attribute          | Value |
| ------------------ | ----- |
| Potion Health      | 1     |
| Superpotion Health | 4     |
| Hyperpotion Health | 8     |

## In Game Store

| Attribute             | Value |
| --------------------- | ----- |
| Potion Price          | 5     |
| Superpotion Price     | 15    |
| Hyperpotion Price     | 20    |
| Phaser Price          | 0     |
| Laser Price           | 250   |
| Cannon Price          | 20    |
| Phaser Ammo x10 Price | 5     |
| Laser Ammo x10 Price  | 15    |
| Cannon Ammo x10 Price | 20    |

## Core concepts

Coins available: 1, 2, 5, 10

Player will start with 10 coins, so that can but a phaser (0), a potion (5) and ammo for the phaser (5).
Player's base health must be initially low so that it will be careful until has enough money and can buy extra ammo and potions.

Price for potions (5) has to be lower than the penalty applied when falling off the platforms (10). This way, we ensure player will be careful of not falling off.

Prices for Laser and Cannon have to be slightly high (25x times the highest coin available) so that it plays a little bit until being able to unlock them.

Phaser needs 4 shots (Laser 2) to kill a bee which give 7 loot coins.

Laser and Cannon are expensive to maintain to provide an incentive if the player wants to main some of these weapons.
