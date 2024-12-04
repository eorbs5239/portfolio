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
    

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� �������� ����
    public Image itemImage;  // �������� �̹���

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
            Debug.Log("��Ʈ����");
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

    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;  // ������ �̹����� ����

        // ������ Ÿ�Կ� ���� ī��Ʈ �̹��� ǥ�� ���� ����
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

    // �ش� ������ ������ ���� ������Ʈ
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

    // ���콺�� ������ Ŭ������ �� ������ �̸��� ������ �ٽ� ���
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            //�̹� ������ ������ �ִ�
            if(selectSlot != null)
                selectSlot.slotImage.color = Color.white;

            slotImage.color = Color.yellow;
            selectSlot = this;

            // ������ �̸��� ���� ���
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
