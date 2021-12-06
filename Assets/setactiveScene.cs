using UnityEngine;
using UnityEngine.SceneManagement;

public class setactiveScene : MonoBehaviour
{
    public Scene scene1;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(scene1);
    }
}
