using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public TMP_Text interactionText;
    private MenuController menuController;
    public int interactionVal=1;

    private void Start()
    {
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }

    public void npcInteract()
    {
        if (interactionVal == 1)
        {
            interactionText.text = "Ave, I heard some news of combat up furthur on the line, I sure hope Varus show those Germans some real civilization.";
        }
        else if (interactionVal == 2)
        {
            interactionText.text = "Anyway, be careful, I heard some sounds of battle up ahead, just be ready for anything.";
        }
        else
        {
            //Exit interaction menu
            menuController.InteractionPanel.SetActive(false);
            menuController.GamePanel.SetActive(true);
        }
    }

    public void interactProgress()
    {
        interactionVal++;
        npcInteract();
    }
}
