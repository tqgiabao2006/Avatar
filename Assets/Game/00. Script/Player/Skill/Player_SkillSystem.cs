using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SkillSystem : State_Base
{
    [SerializeField] List<Skill_Base> _skillSet = new List<Skill_Base>();
    private List<string> _skillNames = new List<string>();
    [SerializeField]private int  _skillCounter;
    [SerializeField] private float _skillResetTime = 1f;
    [SerializeField] private float _skillTransition = 0.1f;
    private float _transitionTimeCounter;

    
    [SerializeField] Player_SkillState _playerSkillState;
     private float _lastTimeClicked = 0;
     PlayerController _playerController;
    AnimatorStateInfo _stateInfo;


     private void Start()
     {
        //SetUp:
        _playerController = _core.GetComponent<PlayerController>();

        foreach(Skill_Base skills in _skillSet)
        {
            _skillNames.Add(skills.name);
        }

     }
     private void Update()
     {
       

        //Timer: TransitionTime;
        _transitionTimeCounter -= Time.deltaTime;

        //Trigger Aniamtion:
        if(Input.GetMouseButtonDown(0) && _playerController._onGround)
         {            
            _playerController._anim.Play(_skillNames[_skillCounter]);
            _skillCounter++;
            _playerController.isSkilling = true;
            _lastTimeClicked = Time.time;
            _transitionTimeCounter = _skillTransition;
         }
         //SkillReset
         SkillReset();

         //Check if player perform skill:
         isSkilling();

         


     }
      private void isSkilling()
     {
        //Check isSkilling to RETURN -> PlayerController:
       if(_playerController._anim.GetCurrentAnimatorStateInfo(0).normalizedTime >1.0f || !_playerController._onGround)
        {
            _playerController.isSkilling = false;
            _isComplete = true;

        }
     }
    private void SkillReset()
    {   
         if(Time.fixedTime - _lastTimeClicked >= _skillResetTime || _skillCounter >=_skillSet.Count)
         {
            _skillCounter = 0;
         }
    }

    



}
