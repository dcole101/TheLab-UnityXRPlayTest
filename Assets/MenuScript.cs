using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class MenuScript : MonoBehaviour
{
    public Renderer surfaceRenderer;
    public Image menuBackground;
    public TextMeshProUGUI scrollText;
    public TextMeshProUGUI fontSizeText;

    private float menuAlpha = 0.7f;

    public Canvas menuUI;
    private bool isMenuPressedDown = false;
    public void ChangeSurfaceColour_OnClick()
    {
        surfaceRenderer.material.color = Random.ColorHSV();
    }

    public void MenuColor_DropDown(int index)
    {
        Color indexColor = Color.black;

        if(index == 0) indexColor = Color.black;
        if (index == 1) indexColor = Color.red;
        if (index == 2) indexColor = Color.green;
        if (index == 3) indexColor = Color.blue;
        Debug.Log("index colour"+index);

        menuBackground.color = new Color(indexColor.r, indexColor.g, indexColor.b, menuBackground.color.a);
    }

    public void TransparentBG(bool isOn)
    {
       menuAlpha = isOn ? 0.7f : 1.0f;
        menuBackground.color = new Color(menuBackground.color.r, menuBackground.color.g, menuBackground.color.b, menuAlpha);
    }

    public void FontSize(float value)
    {
        scrollText.fontSize = value;
        fontSizeText.text = $"Font Size: {(int)value}";
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.MenuButton, out bool isPressed);
        if(isPressed)
        {
            if(!isMenuPressedDown)
            {
                menuUI.enabled = !menuUI.enabled;
            }
            isMenuPressedDown = true;
        }
        else
        {
            isMenuPressedDown = false;
        }
    }
}
