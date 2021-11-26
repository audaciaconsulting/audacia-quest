using Audacia.Quest.Core.Renderer;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Numerics;

namespace Audacia.Quest
{
    public class BlazorAsset
    {
        public Guid Id { get; set; }
        public ElementReference Ref { get; set; }
        public IRenderer Renderer { get; set; }

        public async void ContentLoaded()
        {
            var bounds = await Ref.MudGetBoundingClientRectAsync();
            Renderer.Width = bounds.Width;
            Renderer.Height = bounds.Height;
            Renderer.Origin = Vector2.Zero;

            await Ref.MudChangeCssAsync("hide");
        }
    }
}
