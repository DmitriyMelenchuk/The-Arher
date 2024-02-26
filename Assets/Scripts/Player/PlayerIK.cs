using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private Rig _playerRig;
    [SerializeField] private float _weightSpeed;

    private void Update()
    {
        if (_playerShoting.IsStartShoting == true)
        {
            _playerRig.weight = Mathf.MoveTowards(_playerRig.weight, 1, _weightSpeed * Time.deltaTime);
        }
        if (_playerShoting.IsStartShoting == false)
        {
            _playerRig.weight = Mathf.MoveTowards(_playerRig.weight, 0, _weightSpeed * Time.deltaTime);
        }
    }

    //[SerializeField] private Transform _leftHand;
    //[SerializeField] private Transform _leftHandTarget;
    //[SerializeField] private Transform _rightHand;
    //[SerializeField] private float _leftHandWeight;

    //private Animator _animator;
    //private Transform _targetLook;

    //public float weight;
    //public float bodyWeight;
    //public float headWeight;

    //public float leftHandWeight;
    //public float rightHandWeight;

    //private Transform rHand;

    //public Vector3 aimingPosition;

    //private Transform shoulder;
    //private Transform aimPivot;
    //private Transform leftHand;
    //private Transform rightHand;

    //private void Start()
    //{
    //    _animator = GetComponent<Animator>();
    //    _rightHand = _animator.GetBoneTransform(HumanBodyBones.RightHand);
    //    _leftHand = new GameObject().transform;


    //}
}
