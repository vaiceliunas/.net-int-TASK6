using System;
using System.Linq.Expressions;
using ExpressionTrees.Task1.ExpressionsTransformer.Common;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    public class IncDecExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                {
                    var constant = ExpressionNodeHelpers.GetConstExpression(node);
                    var param = ExpressionNodeHelpers.GetParamExpression(node);
                    if (ExpressionNodeValidations.ValidForIncDec(constant, param))
                        return Expression.Increment(param);
                    break;
                }

                case ExpressionType.Subtract:
                {
                    var constant = ExpressionNodeHelpers.GetConstExpression(node);
                    var param = ExpressionNodeHelpers.GetParamExpression(node);
                    if (ExpressionNodeValidations.ValidForIncDec(constant, param))
                        return Expression.Decrement(param);
                    break;
                }
            }

            return base.VisitBinary(node);
        }
    }
}
