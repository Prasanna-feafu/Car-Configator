using UnityEngine;
using UnityEngine.UI;

public class CarCustomization : MonoBehaviour
{
    public PlaneDetectionController trackingToggle;
    public ARPlacement controller;
    public Animator[] carDoor;
    public RawImage uiToggle, doorToggle;
    public Texture uiOn, uiOff, doorOn, doorOff;
    public GameObject[] uiElement, bodyColor, rimColor, mainCar, carRim;
    public Material[] carColors, rimColors;
    bool uiCondition, testCondition, animateState;

    private void Start()
    {
        uiCondition = false;
        testCondition = false;
        animateState = false;
        for(int i = 0; i < uiElement.Length; i++)
        {
            uiElement[i].SetActive(false);
        }
        
        for(int i = 0; i < bodyColor.Length; i++)
        {
            bodyColor[i].SetActive(false);
            rimColor[i].SetActive(false);
        }
    }

    public void UIToggle()
    {
        uiCondition = !uiCondition;
        if(uiCondition)
        {
            uiToggle.texture = uiOn;
        }
        else
        {
            uiToggle.texture = uiOff;
        }
        for(int i = 0; i < uiElement.Length; i++)
        {
            uiElement[0].SetActive(uiCondition);
        }
    }

    public void EnableColorBoard(int state)
    {
        if(state == 0)
        {
            for (int i = 0; i < bodyColor.Length; i++)
            {
                bodyColor[i].SetActive(true);
            }
        }
        else if(state == 1)
        {
            for (int i = 0; i < rimColor.Length; i++)
            {
                rimColor[i].SetActive(true);
            }
        }
    }

    public void TestDrive()
    {
        testCondition = !testCondition;
        uiElement[0].SetActive(!uiCondition);
        uiElement[1].SetActive(uiCondition);
    }

    public void DrivingClose()
    {
        uiElement[0].SetActive(uiCondition);
        uiElement[1].SetActive(!uiCondition);
    }

    public void SpawnReset()
    {
        controller.spawnControl = false;
        controller.placementParent.SetActive(false);
        trackingToggle.TrackingToggle();
    }

    public void DoorAnimate()
    {
        animateState = !animateState;
        if(animateState)
        {
            doorToggle.texture = doorOn;
        }
        else
        {
            doorToggle.texture = doorOff;
        }
        for(int i = 0; i < carDoor.Length; i++)
        {
            carDoor[i].SetBool("DoorOpen", animateState);
        }
    }

    public void ColorChanges(int state)
    {
        if(mainCar != null)
        {
            mainCar = GameObject.FindGameObjectsWithTag("Colors");
        }

        for (int i = 0; i < mainCar.Length; i++)
        {
            mainCar[i].GetComponent<MeshRenderer>().material = carColors[state];
            bodyColor[i].SetActive(false);
        }
    }

    public void RimColorChanges(int state)
    {
        if(carRim != null)
        {
            carRim = GameObject.FindGameObjectsWithTag("CarRim");
        }
        for (int i = 0; i < carRim.Length; i++)
        {
            carRim[i].GetComponent<MeshRenderer>().material = rimColors[state];
            rimColor[i].SetActive(false);
        }
    }
}
