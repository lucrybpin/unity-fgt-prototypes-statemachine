using UnityEngine;

namespace FGT.Prototypes.SimpleStateMachine.Demo
{
    public class PlayerFSM : MonoBehaviour
    {
        StateMachine _stateMachine;
        Animator _animator;
        Rigidbody2D _rigidBody;

        void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();

            _stateMachine = new StateMachine();

            _stateMachine.AddState("IDLE", new PlayerState_Idle(_animator));
            _stateMachine.AddState("MOVE", new PlayerState_Move(_animator, _rigidBody));

            _stateMachine.ChangeState("IDLE");
        }

        void Update()
        {
            _stateMachine.Update();
        }
    }
}