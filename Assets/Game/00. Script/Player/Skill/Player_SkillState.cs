using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SkillState : State_Base
{

PlayerController _playerController;
[SerializeField] public List<Skill_Base> _skillSet = new List<Skill_Base>();
List<string> _skillNames = new List<string>();
 [SerializeField]private int  _skillCounter;
 [SerializeField] private float skillResetTime = 1f;
 [SerializeField] private float skillTransition = 0.1f;
 
 private float _lastTimeClicked = 0;
  AnimatorStateInfo stateInfo;
 
     [SerializeField] private float transitionTime  = 0.1f;
     private float transitionTimeCounter;

    void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
        _playerController = _core.GetComponent<PlayerController>();
        transitionTimeCounter = 0;
        _skillCounter = 0;
        
        
        foreach(Skill_Base skill in _skillSet)
        {
            _skillNames.Add(skill.name);
        }
    }
   
    private void Update()
    { print(_skillCounter);
        
        isSKilling(_skillCounter);
         if(Input.GetMouseButtonDown(0) && Time.time  - _lastTimeClicked >= transitionTime)
       {
          ProduceAnimation(_skillCounter); 
       }
        SkillCounter();

        //Timer: Calculate the transition between each attacks:
        transitionTimeCounter-= Time.deltaTime;
    }
    public override void Do()
    {
        stateInfo = _playerController._anim.GetCurrentAnimatorStateInfo(0);
        ResetTheCounter();
    }
    private void isSKilling(int skillCounter)
    {
        if(Input.GetMouseButton(0) || IsAnimationPlaying(_skillNames[skillCounter]))
        {
            _playerController.isSkilling = true;
    
        }
        else if(!IsAnimationPlaying(_skillNames[skillCounter]))
        {
            _playerController.isSkilling = false;
        }
    }
    private void ResetTheCounter()
    {
        if(Time.time - _lastTimeClicked >= skillResetTime || _skillCounter >= _skillNames.Count)
        {
            _isComplete = true;
        }

    }
    private bool IsAnimationPlaying(string clipName)
    {
        // Get the current animator state info
        AnimatorStateInfo currentstateInfo = _anim.GetCurrentAnimatorStateInfo(0);
        
        // Check if the currently playing animation matches the specified clip name
        return currentstateInfo.IsName(clipName);
    }



    private void ProduceAnimation(int SkillIndex)
    {
         _playerController._anim.Play(_skillNames[SkillIndex]);

    }
    private void SkillCounter()
    {
        if(Input.GetMouseButton(0) && ((_skillCounter == 0) || (stateInfo.normalizedTime >1.0f && transitionTimeCounter <=0)))
        {   
            if(_skillCounter +1 < _skillNames.Count)
            {
                _skillCounter++;


            }else
            {  //resetSKillcounter;
                _skillCounter =0;
            }

            transitionTimeCounter = transitionTime;
            _lastTimeClicked = Time.time;
           
        }
    
        
    }



}

    
 