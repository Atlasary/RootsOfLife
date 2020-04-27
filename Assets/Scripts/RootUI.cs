using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootUI : MonoBehaviour
{
    private Root target;
    private RootBluePrint root;

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellCost;

    public Text repairCost;

    public void SetTarget(Root root)
    {
        target = root;
        this.root = target.root;

        transform.position = this.root.gameObject.transform.position;

        updateUpgrade();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    private void updateUpgrade()
    {
        if (!this.root.isUpgraded)
        {
            upgradeCost.text = "$ " + target.root.upgradePrice;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }
    }

    public void Upgrade()
    {
        target.UpgradeRoot();
    }

    public void Sell()
    {
        target.SellRoot();
    }

    public void Repair()
    {
        target.RepairRoot();
    }
}
