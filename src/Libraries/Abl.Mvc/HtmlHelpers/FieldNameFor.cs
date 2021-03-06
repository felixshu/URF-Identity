﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace Abl.Mvc.HtmlHelpers
{
    /// <summary>
    /// Useful helper for determining the an MVC bound data control id
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// <label for="<%= Html.FieldIdFor(m => m.EmailAddress) %>">E-mail address:</label> 
    /// <%= Html.TextBoxFor(m => m.EmailAddress) %>
    /// ]]>
    /// </example>
    public static partial class HtmlHelperExtensions
   {

      public static MvcHtmlString FieldNameFor<TModel, TValue>(
          this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
      {
         string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

         string inputFieldName =
            helper.ViewContext.ViewData.TemplateInfo
            .GetFullHtmlFieldName(htmlFieldName);

         return MvcHtmlString.Create(inputFieldName);
      }

   }
}
