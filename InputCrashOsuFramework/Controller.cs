using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osuTK;

namespace InputCrashOsuFramework
{
    public class Controller : Container, IKeyBindingHandler<GlobalAction>
    {
        private Vector2 controlVector;

        private bool upPressed;
        private bool downPressed;
        private bool leftPressed;
        private bool rightPressed;
        private readonly Circle controlVectorCircle;
        private readonly SpriteText inputInfo;
        public const bool DEBUG = true;

        public Controller()
        {
            Children = new Drawable[]
            {
                controlVectorCircle = new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    RelativePositionAxes = Axes.Both,
                    Size = new Vector2(0.25f),
                    Colour = FrameworkColour.Blue
                },
                new FillFlowContainer<SpriteText>
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Children = new SpriteText[]
                    {
                        inputInfo = new SpriteText()
                    }
                }
            };
        }

        protected override void Update()
        {
            controlVector = Vector2.Zero;
            if (upPressed)
                controlVector += new Vector2(0, 1);
            if (downPressed)
                controlVector += new Vector2(0, -1);
            if (leftPressed)
                controlVector += new Vector2(-1, 0);
            if (rightPressed)
                controlVector += new Vector2(1, 0);

            controlVectorCircle.Position = controlVector / 2;

            if (DEBUG)
                UpdateDebugInfo();

            base.Update();
        }

        private void UpdateDebugInfo()
        {
            var direction = "";
            if (upPressed) direction += "U";
            if (downPressed) direction += "D";
            if (leftPressed) direction += "L";
            if (rightPressed) direction += "R";
            inputInfo.Text = $"input: {direction}";
        }

        //protected override bool OnKeyDown(KeyDownEvent e)
        //{
        //    switch (e.Key)
        //    {
        //        case osuTK.Input.Key.Up:
        //            upPressed = true;
        //            break;
        //        case osuTK.Input.Key.Down:
        //            downPressed = true;
        //            break;
        //        case osuTK.Input.Key.Left:
        //            leftPressed = true;
        //            break;
        //        case osuTK.Input.Key.Right:
        //            rightPressed = true;
        //            break;
        //    }
        //    return true;
        //}

        //protected override bool OnKeyUp(KeyUpEvent e)
        //{
        //    switch (e.Key)
        //    {
        //        case osuTK.Input.Key.Up:
        //            upPressed = false;
        //            break;
        //        case osuTK.Input.Key.Down:
        //            downPressed = false;
        //            break;
        //        case osuTK.Input.Key.Left:
        //            leftPressed = false;
        //            break;
        //        case osuTK.Input.Key.Right:
        //            rightPressed = false;
        //            break;
        //    }
        //    return true;
        //}

        public bool OnPressed(GlobalAction action)
        {
            switch (action)
            {
                case GlobalAction.Up:
                    upPressed = true;
                    break;
                case GlobalAction.Down:
                    downPressed = true;
                    break;
                case GlobalAction.Left:
                    leftPressed = true;
                    break;
                case GlobalAction.Right:
                    rightPressed = true;
                    break;
            }
            return true;
        }

        public bool OnReleased(GlobalAction action)
        {
            switch (action)
            {
                case GlobalAction.Up:
                    upPressed = false;
                    break;
                case GlobalAction.Down:
                    downPressed = false;
                    break;
                case GlobalAction.Left:
                    leftPressed = false;
                    break;
                case GlobalAction.Right:
                    rightPressed = false;
                    break;
            }
            return true;
        }
    }
}
