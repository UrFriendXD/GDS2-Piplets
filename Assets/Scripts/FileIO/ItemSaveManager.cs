using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
	[SerializeField] ItemDatabase itemDatabase;

	private const string InventoryFileName = "Inventory";
	//private const string EquipmentFileName = "Equipment";

	public void Awake()
	{
		ServiceLocator.Current.Get<SaveManager>().ItemSaveManager = this;
		ServiceLocator.Current.Get<SaveManager>().ItemDatabase = itemDatabase;
	}

	public void LoadInventory(PlayerScript character)
	{
		ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);
		if (savedSlots == null) return;
		character.inventory.Clear();

		for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
		{
			ItemSlot itemSlot = character.inventory.ItemSlots[i];
			ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

			if (savedSlot == null)
			{
				itemSlot.Item = null;
				itemSlot.Amount = 0;
			}
			else
			{
				itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
				itemSlot.Amount = savedSlot.Amount;
			}
		}
	}

	// public void LoadEquipment(Character character)
	// {
	// 	ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName);
	// 	if (savedSlots == null) return;
	//
	// 	foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
	// 	{
	// 		if (savedSlot == null) {
	// 			continue;
	// 		}
	//
	// 		Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
	// 		character.Inventory.AddItem(item);
	// 		character.Equip((EquippableItem)item);
	// 	}
	// }

	public void SaveInventory(PlayerScript character)
	{
		SaveItems(character.inventory.ItemSlots, InventoryFileName);
	}

	// public void SaveEquipment(Character character)
	// {
	// 	SaveItems(character.EquipmentPanel.EquipmentSlots, EquipmentFileName);
	// }

	private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
	{
		var saveData = new ItemContainerSaveData(itemSlots.Count);

		for (int i = 0; i < saveData.SavedSlots.Length; i++)
		{
			ItemSlot itemSlot = itemSlots[i];

			if (itemSlot.Item == null) {
				saveData.SavedSlots[i] = null;
			} else {
				saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
			}
		}

		ItemSaveIO.SaveItems(saveData, fileName);
	}
}
