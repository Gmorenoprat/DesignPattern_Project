using UnityEngine;

public class SinuousAdvance : IAdvance
{
    float _speed = 3;
    float _frecuencia = 9f;
    float _magnitud = 0.04f;
    Transform _xf;

    public float SetSpeed { set { _speed = value; } }
    public Transform SetTransform { set { _xf = value; } }

    public void Advance()
    {
        var pos = _xf.position;
        pos += _xf.right * Time.deltaTime * _speed;
        _xf.position = pos + _xf.up * Mathf.Sin(Time.time * _frecuencia) * _magnitud;
      
    }
}


