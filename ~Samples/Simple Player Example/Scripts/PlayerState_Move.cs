using UnityEngine;

namespace FGT.Prototypes.StateMachine.Demo
{
    public class PlayerState_Move : IState
    {
        public StateMachine StateMachine { get; set; }

        Animator _animator;
        Rigidbody2D _rigidBody;

        public PlayerState_Move(Animator animator, Rigidbody2D rigidBody)
        {
            _animator = animator;
            _rigidBody = rigidBody;
        }

        public void Enter() { /* Debug.Log($">>>> Entered State Move"); */ }
        public void Exit() { /* Debug.Log($">>>> Exit State Move"); */ }

        public void Execute()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (input == Vector2.zero)
                StateMachine.ChangeState("IDLE");

            Animate(input);

            _rigidBody.linearVelocity = input.normalized;
        }

        void Animate(Vector2 input)
        {

            if (input == Vector2.down)
            {
                _animator.Play("Character Base Walk Down");
                _animator.SetInteger("LAST_DIRECTION", 0);
            }
            else if (input == Vector2.down + Vector2.right)
            {
                _animator.Play("Character Base Walk Down Right");
                _animator.SetInteger("LAST_DIRECTION", 1);
            }
            else if (input == Vector2.right)
            {
                _animator.Play("Character Base Walk Right");
                _animator.SetInteger("LAST_DIRECTION", 2);
            }
            else if (input == Vector2.up + Vector2.right)
            {
                _animator.Play("Character Base Walk Up Right");
                _animator.SetInteger("LAST_DIRECTION", 3);
            }
            else if (input == Vector2.up)
            {
                _animator.Play("Character Base Walk Up");
                _animator.SetInteger("LAST_DIRECTION", 4);
            }
            else if (input == Vector2.up + Vector2.left)
            {
                _animator.Play("Character Base Walk Up Left");
                _animator.SetInteger("LAST_DIRECTION", 5);
            }
            else if (input == Vector2.left)
            {
                _animator.Play("Character Base Walk Left");
                _animator.SetInteger("LAST_DIRECTION", 6);
            }
            else if (input == Vector2.down + Vector2.left)
            {
                _animator.Play("Character Base Walk Down Left");
                _animator.SetInteger("LAST_DIRECTION", 7);
            }
        }
    }
}