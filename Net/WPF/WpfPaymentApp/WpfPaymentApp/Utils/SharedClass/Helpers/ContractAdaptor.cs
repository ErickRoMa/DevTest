using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfPaymentApp.ViewModel.SharedClass.Helpers
{
    internal static class ContractAdaptor
    {
        public static T ContractToEntity<T>(this object source)
        {
            T target = (T)Activator.CreateInstance(typeof(T));
            PropertyDescriptorCollection targetProperties = TypeDescriptor.GetProperties(typeof(T));
            IEnumerable<PropertyDescriptor> tProperties = targetProperties.Cast<PropertyDescriptor>();
            PropertyDescriptor tProperty = default;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                if ((tProperty = tProperties.Where(r => r.Name == property.Name).FirstOrDefault()) == null)
                    continue;

                tProperty.SetValue(target, property.GetValue(source));
            }

            return target;
        }
    }
}
