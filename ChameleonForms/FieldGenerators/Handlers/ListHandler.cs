﻿using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using ChameleonForms.Attributes;
using ChameleonForms.Component.Config;

namespace ChameleonForms.FieldGenerators.Handlers
{
    internal class ListHandler<TModel, T> : FieldGeneratorHandler<TModel, T>
    {
        public ListHandler(IFieldGenerator<TModel, T> fieldGenerator, IFieldConfiguration fieldConfiguration)
            : base(fieldGenerator, fieldConfiguration)
        {}

        public override HandleAction Handle()
        {
            if (!FieldGenerator.Metadata.AdditionalValues.ContainsKey(ExistsInAttribute.ExistsKey) ||
                    FieldGenerator.Metadata.AdditionalValues[ExistsInAttribute.ExistsKey] as bool? != true)
                return HandleAction.Continue;

            var selectList = GetSelectList();
            var html = GetSelectListHtml(selectList);
            return HandleAction.Return(html);
        }

        private IEnumerable<SelectListItem> GetSelectList()
        {
            var model = FieldGenerator.GetModel();
            var listProperty = model.GetType().GetProperty((string)FieldGenerator.Metadata.AdditionalValues[ExistsInAttribute.PropertyKey]);
            var listValue = (IEnumerable)listProperty.GetValue(model, null);
            return GetSelectListUsingPropertyReflection(
                listValue,
                (string)FieldGenerator.Metadata.AdditionalValues[ExistsInAttribute.NameKey],
                (string)FieldGenerator.Metadata.AdditionalValues[ExistsInAttribute.ValueKey]
            );
        }

        private IEnumerable<SelectListItem> GetSelectListUsingPropertyReflection(IEnumerable listValues, string nameProperty, string valueProperty)
        {
            foreach (var item in listValues)
            {
                var name = item.GetType().GetProperty(nameProperty).GetValue(item, null);
                var value = item.GetType().GetProperty(valueProperty).GetValue(item, null);
                yield return new SelectListItem { Selected = IsSelected(value), Value = value.ToString(), Text = name.ToString() };
            }
        }
    }
}
