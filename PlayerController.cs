using UnityEngine;
public class PlayerController : IController
{
    Player _player;
    public PlayerController(Player p)
    {
        _player = p;
    }

    public void OnUpdate()
    {

        _player.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
        //Disparo
        if (Input.GetMouseButtonDown(0))
        {
            _player.ShootNormal();
        }
        //Disparo Sinuoso
        if (Input.GetMouseButtonDown(1))
        {
            _player.ShootSinuous();
        }

    }
}
