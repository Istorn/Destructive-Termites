using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class Booster
{
    public enum Model {
        [Description("IRON DENTURE")]
        IronDenture = 1,
       /* [Description("MUSHROOM")]
        Mushroom = 2,
        [Description("GIANT TERMITE")]
        GiantTermite = 3,*/
        [Description("GAS EQUIPMENT")]
        GasEquipment = 2,
        [Description("MAGIC SHIELD")]
        MagicShield = 3,
        [Description("QUEEN TERMITE")]
        QueenTermite = 4
    } ;

    protected Model model;

    private Colony owner = null;

    protected float timeDuration = 0;
    
    protected List<GenericObject.Model> extraEatableMaterials = null; 

    public Booster()
    {
        extraEatableMaterials = new List<GenericObject.Model>();
    }

    public void setOwner(Colony owner)
    {
        this.owner = owner;
    }

    public Model getModel()
    {
        return model;
    }

    public List<GenericObject.Model> getExtraEatableMaterials()
    {
        return extraEatableMaterials;
    }

    public static Booster initFromModel(Model model)
    {
        Booster booster = null;
        switch (model)
        {
            case Model.IronDenture:
                booster = new IronDenture();
                break;
            /*case Model.Mushroom:
                booster = new Mushroom();
                break;*/
            case Model.GasEquipment:
                booster = new GasEquipment();
                break;
            case Model.MagicShield:
                booster = new MagicShield();
                break;
            case Model.QueenTermite:
                booster = new QueenTermite();
                break;
        }
        return booster;
    }
}
