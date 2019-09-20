using osu.Framework.Testing;

namespace InputCrashOsuFramework.Visual
{
    public class ATestScene : TestScene
    {
        public ATestScene()
        {
            Child = new Controller
            {
                RelativeSizeAxes = osu.Framework.Graphics.Axes.Both
            };

            AddSliderStep<int>("slider step", 0, 10, 5, value => { });
        }
    }
}
