using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DummyProject.Inaam
{
    public class InaamForm<T> where T : class, new()
    {
        public DbContext Context { get; set; }

        public InaamForm(DbContext context)
        {
            Context = context;
        }

        public List<InaamFormElement> InaamFormElements { get; set; }
        public InaamFormOptions InaamFormOptions { get; set; }

        public Dictionary<string, object> GetSchemaAndOptions()
        {
            return new Dictionary<string, object>() {
                ["schema"] = InaamFormElements,
                ["options"] = InaamFormOptions
            };
        }

        public T Insert(dynamic data)
        {
            var obj = new T();
            var dataObject = (JObject)data;
            foreach (var element in InaamFormElements)
            {

                var property = obj.GetType()
                    .GetProperty(element.ModelPropertyName);
                var propertyType = property.PropertyType.FullName;

                property.SetValue(obj, Convert.ChangeType( dataObject[element.Name], Type.GetType(propertyType)) );
            }

            Context.Set<T>().Add(obj);

            Context.SaveChanges();

            return obj;
        }
    }
}
