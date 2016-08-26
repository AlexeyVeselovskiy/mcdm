using AhpDemo.Views;
using Mcdm.Ahp;
using System.Windows;

namespace AhpDemo.ViewModels
{
    public class CriterionNodeViewModel : HierarchyNodeViewModel
    {
        public CriterionNode Criterion { get; private set; }

        public CriterionNodeViewModel(HierarchyViewModel hierarchy, CriterionNode criterion)
            : base(hierarchy)
        {
            Criterion = criterion;
            Name = criterion.Name;
        }

        public override string Name
        {
            get { return Criterion.Name; }
            set
            {
                Criterion.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public decimal LocalPriority
        {
            get { return Criterion.LocalPriority; }
            set
            {
                Criterion.LocalPriority = value;
                OnPropertyChanged(() => LocalPriority);
                OnPropertyChanged(() => GlobalPriority);
            }
        }

        public decimal GlobalPriority
        {
            get { return Criterion.GlobalPriority; }
        }

        protected override UIElement CreateActionControl()
        {
            return new CriterionView(this);
        }
    }
}
