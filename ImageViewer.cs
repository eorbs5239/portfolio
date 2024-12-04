using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] showSprites;
    public Image imageViewer;
    public Button leftButton;
    public Button rightButton;
    public Button centerButton;

    private int Index = 0;
    private bool isFullScreen = false;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = imageViewer.transform.localScale;
        UpdateImage();

        leftButton.onClick.AddListener(ShowPreviousImage);
        rightButton.onClick.AddListener(ShowNextImage);
        centerButton.onClick.AddListener(ShowFullScreen);
        shownumber();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateImage()
    {
        if (showSprites.Length > 0 && Index >= 0 && Index < showSprites.Length)
        {
            imageViewer.sprite = showSprites[Index];
        }
    }

    public void shownumber()
    {
        imageViewer.sprite = showSprites[0];
    }

    private void ShowPreviousImage()
    {
        Index--;
        if (Index < 0)
        {
            Index = showSprites.Length - 1;
        }
        UpdateImage();
    }
    private void ShowNextImage()
    {
        Index++;
        if (Index >= showSprites.Length)
        {
            Index = 0;
        }
        UpdateImage();
    }

    private void ShowFullScreen()
    {
        isFullScreen = !isFullScreen;
        if (isFullScreen)
        {
            imageViewer.transform.localScale = new Vector3(2, 2);
        }
        else
        {
            imageViewer.transform.localScale = originalScale;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        return;
    }
}
