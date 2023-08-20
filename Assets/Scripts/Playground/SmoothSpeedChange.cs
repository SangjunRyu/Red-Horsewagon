using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSpeedChange
{
    public IEnumerator SpeedChange(ISpeedChangeable changeable, float speed)
    {
        float initialSpeed = changeable.Speed;
        float targetSpeed = 0f;
        float duration = 2f;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            changeable.Speed = Mathf.Lerp(initialSpeed, targetSpeed, elapsedTime / duration); // 2초동안 속도줄이기
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        changeable.Speed = targetSpeed;
        yield return new WaitForSeconds(1f);
    }
}
