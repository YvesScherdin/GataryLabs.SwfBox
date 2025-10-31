using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GataryLabs.Mvvm.Views.InternalBehaviors
{
    public class ControlBehaviorManager : IDisposable
    {
        private Control control;

        private ISet<IControlBehavior> behaviors;

        public ControlBehaviorManager(Control control)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
            behaviors = new HashSet<IControlBehavior>();
        }

        public void Dispose()
        {
            foreach (IControlBehavior behavior in behaviors)
            {
                behavior.Deinitialize();
            }
        }

        public ControlBehaviorManager Add(IControlBehavior behaviorToAdd)
        {
            ArgumentNullException.ThrowIfNull(behaviorToAdd);
            behaviors.Add(behaviorToAdd);
            behaviorToAdd.Initialize(control);
            return this;
        }
    }
}
