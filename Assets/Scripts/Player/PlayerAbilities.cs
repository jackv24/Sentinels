using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour {
	public Abilities ability;
		public enum Abilities
	{
		NormalShoot,
		MultiShot,
		Blink,
		FreezingFire,
		RapidFire,
		SelfRepair,
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  switch(ability)
		{
		case Abilities.NormalShoot: 
				break;
		case Abilities.MultiShot:
			break;

		case Abilities.Blink:
			break;

		case Abilities.FreezingFire:
			break;

		case Abilities.RapidFire:
			break;

		case Abilities.SelfRepair:
			break;
		}
		
	}
}
