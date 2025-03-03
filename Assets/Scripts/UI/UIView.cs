using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Toggle shopToggle;
    [SerializeField] private TextMeshProUGUI shoppOrInventoryText;
    [SerializeField] private CanvasGroup itemDeatilsPanelCanvasGroup;
    [SerializeField] private CanvasGroup sellSection;

    [Header("Item Properties")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemRarityText;
    [SerializeField] private TextMeshProUGUI itemWeightText;
    [SerializeField] private TextMeshProUGUI quantityAvailableText;
    [SerializeField] private TextMeshProUGUI itemBuyingPriceText;
    [SerializeField] private TextMeshProUGUI itemSellingPriceText;

    private UIController uiController;

    private void OnDisable()
    {
        EventService.Instance.OnItemSelectedEventWithParams.RemoveListener(uiController.SetItemDetailsPanel);
    }

    public void OnShopToggleChanged(bool isOn)
    {
        uiController.OnShopToggleChanged(isOn);
        itemDeatilsPanelCanvasGroup.alpha = 0;
    }

    public void UpdateShopORInventoryText(bool isShopOpen)
    {
        shoppOrInventoryText.text = isShopOpen ? "Shop" : "Inventory";
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SetUIController(UIController uiController)
    {
        this.uiController = uiController;
        EventService.Instance.OnItemSelectedEventWithParams.AddListener(uiController.SetItemDetailsPanel);
    }

    public void SetItemDetailPanelView(bool isOn, ItemView itemView)
    {
        if (isOn)
        {
            itemDeatilsPanelCanvasGroup.alpha = 1;
            SetItemDetailPanelValues(itemView);
            EventService.Instance.OnItemSelectedEvent.InvokeEvent();
        }
    }

    public void SetItemDetailPanelValues(ItemView itemView)
    {
        itemName.text = itemView.itemProperty.itemName;
        itemImage.sprite = itemView.itemProperty.itemIcon;
        itemTypeText.text = FormatEnumText(itemView.itemProperty.item);
        itemRarityText.text = FormatEnumText(itemView.itemProperty.rarity);
        itemWeightText.text = itemView.itemProperty.weight.ToString();
        quantityAvailableText.text = uiController.GetQuantity().ToString();
        itemDescriptionText.text = itemView.itemProperty.ItemDescription;
        itemBuyingPriceText.text = itemView.itemProperty.buyingPrice.ToString();
        itemSellingPriceText.text = itemView.itemProperty.sellingPrice.ToString();
    }

    public void DisableItemDetailsPanel() => itemDeatilsPanelCanvasGroup.alpha = 0;

    private string FormatEnumText(Enum enumValue)
    {
        return System.Text.RegularExpressions.Regex.Replace(enumValue.ToString(), "(\\B[A-Z])", " $1");
    }
}