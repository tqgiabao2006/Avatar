using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    
public float fallSpeedYDampingChangeThreshold= - 15f;

[SerializeField] private CinemachineVirtualCamera[] _allVirtualCamera;
[Header("Controls for lerping Y Damping during jump/fall")]
[SerializeField] private float _fallPanAmounnt = 0.25f;
[SerializeField] private float _fallYPanTime = 0.35f;

public bool IsLerpingYDamping{get; private set;}
public bool LerpedFromPlayerFalling{get;set;}

private CinemachineVirtualCamera _currentCamera;
private Coroutine _lerpYPanCoroutine;
private Coroutine _panCameraCoroutine;
private CinemachineFramingTransposer _framingTransposer;

private float _normYPanAmount;
private Vector2 _startingTrackedObjectOffset;

private void Awake()
{
    for (int i = 0; i < _allVirtualCamera.Length; i++)
    {
        if(_allVirtualCamera[i].enabled)
        {
            //Set current active Camera
            _currentCamera = _allVirtualCamera[i];
            //Set current framingTransposer
            _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();   
        }
    }
    //Set the YDamping amount so it's based on the inspector value
    _normYPanAmount = _framingTransposer.m_YDamping;
    
    //set starting position of tracked object
    _startingTrackedObjectOffset = _framingTransposer.m_TrackedObjectOffset;
}

#region Lerp the Y Damping
public void LerpYDamping(bool isPlayerFalling)
{
    _lerpYPanCoroutine =StartCoroutine(LerpYAction(isPlayerFalling));

}
private IEnumerator LerpYAction(bool isPlayerFalling)
{
    IsLerpingYDamping = true;
    //grab the starting damping amout
    float startDampAmount = _framingTransposer.m_YDamping;
    float endDampAmount = 0f;

    if(isPlayerFalling)
    {
        endDampAmount = _fallPanAmounnt;
        LerpedFromPlayerFalling =true;
    }else
    {
        endDampAmount =_normYPanAmount;
    }

    float elaspTime = 0f;
    while(elaspTime < _fallYPanTime)
    {
        elaspTime += Time.deltaTime;
        float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elaspTime/ _fallYPanTime));
        _framingTransposer.m_YDamping =lerpedPanAmount;
        yield return null;

    }
    


}
    
#endregion


#region Pan Camera
public void panCameraOnContact(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
{
    _panCameraCoroutine = StartCoroutine(PanCamera(panDistance, panTime, panDirection, panToStartingPos));


}
private IEnumerator PanCamera(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
{
    Vector2 startPos = Vector2.zero;
    Vector2 endPos = Vector2.zero;

    //handle pan from trigger
    if(!panToStartingPos)
    {
        //set direction and distance
        switch(panDirection)
        {
            case PanDirection.Up: endPos = Vector2.up; break;
            case PanDirection.Down: endPos = Vector2.down; break;
            case PanDirection.Left: endPos = Vector2.left; break;
            case PanDirection.Right: endPos = Vector2.right; break;
            default: break;

        }
        endPos *= panDistance;
        startPos =_startingTrackedObjectOffset;
        endPos += startPos;
    }
    //handle the direction setting when moving back to the staating point
    else
    {
        startPos = _framingTransposer.m_TrackedObjectOffset;
        endPos= _startingTrackedObjectOffset;


    }
    float elaspTime =0f;
    while(elaspTime < panTime)
    {
        elaspTime += Time.deltaTime;
        Vector3 panLerp = Vector3.Lerp(startPos, endPos, (elaspTime/panTime));
        _framingTransposer.m_TrackedObjectOffset = panLerp;
        yield return null;
    }

}
#endregion


#region Swap Camera

public void SwapCamera(CinemachineVirtualCamera cameraFromLeft, CinemachineVirtualCamera cameraFromRight, Vector2 triggerExitDirection)
{
    if(_currentCamera == cameraFromLeft && triggerExitDirection.x >0)
    {
        //active new Camera
        cameraFromRight.enabled = true;
        //deactivate old camera
        cameraFromLeft.enabled = false;
        //Reset new camera
        _currentCamera = cameraFromRight;
        _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    //if camera on the right
     if(_currentCamera == cameraFromRight && triggerExitDirection.x  < 0)
    {
        //active new Camera
        cameraFromLeft.enabled = true;
        //deactivate old camera
        cameraFromRight.enabled = false;
        //Reset new camera
        _currentCamera = cameraFromLeft;
        _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
}
    
#endregion


}
