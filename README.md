## League Of Legends

We are building a computer game.
In this game, there are 3 character types: "Warrior", "Wizard", and "Support".
Each character has 3 attributes: name, health value, and attack power.
These attributes must be initialized with the required starting values.

During character selection, the player must also select equipment. According to the rules:

- A Warrior must have one attack equipment and one health equipment.
- A Wizard must have one health equipment.
- A Support must have one attack equipment.

Equipment effects are as follows:

- For Warrior characters:
  - Blue Spell +10 HP
  - Green Spell +5 HP
  - Sword +20 XP
  - Weapon +50 XP

- For Wizard characters:
  - Blue Spell +50 HP
  - Green Spell +30 HP

- For Support characters:
  - Sword +10 XP
  - Weapon +20 XP

Based on the selected character and equipment, the following output is printed on the screen.
Develop the application that produces this output.

NOTE: It is recommended to use object-oriented programming principles suitable for this scenario.

---

## Development Notes (macOS)

This repository is configured to keep NuGet packages locally under `./.nuget/packages`.
This prevents `dotnet restore/build/test` commands from getting blocked due to permission issues in `~/.local/share/NuGet`.

If NuGet cache permissions are broken on your machine, run these commands once:

```bash
mkdir -p ~/.local/share/NuGet
chmod -R u+rwX ~/.local/share/NuGet
```

Type: Warrior

Name: Ashe

Health Value: 105 HP

Attack Power: 80 XP

---

Type: Wizard

Name: Annie

Health Value: 150 HP

Attack Power: 20 XP

---

Type: Support

Name: Alistar

Health Value: 100 HP

Attack Power: 50 XP

---
