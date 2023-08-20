using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpeedChangeable
{
    float Speed { get; set; }   // �����̴� �͵��� �ӵ� ����
    public void ChangeSpeed(float targetSpeed, float duration);    // �������� ȿ���� ���� �޼���
}
