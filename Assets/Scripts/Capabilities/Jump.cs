using UnityEngine;

namespace BHSCamp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float _jumpHeight = 3f;
        [SerializeField, Range(0, 5)] private int _maxAirJumps = 0;
        [SerializeField, Range(0f, 5f)] private float _downwardMovementMultiplier = 3f;
        [SerializeField, Range(0f, 5f)] private float _upwardMovementMultiplier = 1.7f;
        [SerializeField] private float _jumpWindowTime;
        private float _default_jumpHeight;

        private Rigidbody2D _body;
        private Ground _ground;
        private Vector2 _velocity;

        private int _jumpPhase;
        private float _defaultGravityScale, _jumpSpeed;

        private bool _desiredJump, _onGround;

        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();

            _defaultGravityScale = 1f;
            _default_jumpHeight = _jumpHeight;
        }

        public void Action()
        {
            _desiredJump = true;
            Invoke(nameof(ResetJump), _jumpWindowTime);
        }

        private void ResetJump()
        {
            _desiredJump = false;
        }
        
        private void FixedUpdate()
        {
            _onGround = _ground.OnGround;
            _velocity = _body.velocity;

            if (_onGround)
            {
                _jumpPhase = 0;
            }

            if (_desiredJump)
            {
                JumpAction();
            }

            if (_body.velocity.y > 0)
            {
                _body.gravityScale = _upwardMovementMultiplier;
            }
            else if (_body.velocity.y < 0)
            {
                _body.gravityScale = _downwardMovementMultiplier;
            }
            else if(_body.velocity.y == 0)
            {
                _body.gravityScale = _defaultGravityScale;
            }

            _body.velocity = _velocity;
        }
        private void JumpAction()
        {
            if (_onGround || _jumpPhase < _maxAirJumps)
            {
                _desiredJump = false;

                _jumpPhase += 1;
                
                _jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * _jumpHeight);
                
                if (_velocity.y > 0f)
                {
                    _jumpSpeed = Mathf.Max(_jumpSpeed - _velocity.y, 0f);
                }
                else if (_velocity.y < 0f)
                {
                    _jumpSpeed += Mathf.Abs(_body.velocity.y);
                }
                _velocity.y += _jumpSpeed;
                
                SetDefaultJumpHeight();
            }
        }

        private void SetDefaultJumpHeight()
        {
            _jumpHeight = _default_jumpHeight;
        }

        public void SetJumpMultiplier(float jumpMultiplier)
        {
            _jumpHeight *= jumpMultiplier;
        }
    }
}

