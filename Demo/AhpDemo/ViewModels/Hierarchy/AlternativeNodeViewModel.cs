using AhpDemo.Views;
using Mcdm;
using System.Windows;

namespace AhpDemo.ViewModels
{
    public class AlternativeNodeViewModel : HierarchyNodeViewModel
    {
        public Alternative Alternative { get; private set; }

        public AlternativeNodeViewModel(HierarchyViewModel hierarchy, Alternative alternative)
            : base(hierarchy)
        {
            Alternative = alternative;
            Name = alternative.Name;
        }

        public override string Name
        {
            get { return Alternative.Name; }
            set
            {
                Alternative.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        protected override UIElement CreateActionControl()
        {
            return new AlternativeView(this);
        }
    }
}
