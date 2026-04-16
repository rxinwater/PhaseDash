1. General Information
Title: PhaseDash
Genre: 2D Platformer / Precision Movement
Platform: PC (Windows)
Engine: Unity (2D)
Language: C#
Target Audience: Teens
2. Core Concept

PhaseDash is a fast-paced 2D platformer where the player navigates obstacle-filled levels using movement, sprinting, and a phasing dash ability. The main mechanic revolves around timing your dash to pass through otherwise solid barriers.

3. Core Gameplay Loop
Player starts at spawn point
Player navigates through platforms and obstacles
Avoid hazards (orange zone = reset)
Use dash to phase through red barriers
Reach the green goal area
Win → go to win screen → replay or quit
4. Player Controls
Action	Input
Move Left	A
Move Right	D
Sprint	Left Shift
Dash / Phase	Q

5 Mechanics Breakdown
5.1 Movement
Horizontal movement using A/D
Sprint increases movement speed while held
Movement is continuous and physics-based (Rigidbody2D)

5.2 Dash (Core Mechanic)
Activated with Q
Player quickly moves in a direction
During dash:
Player phases through red walls
Collision with those barriers is temporarily disabled
Timing is critical for success

5.3 Collision Types
Red Walls (Phase Barriers)
Normally solid
Become passable only during dash
Core obstacle for puzzle/platforming
Orange Zone (Death / Reset)
On contact:
Player is returned to starting position
Acts as a fail state
Green Zone (Goal)
Triggers win condition
Loads win screen

6. Level Design
Current Level Structure
Floating blue platforms for traversal
Red vertical barriers requiring dash timing
Orange floor acting as a reset zone
Green platform marking level completion
Design Intent
Force player to:
Control movement precisely
Learn dash timing
Combine sprint + dash

7. UI / Menus
Main Menu
Play → loads game level
Quit → closes application
Win Screen
Play Again → reloads level
Quit → closes application

8. Technical Systems (Current)
Player
Rigidbody2D for movement
Input system using UnityEvents
Dash system with temporary collision ignoring
Barriers
Use colliders
Dynamically ignored during dash
Coins 
Spawned via CoinSpawner
Dissapear when picked up

9. Game State Flow
Main Menu
   ↓
Gameplay
   ↓ (Reach Green)
Win Screen
   ↓
Replay OR Quit
