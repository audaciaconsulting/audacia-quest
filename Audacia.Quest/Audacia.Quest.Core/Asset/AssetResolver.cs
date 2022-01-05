namespace Audacia.Quest.Core.Asset
{
    public class AssetResolver
    {
        private static Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

        public static Sprite AddSprite(string imageSource)
        {
            var sprite = new Sprite(imageSource);
            _sprites.Add(imageSource, sprite);

            return sprite;
        }

        public static Sprite GetSprite(string imageSource)
        {
            if (!_sprites.ContainsKey(imageSource))
            {
                return null;
            }

            return _sprites[imageSource];
        }

        public static List<Sprite> GetAll()
        {
            return _sprites.Values.ToList();
        }

        public static void Clear()
        {
            _sprites.Clear();
        }
    }
}
