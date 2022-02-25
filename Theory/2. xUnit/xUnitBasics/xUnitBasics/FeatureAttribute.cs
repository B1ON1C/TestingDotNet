using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace xUnitBasics
{
    [TraitDiscoverer(FeatureDiscoverer.TypeName, TraitDiscovererBase.AssemblyName)]
    public class FeatureAttribute : Attribute, ITraitAttribute
    {
        public string Id { get; set; }
        public FeatureAttribute(string id) => Id = id;
        public FeatureAttribute() { }
    }

    public class FeatureDiscoverer : TraitDiscovererBase, ITraitDiscoverer
    {
        public const string TypeName = TraitDiscovererBase.AssemblyName + ".FeatureDiscoverer";

        protected override string CategoryName => "Feature";
        public override IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return GetCategory();
            var id = traitAttribute.GetNamedArgument<string>(nameof(FeatureAttribute.Id));
            if (!string.IsNullOrEmpty(id))
            {
                yield return new KeyValuePair<string, string>(TypeName, id);
            }
        }
    }

    public class TraitDiscovererBase : ITraitDiscoverer
    {
        public const string AssemblyName = "xUnitBasics";
        protected const string Category = nameof(Category);
        protected virtual string CategoryName => nameof(CategoryName);

        protected KeyValuePair<string, string> GetCategory()
        {
            return new KeyValuePair<string, string>(Category, CategoryName);
        }
        public virtual IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }
    }
}
