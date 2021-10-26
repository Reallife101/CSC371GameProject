using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    public HighlightPlus.HighlightEffect he;
    public abstract void selected();

    public abstract void deselected();
}
