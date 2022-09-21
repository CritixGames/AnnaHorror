using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This flashyLight helper will change the light's color for the given time, and then restore the color back.
/// Then it will turn off and on the light over the given time period by flashCount times.
/// </summary>

public class FlashyLightHelper : MonoBehaviour
{
    public Light light;             // make the lights flashy and red.
    public Color originalLightColor;
    public Color newLightColor;

    [SerializeField]
    [MinAttribute(2)] int flashCount;
    public bool randomInterval = false;

    private void Start()
    {
        flashCount *= 2;
    }

    public IEnumerator FlashyLightEffect(float secs)
    {
        // first change the light color and turn the light off
        light.color = newLightColor;
        light.enabled = false;

        if (!randomInterval)
        {
            // evenly divide the given time
            for(int i = 0; i < flashCount; i++)
            {
                yield return new WaitForSeconds(secs / flashCount);
                // toggle light
                if (light.enabled) { light.enabled = false; }
                else { light.enabled = true; }
            }
        }
        else
        {
            // TODO: develop ramdon interval generator code
            /// Ideas:
            /// evently split secs into an array of small fractions
            /// for each element: 
            ///     calculate the subtraction amount, but no more than its value.
            ///     randomly generate a index (but not self) and add the subtraction amount to this number.
        }

        light.enabled = true;
        light.color = originalLightColor;
    }
}
