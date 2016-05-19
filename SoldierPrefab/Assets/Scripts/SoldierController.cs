using UnityEngine;
using System.Collections;

public class SoldierController : MonoBehaviour {

    private Animator animator;

    private readonly string VSPEED = "VSpeed";
    private readonly string DIRECTION = "Direction";
    private readonly string WALK = "Walk";
    private readonly string FIRE = "Fire";
    private readonly string RELOAD = "Reload";

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //attachWeaponToSoldierWrist();

    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat(VSPEED, Input.GetAxis("Vertical"));
        animator.SetFloat(DIRECTION, Input.GetAxis("Horizontal"));
        //attachWeaponToSoldierWrist();


        updateWalkState();
        refreshFireState();
        reloadWeapon();
	}

    public Transform weaponTrigger;
    public Transform weaponFrontGrip;

    public Transform soldierRightIndex;
    public Transform soldierLeftHand;
    


    private void attachWeaponToSoldierWrist()
    {
        weaponFrontGrip = GameObject.Find("Assault_Rifle_A3_v2/front_grip").transform;
        weaponTrigger = GameObject.Find("Assault_Rifle_A3_v2/trigger").transform;

        soldierLeftHand = GameObject.Find("swat:LeftHand").transform;
        soldierRightIndex = GameObject.Find("swat:RightHandIndex2").transform;

        weaponTrigger.position = soldierRightIndex.position;
        weaponTrigger.rotation = soldierRightIndex.rotation;

        weaponFrontGrip.position = soldierLeftHand.position;
        weaponFrontGrip.rotation = soldierLeftHand.rotation;

    }

    private void updateWalkState()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool(WALK, true);
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool(WALK, false);
        }
    }

    private void refreshFireState()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool(FIRE, true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool(FIRE, false);
            
        }
    }

    private void reloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool(RELOAD, true);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            animator.SetBool(RELOAD, false);
        }
    }
}
