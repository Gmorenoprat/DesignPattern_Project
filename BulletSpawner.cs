using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner Instance
    {
        get { return _instance;}
    }

    static BulletSpawner _instance;

    public Bullet bulletPrefab; 
    public int bulletStock = 5; 

    public ObjectPool<Bullet> pool; 

    void Start()
    {
        _instance = this;

        pool = new ObjectPool<Bullet>(BulletFactory, Bullet.TurnOn, Bullet.TurnOff, bulletStock, true);
    }

    public Bullet BulletFactory()
    {
       
        Bullet b = Instantiate(bulletPrefab);
        b.transform.parent = this.transform;
        return b;
        
    }
    public void ReturnBullet(Bullet b)
    {
        pool.ReturnObject(b);
    }
}
