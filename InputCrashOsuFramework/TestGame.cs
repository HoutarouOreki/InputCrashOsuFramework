using osu.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Testing;

namespace InputCrashOsuFramework
{
    internal class TestGame : Game
    {
        private Container<Drawable> content;

        protected override Container<Drawable> Content => content;

        protected override void LoadComplete()
        {
            var globalBinding = new GlobalActionContainer(this)
            {
                RelativeSizeAxes = Axes.Both,
                Child = content = new Container<Drawable> { RelativeSizeAxes = Axes.Both }
            };
            base.Content.Add(globalBinding);
            base.LoadComplete();
            Child = new TestBrowser("");
        }
    }
}
