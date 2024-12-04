using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public static Slot selectSlot;
    

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage;  // 아이템의 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private TMP_Text itemInfo;
    private Image slotImage;

    public GameObject Paper1;
    public GameObject Book1;
    void Start()
    {
        slotImage = GetComponent<Image>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paper1.gameObject.SetActive(false);
            Book1.gameObject.SetActive(false);
            Debug.Log("힌트꺼짐");
        }
    }
    public void UseSlotItem()
    {
        if (item.itemType == Item.ItemType.Hint)
        {
            Paper1.gameObject.SetActive(true);
            Debug.Log("dd");
        }
        else if (item.itemType == Item.ItemType.Book)
        {
            Book1.gameObject.SetActive(true);
        }
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;  // 아이템 이미지를 설정

        // 아이템 타입에 따라 카운트 이미지 표시 여부 설정
        if (item.itemType == Item.ItemType.Equipment)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else if (item.itemType == Item.ItemType.Hint)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else if (item.itemType == Item.ItemType.Book)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();  
        }
    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;

        text_Count.text = "0";
        go_CountImage.SetActive(false);

        itemName.text = "";
        itemInfo.text = "";
    }

    // 마우스가 슬롯을 클릭했을 때 아이템 이름과 설명을 다시 출력
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            //이미 선택한 슬롯이 있다
            if(selectSlot != null)
                selectSlot.slotImage.color = Color.white;

            slotImage.color = Color.yellow;
            selectSlot = this;

            // 아이템 이름과 설명 출력
            itemName.text = item.itemName;
            itemInfo.text = item.itemInfo;

        }
        else
        {
            itemName.text = "";
            itemInfo.text = "";
        }
    }
}
