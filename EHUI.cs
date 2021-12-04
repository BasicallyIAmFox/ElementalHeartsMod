using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ElementalHeartsMod
{
    public class EHUIState : UIState
    {
        public override void OnInitialize()
        {
            UIPanel panel = new UIPanel(); // 2
            panel.Width.Set(300, 0); // 3
            panel.Height.Set(300, 0); // 3

            Append(panel); // 4
        }

    }
}