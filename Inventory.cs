using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;  // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 

    private Slot[] slots;  // 슬롯들 배열

    private PlayerMove playermove; //playermove 컴포넌트 비활성화

    //힌트
    
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        playermove = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        TryOpenInventory();
    }


    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
            {
                OpenInventory();
                Cursor.lockState = CursorLockMode.None;

            }

            else
            {
                CloseInventory();
                Cursor.lockState = CursorLockMode.Locked;
            }


        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
        playermove.enabled = false;
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
        playermove.enabled = true;
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots[i].item == _item)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    public void UseButton() //선택한 슬롯을 확인하고 그 함수를 실행해주는 함수
    {
        if (Slot.selectSlot != null)
        {
            Debug.Log("사용" + Slot.selectSlot.item.itemName);
            Slot.selectSlot.UseSlotItem();
        }
    }
}
