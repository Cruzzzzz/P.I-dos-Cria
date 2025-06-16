using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

}