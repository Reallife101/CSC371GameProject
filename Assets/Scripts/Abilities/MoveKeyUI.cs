using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveKeyUI : MonoBehaviour
{
    [SerializeField] Sprite overclock;
    [SerializeField] Sprite teleport;

    [SerializeField] GameObject AbilityManager;
    private AbilityManager ability;
    private Ability movement;

    // Start is called before the first frame update
    void Start()
    {
        ability = AbilityManager.GetComponent<AbilityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = ability.getMovementAbility();

            if (movement.isUpgrade() == 0)
            {
                gameObject.GetComponent<Image>().sprite = overclock;
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = teleport;
            }
    }
}
