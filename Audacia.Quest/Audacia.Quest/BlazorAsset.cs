using Audacia.Quest.Core.Asset;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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
            Loaded = true;

            await Ref.MudChangeCssAsync("hide");
        }
    }
}
