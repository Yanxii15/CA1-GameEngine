# CA1 Art Pack v2: Overgrown Ruin (side-view, 32px)

## Look
- 32×32 pixel art, PPU 32, so 1 tile = 1 Unity unit
- Dark mossy stone ruin. The character is the main light source
- Lava glows warm. Coins are only bright when your light reaches them (no lights of their own)

## Files
| File | Contents | Slice |
|---|---|---|
| `player_sheet.png` | Glass spirit facing **right** (flip X for left). Rows: idle ×4, walk ×6, jump ×3 (rise, peak, fall), death ×4 | Grid 32×32 |
| `tileset.png` | ground-top ×2, ground-fill ×2, slope ↗ low, slope ↗ high, slope ↖ high, slope ↖ low, floating step, tall block, back wall ×2 | Grid 32×32 |
| `lava.png` | Row 1: lava surface ×4 frames. Row 2: lava fill ×4 frames | Grid 32×32 |
| `objects.png` | box, button up (red), button pressed (green), bridge plank | Grid 32×32 |
| `coin.png` | 4-frame spin | Grid 16×16 |
| `exit.png` | stone arch, 2 frames (rune glow) | Grid 32×64 |
| `ui_hearts.png` | full, empty | Grid 16×16 |
| `light_flame.png` | soft flame-edged shape for a **Sprite Light 2D** on the player | Single |

Slopes are **2:1** (gentle) and span two tiles: low half + high half.

## Unity import settings
- Texture Type: Sprite (2D and UI). Sprite Mode: Multiple (Single for `light_flame`)
- **Pixels Per Unit: 32** (coin and hearts: 32 as well, so they're half a tile)
- **Filter Mode: Point (no filter)**
- **Compression: None**
- Sprite Editor → Slice → Grid By Cell Size (see table) → Apply

## Palette
| Use | Hex |
|---|---|
| Outline | `#181E30` |
| Stone | `#4A4656` |
| Moss | `#467840` / light `#6EA054` |
| Back wall | `#24222E` |
| Glass body | `#6EB6D6` / edge `#AAE8F8` |
| Core | `#FFC85A` → `#FFF8C8` |
| Lava | `#CD4620` → `#FA962D` → `#FFDE6E` |
| Crate | `#8C5C34` |
| Exit glow | `#6EE6C8` |

## Sorting layers
Background → Ground → Objects → Player → Hazards → UI
