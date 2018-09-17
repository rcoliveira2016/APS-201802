using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace APS.Infra.Data.Context.Extensions.EntityFramework.Mappings
{
    public static class PropertyConfigurationExtension
    {
        public static PrimitivePropertyConfiguration HasUniqueKey(this PrimitivePropertyConfiguration property, string name, int order)
        {
            return property.HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute(name, order) { IsUnique = true }
                )
            );
        }
    }
}
