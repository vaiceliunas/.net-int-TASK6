using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Common
{
    public class ExpressionNodeHelpers
    {
        public static ConstantExpression GetConstExpression(BinaryExpression node)
        {
            if (node.Left.NodeType == ExpressionType.Constant)
            {
                return (ConstantExpression)node.Left;
            }
            if (node.Right.NodeType == ExpressionType.Constant)
            {
                return (ConstantExpression)node.Right;
            }

            return null;
        }

        public static ParameterExpression GetParamExpression(BinaryExpression node)
        {
            if (node.Left.NodeType == ExpressionType.Parameter)
            {
                return (ParameterExpression)node.Left;
            }
            if (node.Right.NodeType == ExpressionType.Parameter)
            {
                return (ParameterExpression)node.Right;
            }

            return null;
        }
    }
}
