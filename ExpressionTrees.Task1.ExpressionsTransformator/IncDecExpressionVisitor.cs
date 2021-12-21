using System;
using System.Linq.Expressions;
using ExpressionTrees.Task1.ExpressionsTransformer.Common;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    public class IncDecExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                var constant = ExpressionNodeHelpers.GetConstExpression(node);
                var param = ExpressionNodeHelpers.GetParamExpression(node);
                if (!ExpressionNodeValidations.IsNull(param) && 
                    !ExpressionNodeValidations.IsNull(constant) && 
                    ExpressionNodeValidations.IsInt(constant) && 
                    ExpressionNodeValidations.Is1((int)constant.Value))
                    return Expression.Increment(param);
            }

            if (node.NodeType == ExpressionType.Subtract)
            {
                var constant = ExpressionNodeHelpers.GetConstExpression(node);
                var param = ExpressionNodeHelpers.GetParamExpression(node);
                if (!ExpressionNodeValidations.IsNull(param) &&
                    !ExpressionNodeValidations.IsNull(constant) &&
                    ExpressionNodeValidations.IsInt(constant) &&
                    ExpressionNodeValidations.Is1((int)constant.Value))
                    return Expression.Decrement(param);
            }

            return base.VisitBinary(node);
        }
    }
}
