using AhpDemo.Models;
using Mcdm.Ahp;

namespace AhpDemo.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Tree = new HierarchyViewModel(new HierarchyManager(new Hierarchy()));
        }

        public HierarchyViewModel Tree { get; private set; }
    }
}
