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

    public void SetTarget(Yggdrasil yggdrasil)
    {
        target = yggdrasil;
        this.yggdrasil = target.yggdrasil;

        transform.position = target.yggdrasil.gameObject.transform.position;

        updateUpgrade();

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
}
