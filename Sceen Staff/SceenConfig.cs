using UnityEngine;

public class SceenConfig : MonoBehaviour
{ 

  public Transform mainGame;
  ScreenManag _mgr;
  bool _paused = false;


  private void Start()
  {
        _mgr = ScreenManag.Instance;

        _mgr.Push(new ScreenGO(mainGame));
   }

  private void Update()
  {

        
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && !_paused)
        {
            var s = Instantiate(Resources.Load<ScreenPause>("CanvasPause")); 
            _mgr.Push(s);
            _paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _mgr.Pop();
            _paused = false;
        }
    }
}
