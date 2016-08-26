using AhpDemo.Views;
using Mcdm.Ahp;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AhpDemo.ViewModels
{
    public class GoalNodeViewModel : HierarchyNodeViewModel
    {
        public GoalNode Goal { get; private set; }

        public GoalNodeViewModel(HierarchyViewModel hierarchy, GoalNode goal)
            : base(hierarchy)
        {
            Goal = goal;
        }

        public override string Name
        {
            get { return Goal.Name; }
            set
            {
                Goal.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public IEnumerable<CriterionNodeViewModel> GetAllCriterionNodes()
        {
            var result = new List<CriterionNodeViewModel>();
            GetAllChildrenRecursive(Children.Cast<CriterionNodeViewModel>(), result);

            return result;
        }

        private void GetAllChildrenRecursive(IEnumerable<CriterionNodeViewModel> nodes, List<CriterionNodeViewModel> result)
        {
            foreach (var node in nodes)
            {
                result.Add(node);
            }

            foreach (var node in nodes)
            {
                GetAllChildrenRecursive(node.Children.Cast<CriterionNodeViewModel>(), result);
            }
        }

        protected override UIElement CreateActionControl()
        {
            return new GoalView(this);
        }
    }
}
