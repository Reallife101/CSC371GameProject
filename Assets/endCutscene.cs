using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCutscene : MonoBehaviour
{
    [SerializeField] string sc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endScene(36f));
    }

    private IEnumerator endScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sc);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(sc);
        }
    }
}
