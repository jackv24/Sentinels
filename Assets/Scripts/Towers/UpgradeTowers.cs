using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeTowers : MonoBehaviour
{
    public Text nameText;

    public Image towerImage;
    private Sprite towerSprite;

    public Slider healthSlider;
    public Slider xpSlider;
    public Slider levelSlider;

    public Text nextLevelText;

    void Start()
    {
        towerSprite = Resources.Load<Sprite>("Sprites/Turret");

        towerImage.sprite = towerSprite;
    }
}
