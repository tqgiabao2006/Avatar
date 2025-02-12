using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    CinemachineImpulseDefinition impulseDefinition;
    [SerializeField] private CinemachineImpulseListener impulseListener;

   
      public void CameraShake(CinemachineImpulseSource impulseSource, SO_CameraShake SO_CameraShake)
    {
        impulseSource.GenerateImpulseWithForce(SO_CameraShake.impactForce);
    }
    private void SetupCameraShake(CinemachineImpulseSource impulseSource, SO_CameraShake SO_CameraShake)
    {
        impulseDefinition = impulseSource.m_ImpulseDefinition;

        //Change Impulse source settings
        impulseDefinition.m_ImpulseDuration = SO_CameraShake.impactTime;
        impulseDefinition.m_CustomImpulseShape = SO_CameraShake.impulseCurve;
        impulseSource.m_DefaultVelocity = SO_CameraShake.defaultVelocity;   

        //Change Impulse listener settings
        impulseListener.m_ReactionSettings.m_AmplitudeGain = SO_CameraShake.listenerAmplitude;
                impulseListener.m_ReactionSettings.m_Duration = SO_CameraShake.listenerDuration;
                        impulseListener.m_ReactionSettings.m_FrequencyGain = SO_CameraShake.listenerFrequency;  



    }

   
}
