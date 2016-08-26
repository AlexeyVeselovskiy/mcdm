using System.Windows;
using System.Windows.Controls;

namespace AhpDemo.ViewModels
{
    public class AlternativesNodeViewModel : HierarchyNodeViewModel
    {
        public AlternativesNodeViewModel(HierarchyViewModel hierarchy)
            : base(hierarchy)
        {
            Name = "Alternatives";
        }

        protected override UIElement CreateActionControl()
        {
            return new TextBlock() { Text = Name };
        }
    }
}
