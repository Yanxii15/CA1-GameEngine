# CA1 – 2D Game Engine Development (DkIT)

**GitHub repo:** https://github.com/Yanxii15/CA1-GameEngine

Student: Ayo · Module: 2D Game Engine Development · CA1 Project (50%)

---

## The game

A 2D side-view platformer. You play a small glass spirit trying to escape a dark, overgrown ruin. The whole map is almost black; the only light is the glow around the player, so you only see what your light reaches.

You have **3 lives**. Every time you die, your light gets **bigger**, so the game gets easier the more you struggle. In Stage 2, **Light Shards** give you extra light until you next die, and **Shades** (enemies) patrol in the dark and only show up properly inside your light.

### Controls
| Key | Action |
|---|---|
| A / D | Move left / right |
| Space | Jump |
| Mouse | Menu buttons |

### Stages
1. **Stage 1 – The Sunken Hall**: lava gap, hill, push the box onto the pressure plate to raise the bridge over the lava, staircase up to the exit. Reaching the exit loads Stage 2.
2. **Stage 2 – The Root Depths**: lava lake, use the box as a step over the tall block, one-way platform, lava hops, two Shades, two Light Shards, and a sealed hatch that only opens once you step on its button. The win screen can restart Stage 2 or go back to Stage 1.

---

## How to open and run it

1. Install **Unity 6000.6.4f1** (Unity 6.6) through Unity Hub. The project uses **URP 2D**.
2. Open the project folder in Unity Hub (**Add → Add project from disk**). The first open takes a few minutes while Unity rebuilds the `Library` folder.
3. Open `Assets/Scenes/Stage1.unity` and press **Play**. Stage 1 loads Stage 2 at the exit.

If you clone from GitHub instead of using the Moodle zip: images and audio are stored with **Git LFS**, so install Git LFS first (`git lfs install`, then clone). GitHub's "Download ZIP" button does not include LFS files, so the art would be missing.

---

## Where things are

| Folder | Contents |
|---|---|
| `Assets/Scenes` | `Stage1.unity` (build index 0), `Stage2.unity` (build index 1) |
| `Assets/Scipts` | All C# scripts (folder name kept as created) |
| `Assets/Animations` | Player clips (Idle, Walk, Jump, Fall, Death), `PlayerAnims` Animator Controller, coin spin |
| `Assets/Art` | Sprite sheets, tiles, Ruins tile palette |
| `Assets/Audio` | Music loop and sound effects |
| `Assets/Prefabs` | Coin, Bridge, Shade |

### Scripts
| Script | Job |
|---|---|
| `PlayerMovement.cs` | Input System movement and jump, ground check by contact normal, sprite facing, Animator parameters, reports what the player touches (lava, enemy, exit, coin, shard) |
| `GameManager.cs` | Game rules: lives, death and respawn, light radius from lives and shards, coins, win/lose, loading the next stage, sound effects |
| `UIManager.cs` | Start menu, hearts, coin counter, win and game-over screens, pausing with `Time.timeScale`, restart and stage buttons |
| `Puzzles.cs` | Stage 1 pressure plate: box on the plate shows the bridge; resets the box on death |
| `HatchButton.cs` | Stage 2 button: opens the sealed hatch by switching its Platform Effector 2D to one-way |
| `ShadePatrol.cs` | Stage 2 enemy: patrols left and right between two x limits set per Shade in the Inspector |

---

## Unity features used

- **Tilemaps**: Ground (one Composite Collider 2D), Background, Hazards (trigger, tagged `Lava`, Animated Tile lava), Platforms (one-way)
- **2D physics**: Rigidbody 2D (Dynamic player and box, Kinematic Shades, Static platforms), Box/Capsule/Circle colliders, triggers, tags
- **Platform Effector 2D**: one-way platform, and the hatch that is solid until the button switches it to one-way
- **URP 2D lighting**: Global Light 2D at 0.1, Spot Light 2D on the player, Point Lights on the shards; lit and unlit sprite materials (Shade eyes are unlit)
- **Animation**: Animator Controller with Idle, Walk, Jump, Fall and Death states, driven by `Speed`, `IsGrounded`, `YVelocity` and `Die`
- **UI**: Canvas overlays with TextMeshPro, buttons wired with On Click events
- **Audio**: looping music on the camera, sound effects with `PlayOneShot`
- **Cinemachine**: follow camera with a Confiner 2D
- **Scenes and prefabs**: two scenes in the build list, per-scene Inspector values (`nextSceneName`, light radii)
- **Input System**: `Move` and `Jump` actions

## Unseen mechanic: dynamic 2D lighting

The mechanic not covered in class is **dynamic 2D lighting with URP Light 2D**. The level is lit only by a very dim Global Light, so the player's Spot Light is what makes the level readable. `GameManager.UpdateLighting` sets the light's outer radius from the player's lives (3 lives = smallest, 1 life = largest), and the inner radius is kept at 0.24 × the outer radius. In Stage 2, each Light Shard collected counts as one extra step of light until the player dies.

### Research used
- Unity Manual – 2D lights (URP Light 2D)
- Unity Manual – Platform Effector 2D
- Unity Manual – Animated Tile (2D Tilemap Extras)
- Wild Cockatiel Games – *How to Setup Animator and Animations in Unity 2D* (YouTube)

---

## Known limitations

- The player can sometimes stick to walls or hang on ledge edges (friction on the shared ground collider).
- A small hop can happen at some ledge edges.
- From the lake rims in Stage 2 the player's head brushes the ceiling on a full jump.
- Lava can be touched from on top of the box in one spot.

---

## Credits

- **Code**: all C# scripts written by me.
- **Audio**: all sound effects and the music loop were generated with AI assistance.
- **Art**: the player, tileset and object sprites, plus the Shade, Light Shard and hatch sprites, were made with AI assistance.
- **Scene setup**: the prefabs, all tile paintings and object placement in both Stages were done by me.
- Fonts: TextMeshPro default (LiberationSans SDF).
