using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ElementalHeartsMod
{
    public class EHUIState : UIState
    {
        public override void OnInitialize()
        {
        }
        public void CreateText(string text, Color color)
        {
            UIText EHText = new UIText(text);
            EHText.HAlign = .83f;
            EHText.VAlign = .02f;
            EHText.TextColor = color;
            Append(EHText);
        }
    }
}