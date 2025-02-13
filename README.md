# 🔥 Ming: The Story of a Great Elementalist - *A Celeste-Inspired 2D Platformer*


![MingLogo](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/MingPoster.png)

[![Unity](https://img.shields.io/badge/Made_with-Unity-000?logo=unity&style=for-the-badge)](https://unity.com/)  
[![GitHub Repo](https://img.shields.io/badge/View_on-GitHub-blue?style=for-the-badge&logo=github)](https://github.com/tqgiabao2006/Avatar)


---

## 🚀 Game Overview  
**Ming: The Story of a Great Elementalist** is an ambitious 2D platformer that combines the successes of both the 3D and 2D game industries—*Elden Ring* and *Celeste*. It features dynamic boss fights with high difficulty, diverse combo skills, a fluid moveset, and multiple character transformations.

### 🎯 Key Features
- ⚙️ **State Machine** – Manages different character states and animations efficiently.
- 🏃 **Dynamic Movement Mechanics** – Small but effective hidden mechanics that make character movement smoother and more responsive.
- 📐 **Custom Physics System** – Designed for a unique and polished gameplay experience.
- 🎨 **Self-Made Pixel Art Assets** – All in-game art is handcrafted.

---

## 📌 Details

### **1. ⚙️ State Machine**
#### **Overview**
The **State Machine Pattern** is a behavioral design pattern that allows an object to change its behavior dynamically based on its internal state. It is commonly used in game development, AI, and UI systems.

#### **Key Components**
- **State**: Represents a specific mode of behavior.
- **Context**: The main object that holds the current state and delegates behavior to it.
- **Transitions**: Define the rules for changing states.
- **State Interface**: Standardizes behavior across different states.

```csharp
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
```

### **How is it implemented in Ming?**
- The **State** class stores its own movement logic in **Do()**, with necessary data provided and cleared through **Enter()** and **Exit()**.
- Uses **Delegates** to wrap predicate functions that determine whether state transitions are allowed.
- The player's character has a **Sensor** component that detects whether the character is on the ground, a wall, or in the air, enhancing scalability and flexibility.

**Why did I use it?**
- **Encapsulates** behavior per state.
- Improves **maintainability and scalability** by separating concerns.
- Simplifies debugging by isolating state logic.
- Provides **full animation control** through code.


![FMS](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/FSM.gif)

---

### **🏃 Dynamic Movement Mechanics** 
#### **1. 3-Phased Running**
- The player's movement is divided into three main phases: **acceleration, max speed, and deceleration**.
- This is controlled by dynamically adjusting **ground drag** (ground friction) and setting **minimum and maximum speed** values.

![Run GIF ](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Movement.gif)


#### **2. Dynamic Jumping Forces**
- **Jump State:** The player's jump consists of three phases: **Jump, Max Height, and Fall**.
- **Dynamic Jump Force:** The jump force varies depending on how long the player holds the space key.
- **Air Control:** Adds an **anti-gravity time** at the peak of the jump, allowing smoother aerial movement.
- **Fast Fall:** Gradually increases gravity to pull the character down quickly, avoiding a floating feeling.
- **Coyote Time:** Adds a **0.2s buffer**, allowing the player to jump even if they have just fallen off a platform.
- **Jump Buffering:** Allows players to queue a jump just before landing, making jumping more responsive.
- **Double/Triple Jump:** Enables multi-jump mechanics.
- **Wall Jump:** Allows jumping off walls.
- **Animation Alignment with Jump:** Ensures animations sync properly with movement.


![Jump.PNG](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Jump.png)

![Jump.GIF](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Jump.gif)

- **Skill Combo**
  + Have a wait time, if player still click, the animator skip the first attack move to second attack if not reset the counter
- **Dash Effect**
  + Calculate the dash direction, then spawn empty objects with character sprite in that time, creating a ghost effect

#### **3. 🎨 **Self-made Pixel Art Asset***

**Player Animations**

![Idle.GIF](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Idle.gif)
*Idle animation*

![Attack.GIF](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Attack.gif)]
*Attack animation*

![JumpAttack.GIF](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/JumAttack.gif)
*Jump Attack animation*

![WallClimb.GIF](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/Wall%20Climb.gif)
*Wall Climb animation*

![32x32TileSet](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/32x32Dirt..png)
*Tile set*


---
## 🎥 Demo Gameplay Video
![Gameplay Preview](https://github.com/tqgiabao2006/Avatar/raw/main/ReadMe/GamePlay.gif)

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

