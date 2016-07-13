
using ISAAC.Brain.Action;
using ISAAC.Brain.Memorizing;

namespace ISAAC.Brain
{
    class BrainController
    {
        public Memory Memory { get; set; }
        public ActionController ActionController { get; set; }

        public BrainController()
        {
            Memory = new Memory();
            ActionController = new ActionController();
        }
    }
}
