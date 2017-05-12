/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using GC.Definitions.GridTaxonomy;
using GC.World.Grids;

namespace GC.App.GridTaxonomy {

    public class Node {

        // If this is a leaf
        String ClassName;

        // If this is a tree
        Condition Condition;
        Node LeftBranch;
        Node RightBranch;

        public Node(String className) {
            if (className == null || className == "")
                throw new ArgumentException("Empty className");

            ClassName = className;
        }

        public Node(Condition condition, Node leftBranch, Node rightBranch) {
            if (condition == null)
                throw new ArgumentException("Null condition");
            if (leftBranch == null)
                throw new ArgumentException("Null leftBranch");
            if (rightBranch == null)
                throw new ArgumentException("Null rightBranch");

            Condition = condition;
            LeftBranch = leftBranch;
            RightBranch = rightBranch;
        }

        public Node(NodeDefinition definition) {
            if (!String.IsNullOrWhiteSpace(definition.ClassName)) {
                ClassName = definition.ClassName;
            }
            else {
                if (definition.Condition == null)
                    throw new ArgumentException("Null condition");
                if (definition.LeftBranch == null)
                    throw new ArgumentException("Null leftBranch");
                if (definition.RightBranch == null)
                    throw new ArgumentException("Null rightBranch");

                Condition = new Condition(definition.Condition);
                LeftBranch = new Node(definition.LeftBranch);
                RightBranch = new Node(definition.RightBranch);
            }
        }

        public NodeDefinition GetDefinition() {
            NodeDefinition result = new NodeDefinition();

            if (!String.IsNullOrWhiteSpace(ClassName)) {
                result.ClassName = ClassName;
            }
            else {
                result.Condition = Condition.GetDefinition();
                result.LeftBranch = LeftBranch.GetDefinition();
                result.RightBranch = RightBranch.GetDefinition();
            }

            return result;
        }

        public String ToString(String indent = "") {
            if (!String.IsNullOrWhiteSpace(ClassName)) {
                return indent + ClassName;
            }
            else {
                indent += "  ";
                return indent + Condition.ToString() + "\r\n"
                     + indent + LeftBranch.ToString(indent) + "\r\n"
                     + indent + RightBranch.ToString(indent);
            }
        }

        /// <summary>
        /// Navigates this branch given a grid and returns the resulting Class
        /// </summary>
        public String Classify(EnforcedGrid grid) {
            if (ClassName != null)
                return ClassName;

            if (Condition.Evaluate(grid))
                return LeftBranch.Classify(grid);
            else
                return RightBranch.Classify(grid);            
        }

    }

}
*/
