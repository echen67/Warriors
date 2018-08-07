using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    public GameObject inventoryPanel;
    private CanvasGroup canvasGroup;
    //private RectTransform rectTransform;
    public bool toggle;

    void Start () {
        canvasGroup = inventoryPanel.GetComponent<CanvasGroup>();
        //rectTransform = inventoryPanel.GetComponent<RectTransform>();
        toggle = false;
        Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toggle = !toggle;
            if (toggle)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        toggle = !toggle;
        if (toggle)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Hide()
    {
        canvasGroup.alpha = 0f;
        //canvasGroup.blocksRaycasts = false;
        //canvasGroup.interactable = false;
        //rectTransform.sizeDelta = new Vector2(0, 0);
    }

    void Show()
    {
        canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
        //canvasGroup.interactable = true;
        //rectTransform.sizeDelta = new Vector2(475f, 475f);
    }

}
