using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YggdrasilUI : MonoBehaviour
{
    private Yggdrasil target;
    private YggdrasilBlueprint yggdrasil;

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text extendCost;

    public RootBluePrint rootPrefab;

    public void SetTarget(Yggdrasil yggdrasil)
    {
        target = yggdrasil;
        this.yggdrasil = target.yggdrasil;

        transform.position = target.yggdrasil.gameObject.transform.position;

        updateUpgrade();
        updateExtend();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    private void updateUpgrade()
    {
        if (!yggdrasil.isUpgraded)
        {
            upgradeCost.text = "$ " + target.yggdrasil.upgradePrice;
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
        target.UpgradeYggdrasil();
    }

    private void updateExtend()
    {
        extendCost.text = rootPrefab.price.ToString();
    }

    public void Extend()
    {
        target.ExtendYggdrasil();
    }
}
