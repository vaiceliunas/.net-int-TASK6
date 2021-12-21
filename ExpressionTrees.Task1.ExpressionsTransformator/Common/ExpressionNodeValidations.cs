using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace ExpressionTrees.Task1.ExpressionsTransformer.Common
{
    public class ExpressionNodeValidations
    {
        public static bool IsInt(Expression o)
        {
            return o.Type == typeof(int);
        }

        public static bool Is1(int i)
        {
            return i == 1;
        }

        public static bool IsNull(Expression o)
        {
            return o == null;
        }

        public static bool ValidForIncDec(ConstantExpression constant, ParameterExpression param)
        {
            return (!ExpressionNodeValidations.IsNull(param) &&
                    !ExpressionNodeValidations.IsNull(constant) &&
                    ExpressionNodeValidations.IsInt(constant) &&
                    ExpressionNodeValidations.Is1((int) constant.Value));
        }
    }
}
