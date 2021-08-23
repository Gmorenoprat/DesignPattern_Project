using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IObservable
{
    private float _speed;
    private float _timeToDie;
    public Player owner;


    private IAdvance _movementType;

    List<IObserver> _allObserver;

    public float Speed { get { return _speed;}}

    #region Builders
    public Bullet SetType(IAdvance advance)
    {
        _movementType = advance;
        return this;
    }
    public Bullet SetSpeed(float speed)
    {
        _speed = speed;
        return this;
    }
    public Bullet SetTimeToDie(float timeToDie)
    {
        _timeToDie = timeToDie;
        return this;
    }
    public Bullet SetOwner(Player owner)
    {
        this.owner = owner;
        return this;
    }
    #endregion
  
    void Awake()
    {
        _allObserver = new List<IObserver>();
    }

    void Update()
    {
        //Movimiento
        if (_movementType != null)
            _movementType.Advance();

        //Lifetime
        _timeToDie -= Time.deltaTime;

        if (_timeToDie <= 0)
        {
            BulletSpawner.Instance.ReturnBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy e = collision.GetComponent<Enemy>();

        if (e)
        {
            NotifyToObservers("BulletHit");
            e.GetShot();
            BulletSpawner.Instance.ReturnBullet(this); 
        }
    }


    #region POOL
    //Funcion para agarrar una bullet del pool
    public static void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);  //La activo
    }

    //Funcion para devolver una bullet al pool
    public static void TurnOff(Bullet b)
    {
        b.Unsubscribe(b.owner);
        b.gameObject.SetActive(false); //La deshabilito

    }
    #endregion

    #region Interfaz IObservable

    public void Subscribe(IObserver obs)
    {
        if (!_allObserver.Contains(obs))
        {
            _allObserver.Add(obs);
        }
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObserver.Contains(obs))
        {
            _allObserver.Remove(obs);
        }
    }

    public void NotifyToObservers(string action)
    {
        for (int i = _allObserver.Count - 1; i >= 0; i--)
        {
            _allObserver[i].Notify(action);
        }
    }

    #endregion
}

