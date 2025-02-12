using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack_State : State_Base
{
    PlayerController _playerController;
    [SerializeField ] Skill_Base _jumpAttackData;

   private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();

    }

    public override void Enter()
    {
       if(_playerController.isJUmpAttacking) return;
       StartCoroutine(Trigger());
    }

    private IEnumerator Trigger()
    {
      _playerController.isJUmpAttacking = true;
      float iniGravityScale = _playerController._rb.gravityScale;
      _playerController._rb.velocity = Vector2.zero;
      _playerController._rb.gravityScale = 0;
      _playerController._anim.Play(_jumpAttackData.name);
      yield return new WaitForSeconds(_jumpAttackData.animationClip.length);
      _playerController._rb.gravityScale = iniGravityScale;
      _playerController.isJUmpAttacking = false;
      _isComplete = true;
    

    }

}
