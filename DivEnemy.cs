using UnityEngine;

public class DivEnemy : Enemy, IPrototype
{
    bool _cloned = false;
    float _scaleMuliplier = 0.5f;
    float _distanceToClone = 1.5f;
    bool wasCloned { 
        get { return _cloned; } 
        set { _cloned = value; }
    }

    public int cantClones = 2;

    public override void GetShot()
    {
        if (!wasCloned)
        {
            for (int i = 0; i < cantClones; i++)
            { 
                Clone();
            }
        }
    
        base.GetShot();
        Reset();
    }

    public IPrototype Clone()
    {

        DivEnemy e = (DivEnemy)Instantiate(this)
            .setSpeed(FlyWeightPointer.MiniAsteroid.speed)
            .setTarget(FindObjectOfType<Player>().transform)
            .setScale(_scaleMuliplier)
            .setPosition(this.transform.position + new Vector3(Random.Range(0, _distanceToClone), Random.Range(0, _distanceToClone), 0))
            .setScore(FlyWeightPointer.MiniAsteroid.score);

        e.wasCloned = true;

        e.transform.parent = EnemySpawner.Instance.transform; 

        return e;
    }

    public void Reset()
    {
        wasCloned = false;
        this.transform.localScale = new Vector3(1, 1, 1);
        this.setSpeed(FlyWeightPointer.Asteroid.speed)
            .setScore(FlyWeightPointer.Asteroid.score);
    }
}
