SceneStack
==========

This Unity3D-Project tries to simplify loading scenes in a specific order.

I tried to achieve this behaviour in Unity3D 2020.3.19f1 this way:
  - On Button-Click **push** specific **Scene-Information to the Scene-Stack**
  - First **Scene-Information** gets popped off the **Scene-Stack**
  - Scene gets loaded, Player clears the objective and the **next one gets popped off the Scene-Stack**
  - Repeat until last scene on **Scene-Stack** gets completed
  - **Flow-Manager can't get a new Scene** off the **Scene-Stack** so it **loads a Fallback-Scene** (e.g. Main-Menu)

The **Flow-Manager checks for Progression-Flags** before loading the next scene and can skip it if necessary (e.g. Player has seen story before the fight already).

I also added some _fluff_ (UI, Background-Data, Progression-Flags, etc.) to better bring my point across.

You can see this behaviour in action in the scenes **Main-Menu**, **Scene 01** & **Scene 02**.\
The **Main-Menu** offers options to load some scenes. Think about them as Story- & Gameplay-segments.

**You want to load scenes in Unity3D in a specific order and need some information about what to do in them too?**\
That's when you can use this project as a reference or just copy it as is.

If you find any errors or have suggestions for improvement please let me know.
