using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake current;

    private void Awake()
    {
        current = this;
    }
    public void CameraTremor(float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float x = Random.Range(-1f, 1f) * magnitude;
        float y = Random.Range(-1f, 1f) * magnitude;

        transform.localPosition = new Vector3(x, y, originalPos.z);
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0;
        

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;

        }
        
        transform.localPosition = new Vector3(0f, 0f, originalPos.z);
    }
}
