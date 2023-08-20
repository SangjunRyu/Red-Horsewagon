using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpeedChangeable
{
    float Speed { get; set; }   // 움직이는 것들의 속도 정의
    public void ChangeSpeed(float targetSpeed, float duration);    // 느려지는 효과를 위한 메서드
}
