using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DmgKeyUI : MonoBehaviour
{
    [SerializeField] Sprite burst;
    [SerializeField] Sprite format;

    [SerializeField] GameObject AbilityManager;
    private AbilityManager ability;
    private Ability dmg;

    // Start is called before the first frame update
    void Start()
    {
        ability = AbilityManager.GetComponent<AbilityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dmg = ability.getDmgAbility();

        if (dmg.isUpgrade() == 0)
        {
            gameObject.GetComponent<Image>().sprite = burst;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = format;
        }
    }
}
