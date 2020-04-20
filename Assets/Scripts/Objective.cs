using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour{
	
	public GameObject manager;
	public Text Objective1Text;
	public bool wave = false;
	public Text Objective2Text;
	
	
	void Update () {
		if (manager.GetComponent<PlayerStats>().startMoney != PlayerStats.money){
			Objective1Text.text = "Achieved";
		}
		if (WaveSpawner.EnemiesAlive!=0 && wave==false){
			wave=true;
		}
		if (WaveSpawner.EnemiesAlive == 0 && wave==true){
			Objective2Text.text = "Achieved";
		}
		
	}

}