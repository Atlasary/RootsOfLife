using System;
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
    public Button repairButton;

    public void SetTarget(Root root)
    {
        target = root;
        this.root = target.root;

        transform.position = this.root.gameObject.transform.position + new Vector3(0, 20f, 0);

        updateUpgrade();
        updateRepair();
        updateSell();

        ui.SetActive(true);
    }


    public void Hide()
    {
        ui.SetActive(false);
    }

    private void updateUpgrade()
    {
        if (!root.isUpgraded)
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

    private void updateSell()
    {
        int cost = root.isUpgraded ? root.price + root.upgradePrice : root.price;
        sellCost.text = "$ " + (.7 * cost);
    }

    public void Sell()
    {
        target.SellRoot();
    }

    private void updateRepair()
    {
        Debug.Log("repair");
        if(root.currentHealth < root.health)
        {
            repairCost.text = "$ " + (root.health - root.currentHealth) * root.repairPrice;
            repairButton.interactable = true;
        } else
        {
            repairCost.text = "$ 0";
            repairButton.interactable = false;
        }
    }

    public void Repair()
    {
        target.RepairRoot();
    }
}
