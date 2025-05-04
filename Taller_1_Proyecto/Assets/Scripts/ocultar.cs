using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ocultar : MonoBehaviour
{
    public GameObject ocultarPanel;

    public void ocultarPANEL(){
        ocultarPanel.SetActive(false);
    }

    public void mostrarPANEL(){
        ocultarPanel.SetActive(true);
    }
}
