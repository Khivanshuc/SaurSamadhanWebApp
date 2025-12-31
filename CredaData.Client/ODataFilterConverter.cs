using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CredaData.Client
{
    public static class ODataFilterConverter
    {
        public static string ConvertToODataFilter<T>(this Expression<Func<T, bool>> predicate)
        {
            return Visit(predicate.Body);
        }

        private static string Visit(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                    var andAlsoExpression = (BinaryExpression)expression;
                    return $"{Visit(andAlsoExpression.Left)} and {Visit(andAlsoExpression.Right)}";
                case ExpressionType.OrElse:
                    var orElseExpression = (BinaryExpression)expression;
                    return $"{Visit(orElseExpression.Left)} or {Visit(orElseExpression.Right)}";
                case ExpressionType.Equal:
                    var equalExpression = (BinaryExpression)expression;
                    return $"{Visit(equalExpression.Left)} eq {Visit(equalExpression.Right)}";
                case ExpressionType.NotEqual:
                    var notEqualExpression = (BinaryExpression)expression;
                    return $"{Visit(notEqualExpression.Left)} ne {Visit(notEqualExpression.Right)}";
                case ExpressionType.GreaterThan:
                    var greaterThanExpression = (BinaryExpression)expression;
                    return $"{Visit(greaterThanExpression.Left)} gt {Visit(greaterThanExpression.Right)}";
                case ExpressionType.GreaterThanOrEqual:
                    var greaterThanOrEqualExpression = (BinaryExpression)expression;
                    return $"{Visit(greaterThanOrEqualExpression.Left)} ge {Visit(greaterThanOrEqualExpression.Right)}";
                case ExpressionType.LessThan:
                    var lessThanExpression = (BinaryExpression)expression;
                    return $"{Visit(lessThanExpression.Left)} lt {Visit(lessThanExpression.Right)}";
                case ExpressionType.LessThanOrEqual:
                    var lessThanOrEqualExpression = (BinaryExpression)expression;
                    return $"{Visit(lessThanOrEqualExpression.Left)} le {Visit(lessThanOrEqualExpression.Right)}";
                case ExpressionType.Constant:
                    var constantExpression = (ConstantExpression)expression;
                    if (constantExpression.Value is string)
                    {
                        return $"'{constantExpression.Value}'";
                    }
                    if (constantExpression.Value is bool boolValueConst)
                    {
                        return boolValueConst ? "true" : "false";
                    }
                    return constantExpression.Value?.ToString() ?? string.Empty;
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;

                    if (memberExpression.Expression is ConstantExpression constantExpr)
                    {
                        // Extract the value of the field or property
                        var container = constantExpr.Value;
                        var member = memberExpression.Member;

                        if (member is FieldInfo field)
                        {
                            var value = field.GetValue(container);
                            if (value is string)
                            {
                                return $"'{value}'";
                            }
                            if (value is bool boolValueField)
                            {
                                return boolValueField ? "true" : "false";
                            }
                            return value?.ToString() ?? string.Empty;
                        }
                        if (member is PropertyInfo prop)
                        {
                            var value = prop.GetValue(container);
                            if (value is string)
                            {
                                return $"'{value}'";
                            }
                            if (value is bool boolValueProp)
                            {
                                return boolValueProp ? "true" : "false";
                            }
                            return value?.ToString() ?? string.Empty;
                        }
                    }

                    return memberExpression.Member.Name;
                case ExpressionType.Call: //TODO: Not working properly except string contains   
                    var methodCallExpression = (MethodCallExpression)expression;
                    if (methodCallExpression.Method.Name == "Contains")    //contains contains(CompanyName,'freds')
                    {
                        return $"contains({Visit(methodCallExpression.Object)},{Visit(methodCallExpression.Arguments[0])})";
                    }
                    return $"{methodCallExpression.Method.Name}({string.Join(", ", methodCallExpression.Arguments.Select(arg => Visit(arg)))})";
                case ExpressionType.And:
                    var andExpression = (BinaryExpression)expression;
                    return $"({Visit(andExpression.Left)} and {Visit(andExpression.Right)})";
                case ExpressionType.Or:
                    var orExpression = (BinaryExpression)expression;
                    return $"({Visit(orExpression.Left)} or {Visit(orExpression.Right)})";
                default:
                    throw new NotSupportedException("Expression type not supported: " + expression.NodeType);
            }
        }
    }
}
