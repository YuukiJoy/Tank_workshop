using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Picker : MonoBehaviour
{
    public ColorPaletteController cpc;
    public Material tankMaterial;
    
    public void ChangeColor(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            if (context.ReadValue<float>() > 0)
            {
                cpc.NextColor();
            }
            else
            {
                cpc.PreviousColor();
            }
            
        }
    }

    public void ChangeTankMaterial()
    {
        tankMaterial.SetColor("_TankColor", cpc.SelectedColor);
    }
}
