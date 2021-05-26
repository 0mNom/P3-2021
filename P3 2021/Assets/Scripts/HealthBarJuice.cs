using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarJuice : MonoBehaviour
{

    public Slider Healthbar;
    public Slider HealthJuice;
    private float CurrentValue;
    private float TargetValue;
    public float Delay = 0.5f;
    public float Speed = 1f;


    private void Awake()
    {
        
    }

    

    public void StartJuice()
    {
        TargetValue = Healthbar.value;
        CurrentValue = HealthJuice.value;

        StopAllCoroutines();

        StartCoroutine(Juice(CurrentValue, TargetValue, Speed));
    }

    IEnumerator Juice(float CurVal, float TargVal, float Duration)
    {
        float elapsed = 0f;

        yield return new WaitForSeconds(Delay);

        while (elapsed < Speed)
        {
            elapsed += Time.deltaTime;
            HealthJuice.value = Mathf.Lerp(CurVal, TargVal, elapsed / Duration);

            yield return null;

        }

        HealthJuice.value = TargetValue;
    }
}
