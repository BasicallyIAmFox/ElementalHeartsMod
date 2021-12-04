using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ElementalHeartsMod
{
    public class EHUIState : UIState
    {
        public static bool visible = false;

        public override void OnInitialize()
        {
            UIPanel parent = new UIPanel();
            parent.Height.Set(100f, 0f);
            parent.Width.Set(300, 0f);
            parent.Left.Set(Main.screenWidth - parent.Width.Pixels, 0f);
            parent.Top.Set(0f, 0f);
            parent.BackgroundColor = new Color(255, 255, 255, 255);

            base.Append(parent);
        }
    }
    public class EHOverlay : UserInterface
    {

    }

}