/*
using System;

using VRage;
using VRage.Library.Collections;

using SEPC.Extensions;

using GC.World.Grids;


namespace GC.App.GridTaxonomy {

    public class Node {

		enum NodeType { Unknown, Leaf, Tree }

		NodeType NType;

        // If this is a leaf
        String GridClassName;

        // If this is a tree
        Condition Condition;
        Node Left;
        Node Right;

		public Node() { }

		public Node(String gridClassName) {
			Exceptions.ThrowIf<ArgumentException>(String.IsNullOrEmpty(gridClassName), "Empty gridClassName");

			NType = NodeType.Leaf;
			GridClassName = gridClassName;
        }

        public Node(Condition condition, Node leftBranch, Node rightBranch) {
			Exceptions.ThrowIf<ArgumentException>(condition == null, "Null condition");
			Exceptions.ThrowIf<ArgumentException>(leftBranch == null, "Null leftBranch");
			Exceptions.ThrowIf<ArgumentException>(rightBranch == null, "Null rightBranch");

			NType = NodeType.Tree;
			Condition = condition;
            Left = leftBranch;
            Right = rightBranch;
        }

		public void Serialize(BitStream stream)
		{
			if (stream.Reading)
				stream.WriteByte((byte)NType);
			else
				NType = (NodeType)stream.ReadByte();

			// Only serializes the values matching its type
			switch (NType)
			{
				case NodeType.Leaf:
					stream.Serialize(ref GridClassName);
					break;
				case NodeType.Tree:
					if (stream.Reading)
					{
						Condition = new Condition();
						Left = new Node();
						Right = new Node();
					}
					Condition.Serialize(stream);
					Left.Serialize(stream);
					Right.Serialize(stream);
					break;
				default:
					throw new InvalidOperationException("Unexpected stored type");
			}
		}


		public String ToString(String indent = "") {
            if (!String.IsNullOrWhiteSpace(GridClassName)) {
                return indent + GridClassName;
            }
            else {
                indent += "  ";
                return indent + Condition.ToString() + "\r\n"
                     + indent + Left.ToString(indent) + "\r\n"
                     + indent + Right.ToString(indent);
            }
        }

        /// <summary>
        /// Navigates this branch given a grid and returns the resulting Class
        /// </summary>
//        public String Classify(EnforcedGrid grid) {
//            if (GridClassName != null)
//                return GridClassName;
//
//            if (Condition.Evaluate(grid))
//                return LeftBranch.Classify(grid);
//            else
//                return RightBranch.Classify(grid);            
//        }
//    }

}
*/