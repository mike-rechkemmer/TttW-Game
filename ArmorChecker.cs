using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.vMelee;
using UnityEngine.UI;

public class ArmorChecker : MonoBehaviour
{
    public GameObject Hair;
    public GameObject FlatHair;
    public GameObject SpikedHair;

    public GameObject MaskObj;
    public GameObject ChestObj;
    public GameObject LegObj;

    public GameObject currentChestObj;
    public GameObject currentLegObj;

    public GameObject HelmLeather; //Mask Accessory

    public GameObject NudeChest; //0
    public GameObject NudeLeg; //1
    public GameObject ShirtChest; //2
    public GameObject ShortsLeg; //3
    public GameObject BanditChest; //4
    public GameObject BanditLeg; //5
    public GameObject SoldierChest; //4
    public GameObject SoldierShoulder; //4 - Accessory
    public GameObject SoldierLeg; //5
    public GameObject SoldierLeftLeg; //5 - Accessory
    public GameObject SoldierRightLeg; //5 - Accessory
    public GameObject WornShirtChest; //8
    public GameObject WornPants; //9
    public GameObject StylishShirtChest; //10
    public GameObject StylishPants; //11
    public GameObject WoodChest; //12
    public GameObject WoodShoulder; //12 - Accessory
    public GameObject BushShoulder; //12 - Accessory
    public GameObject WoodLeftHand; //12 - Accessory
    public GameObject WoodRightHand; //12 - Accessory
    public GameObject WoodLeftArm; //12 - Accessory
    public GameObject WoodRightArm; //12 - Accessory
    public GameObject WoodPants; //13
    public GameObject WoodHips; //13 - Accessory
    public GameObject WoodLeftUpperLeg; //13 - Accessory
    public GameObject WoodLeftLowerLeg; //13 - Accessory
    public GameObject WoodLeftFoot; //13 - Accessory
    public GameObject WoodRightUpperLeg; //13 - Accessory
    public GameObject WoodRightLowerLeg; //13 - Accessory
    public GameObject WoodRightFoot; //13 - Accessory

    //DEFENSE ARMOR
    public int ChestDef;
    public int LegDef;
    public int TotalDef;
    public int TotalStr;

    //ARMOR UI
    public Text DamageText;
    public Text ArmorText;

    //DAMAGE OVER TIME//
    public bool Poisoned;

    public bool OnFire;

    public int PoisonReduction; //Reduces poison damage -- 3 = 3 Hp -- 4 = 2 Hp -- 5 = 1 Hp
    public int PoisonResistance; //Reduces time poisoned -- 8 = 4 sec -- 6 = 6 sec -- 10 = 2 sec
    public float PoisonTimeLeft = 12f; // Poison Life Time
    float PoisonTime = 0f; //Damage every 3 sec

    public int ChestPoisonReduction;
    public int ChestPoisonResistance;
    public int LegPoisonReduction;
    public int LegPoisonResistance;

    public int FireReduction; //Reduces fire damage
    public int FireResistance; //Reduces time on fire
    public float FireTimeLeft = 3f; // Fire Life Time
    float FireTime = 0f; //Damage every 1 sec

    public int ChestFireReduction;
    public int ChestFireResistance;
    public int LegFireReduction;
    public int LegFireResistance;

    public GameObject PoisonFXChest;
    public GameObject PoisonFXHips;

    public GameObject FireFXChest;
    public GameObject FireFXHips;
    public GameObject FireFXLeftLeg;
    public GameObject FireFXRightLeg;
    public GameObject FireFXLeftFoot;
    public GameObject FireFXRightFoot;

    //UI Stat Icons
    public GameObject FireResistIcon;
    public GameObject FireProtectIcon;
    public GameObject PoisonResistIcon;
    public GameObject PoisonProtectIcon;
    public GameObject FlammableIcon;

    public Image FireResistEnergy;
    public Image FireProtectEnergy;
    public Image PoisonResistEnergy;
    public Image PoisonProtectEnergy;
    public Image FlammableEnergy;

    public void Start()
    {
        if (currentChestObj == null) {
            currentChestObj = NudeChest;
        }
        if (currentLegObj == null)
        {
            currentChestObj = NudeLeg;
        }
    }

    public void RemoveHair()
    {
        Hair.gameObject.SetActive(false);
        if (MaskObj.transform.childCount > 0 && MaskObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 1)
        {
            SpikedHair.gameObject.SetActive(true);
        }
        if (MaskObj.transform.childCount > 0 && MaskObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 8)
        {
            FlatHair.gameObject.SetActive(true);
            HelmLeather.SetActive(true);
        }
    }

    public void ApplyHair()
    {
        Hair.gameObject.SetActive(true);
        FlatHair.gameObject.SetActive(false);
        SpikedHair.gameObject.SetActive(false);
        HelmLeather.SetActive(false);
    }

    // Update is called once per frame
    public void ArmorCheck()
    {
        if (MaskObj.transform.childCount == 0) { 
                ApplyHair();
        }

        if (currentChestObj == null)
        {
            currentChestObj = NudeChest;
        }
        if (currentLegObj == null)
        {
            currentChestObj = NudeLeg;
        }

        if (ChestObj.transform.childCount < 1) { currentChestObj.SetActive(false); NudeChest.SetActive(true); currentChestObj = NudeChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 2) { currentChestObj.SetActive(false); ShirtChest.SetActive(true); currentChestObj = ShirtChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 4) { currentChestObj.SetActive(false); BanditChest.SetActive(true); currentChestObj = BanditChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 6) { currentChestObj.SetActive(false); SoldierChest.SetActive(true); SoldierShoulder.SetActive(true); SoldierLeftLeg.SetActive(true); SoldierRightLeg.SetActive(true); currentChestObj = SoldierChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 8) { currentChestObj.SetActive(false); WornShirtChest.SetActive(true); currentChestObj = WornShirtChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 10) { currentChestObj.SetActive(false); StylishShirtChest.SetActive(true); currentChestObj = StylishShirtChest; }
        else if (ChestObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 12) { currentChestObj.SetActive(false); WoodChest.SetActive(true); WoodShoulder.SetActive(true); BushShoulder.SetActive(true); WoodLeftArm.SetActive(true); WoodRightArm.SetActive(true); WoodRightHand.SetActive(true); WoodLeftHand.SetActive(true); WoodHips.SetActive(true); currentChestObj = WoodChest; }

        //Chest Accessory Disables
        if (currentChestObj != SoldierChest) { SoldierShoulder.SetActive(false); SoldierLeftLeg.SetActive(false); SoldierRightLeg.SetActive(false); }
        if (currentChestObj != WoodChest) { WoodShoulder.SetActive(false); BushShoulder.SetActive(false); WoodLeftArm.SetActive(false); WoodRightArm.SetActive(false); WoodRightHand.SetActive(false); WoodLeftHand.SetActive(false); WoodHips.SetActive(false); }

        if (LegObj.transform.childCount < 1) { currentLegObj.SetActive(false); NudeLeg.SetActive(true); currentLegObj = NudeLeg; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 3) { currentLegObj.SetActive(false); ShortsLeg.SetActive(true); currentLegObj = ShortsLeg; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 5) { currentLegObj.SetActive(false); BanditLeg.SetActive(true); currentLegObj = BanditLeg; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 7) { currentLegObj.SetActive(false); SoldierLeg.SetActive(true); currentLegObj = SoldierLeg; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 9) { currentLegObj.SetActive(false); WornPants.SetActive(true); currentLegObj = WornPants; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 11) { currentLegObj.SetActive(false); StylishPants.SetActive(true); currentLegObj = StylishPants; }
        else if (LegObj.transform.GetChild(0).GetComponent<ArmorID>().ID == 13) { currentLegObj.SetActive(false); WoodPants.SetActive(true); WoodLeftUpperLeg.SetActive(true); WoodLeftLowerLeg.SetActive(true); WoodLeftFoot.SetActive(true); WoodRightUpperLeg.SetActive(true); WoodRightLowerLeg.SetActive(true); WoodRightFoot.SetActive(true); currentLegObj = WoodPants; }

        //Leg Accessory Disables
        if (currentLegObj != WoodPants) { WoodLeftUpperLeg.SetActive(false); WoodLeftLowerLeg.SetActive(false); WoodLeftFoot.SetActive(false); WoodRightUpperLeg.SetActive(false); WoodRightLowerLeg.SetActive(false); WoodRightFoot.SetActive(false); }

        //Stats
        if (currentChestObj == NudeChest) { ChestDef = 0; ChestPoisonResistance = 0; ChestPoisonReduction = 0; ChestFireResistance = 0; ChestFireReduction = 0; }
        else if (currentChestObj == WoodChest) { ChestDef = 12; ChestPoisonResistance = 4; ChestFireResistance = -2; ChestFireReduction = -5; }
        else if (currentChestObj == WornShirtChest) { ChestDef = 1; }
        else if (currentChestObj == ShirtChest) { ChestDef = 2; }
        else if (currentChestObj == BanditChest) { ChestDef = 8; }
        else if (currentChestObj == SoldierChest) { ChestDef = 25; }

        if (currentLegObj == NudeLeg) { LegDef = 0; LegPoisonResistance = 0; LegPoisonReduction = 0; LegFireResistance = 0; LegFireReduction = 0; }
        else if (currentLegObj == WoodPants) { LegDef = 8; LegPoisonResistance = 2; LegFireResistance = -1; LegFireReduction = -2; }
        else if (currentLegObj == ShortsLeg) { LegDef = 1; }
        else if (currentLegObj == StylishPants) { LegDef = 1; }
        else if (currentLegObj == BanditLeg) { LegDef = 5; }
        else if (currentLegObj == SoldierLeg) { LegDef = 12; }

        TotalDef = ChestDef + LegDef;
        
        PoisonResistance = ChestPoisonResistance + LegPoisonResistance;
        PoisonReduction = ChestPoisonReduction + LegPoisonReduction;
        FireResistance = ChestFireResistance + LegFireResistance;
        FireReduction = ChestFireReduction + LegFireReduction;

        if (GetComponent<vMeleeManager>().rightWeapon != null)
        {
            TotalStr = GetComponent<vMeleeManager>().rightWeapon.damage.damageValue;
        }
        else { TotalStr = 0; }

        //UI Armor Stats
        ArmorText.text = TotalDef.ToString();
        DamageText.text = TotalStr.ToString();

        //UI Buff Stats
        if (PoisonResistance > 0) { PoisonResistIcon.SetActive(true); } else if (PoisonResistance <= 0) { PoisonResistIcon.SetActive(false); }
        if (PoisonReduction > 0) { PoisonProtectIcon.SetActive(true); } else if (PoisonReduction <= 0) { PoisonProtectIcon.SetActive(false); }
        if (FireResistance > 0) { FireResistIcon.SetActive(true); } else if (FireResistance <= 0) { FireResistIcon.SetActive(false); }
        if (FireReduction > 0) { FireProtectIcon.SetActive(true); FlammableIcon.SetActive(false); } else if (FireReduction <= 0) { FireProtectIcon.SetActive(false); }

        //Negative Buffs
        if (FireReduction < 0) { FlammableIcon.SetActive(true); } else if (FireReduction >= 0) { FlammableIcon.SetActive(false); }

        //UI Energy Bars
        PoisonResistEnergy.fillAmount = PoisonResistance / 12f;
        PoisonProtectEnergy.fillAmount = PoisonReduction / 12f;
        FireResistEnergy.fillAmount = FireResistance / 12f;
        FireProtectEnergy.fillAmount = FireReduction / 12f;

        //Negative Buffs
        FlammableEnergy.fillAmount = ((FireReduction + FireResistance) * -1f) / 12f;
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Poison")
        {
            Poisoned = true;
        }

        if (other.tag == "CampFire")
        {
            OnFire = true;
        }

        if(other.tag == "Water")
        {
            TurnOffFire();
            TurnOffPoison();
        }
    }

    public void FixedUpdate()
    {
        if (Poisoned)
        {
            TurnOnPoison();

            //Poison Time
            PoisonTimeLeft -= Time.deltaTime;
            if (PoisonTimeLeft < PoisonResistance)
             {
                TurnOffPoison();
            }

            //Poison Damage Repeater
            int PoisonDamage = 6 - PoisonReduction;
            PoisonTime += Time.deltaTime;
            if (PoisonTime > 3f)
            {
                gameObject.GetComponent<vHealthController>().TakeDamage(new vDamage(PoisonDamage));
                PoisonTime = 0f;
            }
        }

        if (OnFire)
        {
            TurnOnFire();

            //Fire Time
            FireTimeLeft -= Time.deltaTime;
            if (FireTimeLeft < FireResistance)
            {
                TurnOffFire();
            }

            //Fire Damage Repeater
            int FireDamage = 3 - FireReduction;
            FireTime += Time.deltaTime;
            if (FireTime > 1f)
            {
                gameObject.GetComponent<vHealthController>().TakeDamage(new vDamage(FireDamage));
                FireTime = 0f;
            }
        }
    }

    void TurnOnPoison()
    {
        PoisonFXChest.SetActive(true);
        PoisonFXHips.SetActive(true);
    }

    void TurnOnFire()
    {
        FireFXChest.SetActive(true);
        FireFXHips.SetActive(true);
        FireFXLeftLeg.SetActive(true);
        FireFXRightLeg.SetActive(true);
        FireFXLeftFoot.SetActive(true);
        FireFXRightFoot.SetActive(true);
    }

    void TurnOffPoison()
    {
        PoisonTime = 0f;
        PoisonTimeLeft = 12f;
        PoisonFXChest.SetActive(false);
        PoisonFXHips.SetActive(false);
        Poisoned = false;
    }

    void TurnOffFire()
    {
        FireTime = 0f;
        FireTimeLeft = 3f;
        FireFXChest.SetActive(false);
        FireFXHips.SetActive(false);
        FireFXLeftLeg.SetActive(false);
        FireFXRightLeg.SetActive(false);
        FireFXLeftFoot.SetActive(false);
        FireFXRightFoot.SetActive(false);
        OnFire = false;
    }
}
