using osu.Framework.Graphics;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using System.Collections.Generic;
using System.Linq;

namespace InputCrashOsuFramework
{
    public class GlobalActionContainer : KeyBindingContainer<GlobalAction>, IHandleGlobalKeyboardInput
    {
        private readonly Drawable handler;

        public GlobalActionContainer(Drawable game) : base(SimultaneousBindingMode.Unique, KeyCombinationMatchingMode.Modifiers)
        {
            if (game is IKeyBindingHandler<GlobalAction>)
                handler = game;
        }

        public override IEnumerable<KeyBinding> DefaultKeyBindings => GlobalKeyBindings.Concat(InGameKeyBindings);

        public IEnumerable<KeyBinding> GlobalKeyBindings => new[]
        {
            new KeyBinding(InputKey.Escape, GlobalAction.Back),
            new KeyBinding(InputKey.FirstMouseButton, GlobalAction.Back),

            new KeyBinding(InputKey.Space, GlobalAction.Select),
            new KeyBinding(InputKey.Enter, GlobalAction.Select),
        };

        public IEnumerable<KeyBinding> InGameKeyBindings => new[]
        {
            new KeyBinding(InputKey.Up, GlobalAction.Up),
            new KeyBinding(InputKey.Left, GlobalAction.Left),
            new KeyBinding(InputKey.Right, GlobalAction.Right),
            new KeyBinding(InputKey.Down, GlobalAction.Down),

            new KeyBinding(InputKey.A, GlobalAction.ShootLeft),
            new KeyBinding(InputKey.S, GlobalAction.ShootRight)
        };

        protected override IEnumerable<Drawable> KeyBindingInputQueue =>
            handler == null ? base.KeyBindingInputQueue : base.KeyBindingInputQueue.Prepend(handler);
    }

    public enum GlobalAction
    {
        Select,
        Back,

        Up,
        Left,
        Right,
        Down,

        ShootLeft,
        ShootRight
    }
}
