﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace Mcdm.Ahp
{
    public class CriterionNode : Node
    {
        public CriterionNode()
            : this(null, 0M)
        { }

        public CriterionNode(string name)
            : this(name, 0M)
        { }

        public CriterionNode(string name, decimal localPriority)
            : base(name, localPriority)
        {
            _subcriterionNodes = new CriterionNodeCollection(ChildNodes);
            _alternativeNodes = new AlternativeNodeCollection(ChildNodes);
        }

        public Hierarchy Hierarchy
        {
            get
            {
                if (ParentNode == null)
                {
                    return null;
                }

                return (GoalNode != null) ? GoalNode.Hierarchy : ParentCriterionNode.Hierarchy;
            }
        }

        public GoalNode GoalNode
        {
            get { return ParentNode as GoalNode; }
            set
            {
                if (value == null && !(ParentNode is GoalNode))
                {
                    return;
                }

                ParentNode = value;
            }
        }

        public CriterionNode ParentCriterionNode
        {
            get { return ParentNode as CriterionNode; }
            set
            {
                if (value == null && !(ParentNode is CriterionNode))
                {
                    return;
                }

                ParentNode = value;
            }
        }

        private CriterionNodeCollection _subcriterionNodes;
        public CriterionNodeCollection SubcriterionNodes
        {
            get { return _subcriterionNodes; }
        }

        private AlternativeNodeCollection _alternativeNodes;
        public AlternativeNodeCollection AlternativeNodes
        {
            get { return _alternativeNodes; }
        }

        public CriterionNode AddSubcriterionNode(string name)
        {
            return AddSubcriterionNode(name, 0M);
        }

        public CriterionNode AddSubcriterionNode(string name, decimal weight)
        {
            var node = new CriterionNode(name, weight);
            AddSubcriterionNode(node);

            return node;
        }

        public void AddSubcriterionNode(CriterionNode node)
        {
            if (Hierarchy == null)
            {
                throw new InvalidOperationException("Can not add subcriterion node when Hierarchy is null.");
            }

            if (AlternativeNodes.Count > 0)
            {
                ClearChildNodes();
            }

            AddChildNode(node);
            node.RefreshAlternativeNodes();
        }

        public void RemoveSubcriterionNode(CriterionNode node)
        {
            RemoveChildNode(node);
        }

        public void RefreshAlternativeNodes()
        {
            if (SubcriterionNodes.Count == 0)
            {
                foreach (var alternative in Hierarchy.Alternatives)
                {
                    if (!AlternativeNodes.Contains(alternative))
                    {
                        AddChildNode(new AlternativeNode(alternative));
                    }
                }

                foreach (var alternativeNode in AlternativeNodes.ToArray())
                {
                    if (!Hierarchy.Alternatives.Contains(alternativeNode.Alternative))
                    {
                        RemoveChildNode(alternativeNode);
                    }
                }
            }
        }
    }
}
