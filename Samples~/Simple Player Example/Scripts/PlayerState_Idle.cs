using UnityEngine;
using FGT.Prototypes.SimpleStateMachine;

namespace FGT.Prototypes.SimpleStateMachine.Demo
{
    public class PlayerState_Idle : IState
    {
        public StateMachine StateMachine { get; set; }

        Animator _animator;

        public PlayerState_Idle(Animator animator)
        {
            _animator = animator;
        }

        public void Enter() { /* Debug.Log($">>>> Entered State Idle");*/  }
        public void Exit() { /* Debug.Log($">>>> Exit State Idle"); */  }

        public void Execute()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (input != Vector2.zero)
                StateMachine.ChangeState("MOVE");

            Animate();
        }

        void Animate()
        {
            int last_direction = _animator.GetInteger("LAST_DIRECTION");

            if (last_direction == 0)
                _animator.Play("Character Base Idle Down");
            else if (last_direction == 1)
                _animator.Play("Character Base Idle Down Right");
            else if (last_direction == 2)
                _animator.Play("Character Base Idle Right");
            else if (last_direction == 3)
                _animator.Play("Character Base Idle Up Right");
            else if (last_direction == 4)
                _animator.Play("Character Base Idle Up");
            else if (last_direction == 5)
                _animator.Play("Character Base Idle Up Left");
            else if (last_direction == 6)
                _animator.Play("Character Base Idle Left");
            else
                _animator.Play("Character Base Idle Down Left");
        }

    }
}