using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
   public static float Map(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp)
   {
     float newValue =  (value - originalMin) / (originalMax - originalMin) * (newMax - newMin )+newMin;
     if(clamp)
     {
        newValue = Mathf.Clamp(newValue, newMin, newMax);
     }
     return newValue;
   //   float newValue = newMin +  (newMax - newMin) * ((value - originalMin)/ (originalMax -originalMin));
   //   return clamp ? Mathf.Clamp(newValue, Mathf.Min(newMin, newMax), Mathf.Max(newMin, newMax)) : newValue;
   }
}
