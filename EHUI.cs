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
            UIPanel panel = new UIPanel();
            panel.Width.Set(300, 0);
            panel.Height.Set(100, 0);
            panel.HAlign = 0.5f;
            panel.VAlign = 0.5f;
            Append(panel);

            UIText text = new UIText("Hello world!");
            text.HAlign = 0.5f;
            text.VAlign = 0.5f;
            panel.Append(text);
        }
    }
}