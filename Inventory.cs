using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;  // �κ��丮 Ȱ��ȭ ����. true�� �Ǹ� ī�޶� �����Ӱ� �ٸ� �Է��� ���� ���̴�.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting 

    private Slot[] slots;  // ���Ե� �迭

    private PlayerMove playermove; //playermove ������Ʈ ��Ȱ��ȭ

    //��Ʈ
    
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
                if (slots[i].item != null)  // null �̶�� slots[i].item.itemName �� �� ��Ÿ�� ���� ����
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

    public void UseButton() //������ ������ Ȯ���ϰ� �� �Լ��� �������ִ� �Լ�
    {
        if (Slot.selectSlot != null)
        {
            Debug.Log("���" + Slot.selectSlot.item.itemName);
            Slot.selectSlot.UseSlotItem();
        }
    }
}
