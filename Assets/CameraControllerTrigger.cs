using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;

public class CameraControllerTrigger : MonoBehaviour
{
    public CustomInspectorObject customInspectorObject;
    private Collider2D _colli;
    CameraManager cameraManager ;
    public void Start()
    {
        _colli = GetComponent<Collider2D>();
        cameraManager = CameraManager.Instant;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(customInspectorObject.panCameraOnContact)
            {
                cameraManager.panCameraOnContact(customInspectorObject.panDistance, customInspectorObject.panTime, customInspectorObject.panDirection, false);

            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) 
    {  //Caculate exitDirection 
        Vector2 exitDirection = (other.transform.position - _colli.bounds.center).normalized;
        if(other.CompareTag("Player"))
        {
            if(customInspectorObject.swapCamera && customInspectorObject.cameraOnLeft != null && customInspectorObject.cameraOnRight != null)
            {
                //swap camera;  
                cameraManager.SwapCamera(customInspectorObject.cameraOnLeft, customInspectorObject.cameraOnRight, exitDirection);


            }
            if(customInspectorObject.panCameraOnContact)
            {
                //pan the camera
                cameraManager.panCameraOnContact(customInspectorObject.panDistance, customInspectorObject.panTime, customInspectorObject.panDirection, true);

                
            }
        }
        
    }


}
[System.Serializable]
public class CustomInspectorObject
{
    public bool swapCamera = false;
    public bool panCameraOnContact = false;
    
    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;
    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 3f;
    [HideInInspector] public float panTime = 0.35f;

}

public enum PanDirection
{
    Up,
    Down,
    Left,
    Right,
}

[CustomEditor(typeof(CameraControllerTrigger))]
public class MyScriptEditor: Editor
{
    CameraControllerTrigger cameraControllerTrigger;
    private void OnEnable() 
    {
        cameraControllerTrigger = (CameraControllerTrigger)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        if(cameraControllerTrigger.customInspectorObject.swapCamera)
        {
            cameraControllerTrigger.customInspectorObject.cameraOnLeft =EditorGUILayout.ObjectField("Camera on Left", cameraControllerTrigger.customInspectorObject.cameraOnLeft, 
            typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;

            cameraControllerTrigger.customInspectorObject.cameraOnRight =EditorGUILayout.ObjectField("Camera on Right", cameraControllerTrigger.customInspectorObject.cameraOnLeft, 
            typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;

        }
        if(cameraControllerTrigger.customInspectorObject.panCameraOnContact)
        {
            cameraControllerTrigger.customInspectorObject.panDirection = (PanDirection)EditorGUILayout.EnumPopup("Camera Pan Direction", cameraControllerTrigger.customInspectorObject.panDirection);
            cameraControllerTrigger.customInspectorObject.panDistance = EditorGUILayout.FloatField("Pan Distance", cameraControllerTrigger.customInspectorObject.panDistance);  
                        cameraControllerTrigger.customInspectorObject.panTime = EditorGUILayout.FloatField("Pan Time", cameraControllerTrigger.customInspectorObject.panTime);  

        }

        if(GUI.changed)
        {
            EditorUtility.SetDirty(cameraControllerTrigger);
        }
        
    }
}