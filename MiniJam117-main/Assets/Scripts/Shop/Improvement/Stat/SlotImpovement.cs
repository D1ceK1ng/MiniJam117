using System.Globalization;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SlotImpovement : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;
    [SerializeField] private Image _finishedPanel;
    [SerializeField] private Image _closedPanel;
    private Ability _ability;
    private Wallet _wallet;
    public Ability Ability { get => _ability; set => _ability = value; }
    public event Action<SlotImpovement> OnBuy;
    private void Awake() 
    {
        _wallet = FindObjectOfType<Wallet>();
    }
    public void BuyAbility()
    {
        OnBuy?.Invoke(this);
        _wallet.DecreaseCountMoney(_ability);
        MakeSlotInStock();
    }
    public void MakeSlotInStock()
    {
        _button.onClick.RemoveListener(BuyAbility);
        _finishedPanel.gameObject.SetActive(true);
        TryClosingPanel(_closedPanel);
    }
    public void TurnOff() => _canvasGroup.ChangeStateOfCanvasGroup(false);
    private void TryClosingPanel(Image image)
    {
        if (image.gameObject.activeInHierarchy)
        {
             image.gameObject.SetActive(false);
        }
    }
    public void SetAvableSlot() 
    {
        _button.onClick.AddListener(BuyAbility);
        TryClosingPanel(_finishedPanel);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

}
