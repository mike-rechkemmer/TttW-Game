using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRandomizer : MonoBehaviour
{
    public Renderer BodyRend;
    
    //Color changers
    public int HairSlot;
    public Material[] RandomHairColor = new Material[1];

    public int SkinSlot;
    public Material[] RandomSkinColor = new Material[1];

    //Changes hair mesh
    public GameObject HairObj;
    public GameObject[] RandomHairType = new GameObject[1];

    //Changes eye color
    public GameObject EyeObj;
    public Material[] RandomEyeColor = new Material[1];

    //Change Head Skin color and Eyebrow color
    public Renderer HeadRend;

    //Accessories
    public GameObject AccessoryObj;
    public GameObject[] RandomAccessory = new GameObject[1];

    //Output Generated Numbers
    public int HairTypeNumGenerated;
    public int HairNumGenerated;
    public int SkinNumGenerated;
    public int EyeNumGenerated;
    public int AccessoryNumGenerated;
    // Start is called before the first frame update
    void Awake()
    {

        HairTypeNumGenerated = Random.Range(0, RandomHairType.Length);
        HairObj = RandomHairType[HairTypeNumGenerated];
        HairObj.SetActive(true);

        Material[] materials = BodyRend.materials; //Open the mats
        HairNumGenerated = Random.Range(0, RandomHairColor.Length);
        SkinNumGenerated = Random.Range(0, RandomSkinColor.Length);

        materials[SkinSlot] = RandomSkinColor[SkinNumGenerated];
        BodyRend.materials = materials; //Close the mats

        Material[] Headmaterials = HeadRend.materials; //Open the mats
        Headmaterials[0] = RandomSkinColor[SkinNumGenerated]; //Skin Color for face
        Headmaterials[2] = RandomHairColor[HairNumGenerated]; //Eyebrows
        HeadRend.materials = Headmaterials; //Close the mats

        HairObj.GetComponent<SkinnedMeshRenderer>().material = RandomHairColor[HairNumGenerated];

        EyeNumGenerated = Random.Range(0, RandomEyeColor.Length);
        EyeObj.GetComponent<SkinnedMeshRenderer>().material = RandomEyeColor[EyeNumGenerated];


        AccessoryNumGenerated = Random.Range(0, RandomAccessory.Length);
        AccessoryObj = RandomAccessory[AccessoryNumGenerated];
        AccessoryObj.SetActive(true);
    }
}
