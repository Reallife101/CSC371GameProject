
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//You need to use the UnityEngine.UI namespace in order to manipulate the UI.
using UnityEngine.UI;
public class Activate_Tower : MonoBehaviour
{ //We need an Image Variable so the script knows what image to change
    public Image clickMeter;

    //We need variables for the maximum the meter can fill and also the current meter number.
    public float curMeter, maxMeter;

    //We need a variable that increases the value of the meter
    public float incMeter;

    //We also need a float that decreases the value of the meter.
    public float decMeter;

    //This next part can be done in multiple ways, but for ease of use we will
    //add a new float to determine the time between clicks.
    public float meterReduceTimer;

    //We need a float to determine how many frames between clicks until the Meter starts to
    //reduce
    public float timeBetweenClicks;



    //All of those floats can be accessed in the inspector of the Game Object this script is attached too.


    //Now we need to add an Input listener if Statement to determine if your mouse button has been clicked
    //I will make a new Method called "Clicking"

    //We need to say that every click down adds points so in your if statement we will add a float increase.
    //We will also reduce the meterReduceTimer to 0

    //We will add another Method called "ReduceMeter" and say if the player has not clicked for a certain amount of frames
    //start decreasing the meter.


    //Now we need to tell the image what % it should be at. We will do this in a new Method called ImageChange.

    //We need to make sure that the curMeter value cannot be less then 0 and cannot be more than the max. I will do this in a method called MaxMinValue

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ImageChange();
        MaxMinValue();
        Clicking();
        ReduceMeter();
    }

    void Clicking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("I got to press down");
            curMeter += incMeter;
            meterReduceTimer = 0;
        }
    }

    void ReduceMeter()
    {
        //Meter Reduce Timer will increase by one every frame, this is very fast,
        //so let's give a bit of leeway before the meter decreases. 10 frames seems nice.

        meterReduceTimer += 1;
        if (meterReduceTimer > timeBetweenClicks)
        {
            curMeter -= decMeter;
        }
    }

    void ImageChange()
    {
        //The image fill amount is CurrentMeter divided by MaxMeter
        clickMeter.fillAmount = curMeter / maxMeter;
    }

    void MaxMinValue()
    {

        //if current meter is less than 0 then current meter equals 0.
        //if current meter is more than max meter then current meter equals max meter

        if (curMeter < 0)
        {
            curMeter = 0;
        }
        else if (curMeter > maxMeter)
        {
            curMeter = maxMeter;
        }
    }
}
