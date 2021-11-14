using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrowdConKeyUI : MonoBehaviour
{
    [SerializeField] Sprite underclock;
    [SerializeField] Sprite root;

    [SerializeField] GameObject AbilityManager;
    private AbilityManager ability;
    private Ability crowdCon;

    // Start is called before the first frame update
    void Start()
    {
        ability = AbilityManager.GetComponent<AbilityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        crowdCon = ability.getCrowdControlAbility();

        if (crowdCon.isUpgrade() == 0)
        {
            gameObject.GetComponent<Image>().sprite = underclock;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = root;
        }
    }
}
