using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;

    [SerializeField]ShopTooltip tooltip;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
    public void Open(Item item)
    {
        tooltip.Open(item);
    }
    public void Open(HaveWeapon Weapon) 
    {
        tooltip.Open(Weapon);
    }
    public void Close()
    { 
        tooltip.Close();
    }

}
