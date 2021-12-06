using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DescriptionText : MonoBehaviour
{
    [SerializeField] string text = "Press F or leave the Range of the Weapon Rack to close.";
    [SerializeField] TMP_Text text_field;

    [SerializeField] LayerMask targetLayer;
    [SerializeField] string targettag = "WeaponRackButton";

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        text_field = GetComponent<TMP_Text>();
        text_field.text = text;

        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = gameObject.GetComponentInParent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        bool hit = false;

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.tag.Equals(targettag))
            {
                hit = true;
                UITextHolder desc = result.gameObject.GetComponent<UITextHolder>();
                text_field.text = desc.GetText();
            }
        }

        if (!hit)
        {
            text_field.text = text;
        }
    }
}
