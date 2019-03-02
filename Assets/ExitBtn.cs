using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public GameObject GameObjectToExit;
        
    public void Exit()
    {
        GameObjectToExit.SetActive(false);
    }
}
