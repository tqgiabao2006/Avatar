# 🔥Ming, The story of a greate elementalist - *Celeste-inspired 2D Platformer*

![MingLogo](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/MingPoster.png)

[![Unity](https://img.shields.io/badge/Made_with-Unity-000?logo=unity&style=for-the-badge)](https://unity.com/)  
[![GitHub Repo](https://img.shields.io/badge/View_on-GitHub-blue?style=for-the-badge&logo=github)](https://github.com/tqgiabao2006/Avatar)

---

## 🚀 Game Overview  
**Ming, The story of a greate elementalistis** is an ambitious 2D platformer project that combine two major sucess of both 3D and 2D game industry Elden Ring, and Celeste. It creates a dynamic boss fight with high difficulty and diverse combo skills, moveset, character forms.

### 🎯 Key Features
- ⚙️ **State Machine** – Manage different states of a character, and animations.
- 🏃 **Dynamic Movement Mechanics** - Small, effective hidden mechanics that make character's movement smoother and more responsive
- 📐 **Custom Physics System**
- 🎨 **Self-made Pixel Art Asset**
---

### 📌 Details

#### **1. ⚙️State Machine**
**Overview**
The **State Machine Pattern** is a behavioral design pattern that allows an object to change its behavior when its internal state changes. It is commonly used in game development, AI, and UI systems.

**Key Components**
- **State**: Represents a specific mode of behavior.
- **Context**: The main object that holds the current state and delegates behavior to it.
- **Transitions**: Rules defining how and when states change.
- **State Interface**: Defines common behavior for all states.

public interface IState {
    void Enter();
    void Update();
    void Exit();
}

public class IdleState : IState {
    public void Enter() => Debug.Log("Entering Idle State");
    public void Update() => Debug.Log("Idle...");
    public void Exit() => Debug.Log("Exiting Idle State");
}

public class StateMachine {
    private IState currentState;

    public void SetState(IState newState) {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update() => currentState?.Update();
}
**How it is implented in Ming ?**
- **State** class stores its own logic of movement in **Do()**, and necessary data is given and clear through **Enter()**, **Exit()** .
- Use **Delegate** to wrap a predicate function that decide whether can change states or not.
- Attach to player's character a **Sensor** part, can determine whether the character is on ground, wall, or not, offering enhanced scalability and flexibity

![StateVideo](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/BloodVein_Grid.png)


**Why I used it ?**
- **Encapsulates** behavior per state.
- Improves **maintainability and scalabilty** by separating concerns.
- Simplifies debugging by isolating state logic.
- Fully control animation with code

---

#### 2.🏃 **Dynamic Movement Mechanics** 
- **3-phased running**
  - The player's movement divides into 3 main phases: acceleration, max speed, decelleration.
  - I controlled it by increase and decrease **ground drag** (ground friction) and have **min speed** and **max speed** variables.

![RunState.PNG](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Enum%20Direction.png)

![Movement.GIF](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Get%20direction.png)


- **Dynamic jumping forces**
  - **Jump state**: Player's Jump divides into 3 main phases: Jump, max height, fall.
  - **Dynamic jump force**: The jump force vary depends on how long player hold the space key
  - **Air control**: Add anti-gravity time on the max heigh phase, creating a air control feeling for player
  - **Fast fall**: Gradually increase gravity force to pull character down fast, avoiding a floating-feeling on a jump
  - **Coyote time**: Add a buffer time (0.2s) that player still can jump even fall off the platform to correct use
  - **Jump Buffering**: Player can jump near the ground, not neceessary to touch the ground, avoid perfect timing jump, make jump more respsonsive
  - **Double/Triple Jump**
  - **Wall Jump**
  - **Animation allign with Jump**

![Jump.PNG](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Smooth%20curve.png)

![Jump.GIF]()

- **Skill Combo**
  + Have a wait time, if player still click, the animator skip the first attack move to second attack if not reset the counter
- **Dash Effect**
  + Calculate the dash direction, then spawn empty objects with character sprite in that time, creating a ghost effect

#### **3. 🎨 **Self-made Pixel Art Asset***

**Player Animations**

![Idle.GIF](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)
*Idle animation*

![Attack.GIF](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)]
*Attack animation*

![JumpAttack.GIF](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)
*Jump Attack animation*

![WallClimb.GIF](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)
*Wall Climb animation*

![32x32TileSet](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)
*Tile set*


---
## 🎥 Demo Gameplay Video
![Gameplay Preview](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Gameplay.gif)

---

## 🛠 Tech Stack  
| **Technology**   | **Usage**  |  
|-----------------|-----------|  
| Unity (C#) | Core Engine & Gameplay |  
| State Machine | Core Algorithm |  
| Aseprite | Full self-made game art |  

---

## 🎮 Current Status  
📦 **Developing**

---

## 🚧 Development Roadmap  
🔹 **[ ] Boss Fight** – Advanced AI Boss.  
🔹 **[ ] Interactive Obstacle**
🔹 **[ ] Dynamic Environment**  

---

## 🏆 Contributors & Credits  
👨‍💻 **Ben** (*Mad Scientist of Game Lab*) – Solo Developer  
🎵 **Music & SFX:** Open-source / Custom Compositions  
📖 **Special Thanks:** [Unity Vietnam Community]

---

## ⭐ Support & Feedback  
💬 **Have feedback?** Open an [issue](https://github.com/tqgiabao2006/blood-vein/issues) or contact me via email: tqgiabao2006@gmail.com.  
🎮 **Follow my journey:** [🔗 Portfolio](https://your-portfolio-link.com)  

