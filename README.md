# FGT - Prototypes - StateMachine

A fast and lightweight prototyping tool for adding a simple and flexible Finite State Machines to your game.

Ideal for use in early-stage prototypes.

## How to use

### 1. Add the `StateMachine` field to your MonoBehaviour class:

```csharp
[SerializeField] StateMachine _stateMachine;
```

### 2. Create the States (must implement the `IState` interface):

```csharp
public class MyState : IState
{
	public StateMachine StateMachine { get; set; }

	// Dependencies for your state can be created here and passed in the constructor
	Animator _animator;

	public MyState(Animator animator)
	{
		_animator = animator
	}

	public void Enter() { /* Your code, use as you want*/ }
	public void Exit() { /* Your code, use as you want*/ }
	public void Execute()
	{
		// Your code, use as you want...

		// Example: transition to another State
		StateMachine.ChangeState("STATE_IDLE");
	}
}
```

### 3. Initialize the state Machine, Add the States, Initialize and Update it

```csharp
void Awake()
{
	// 1 - Instantiate
	_stateMachine = new StateMachine();

	// 2 - Add your states
	_stateMachine.AddState("MY_STATE_NAME", new MyState(animator));
	_stateMachine.AddState("STATE_IDLE", ...);

	// 3 - Set initial state
	_stateMachine.ChangeState("MY_STATE_NAME");
}

void Update()
{
	// 4 - Update
	_stateMachine.Update();
}
```

---

## 📦 Installation

You can import this system as a Unity package via UPM.

[Github] - Button "<> Code" -> Tab Local -> Tab HTTPS -> Copy url displayed in the field.

[Unity] - Window -> Package Manager -> + -> Add Package from git URL... -> Paste the github https code.
