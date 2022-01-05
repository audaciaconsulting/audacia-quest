using Audacia.Quest.Core.Asset;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Numerics;

namespace Audacia.Quest
{
    public class BlazorAsset
    {
        public string Source { get; set; }
        public ElementReference Ref { get; set; }
        public Sprite Sprite { get; set; }
        public bool Loaded { get; set; } = false;

        public async void ContentLoaded()
        {
            var bounds = await Ref.MudGetBoundingClientRectAsync();
            Sprite.Width = bounds.Width;
            Sprite.Height = bounds.Height;
            Sprite.Origin = new Vector2(-(float)bounds.Width / 2, -(float)bounds.Height / 2);
            Loaded = true;

            await Ref.MudChangeCssAsync("hide");
        }
    }
}
