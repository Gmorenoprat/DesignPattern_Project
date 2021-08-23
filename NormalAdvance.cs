using UnityEngine;

public class NormalAdvance : IAdvance
{
    float _speed = 5;
    Transform _xf;

    public float SetSpeed{ set { _speed = value; } }
    public Transform SetTransform{ set { _xf = value; } }


    public void Advance()
    {
        _xf.transform.position += _xf.right * _speed * Time.deltaTime;
    }

}
