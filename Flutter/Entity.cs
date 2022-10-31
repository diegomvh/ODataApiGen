using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Models;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
  public class EntityProperty : ILiquidizable
  {
    protected Models.Property Value { get; set; }
    protected Flutter.StructuredType Structured { get; set; }
    public EntityProperty(ODataApiGen.Models.Property prop, Flutter.StructuredType structured)
    {
      this.Structured = structured;
      this.Value = prop;
    }

    public string Name
    {
      get
      {
        return Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        /*
        var navigation = Value is NavigationProperty;
        var name = Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        return name + (navigation ? "?" : "");
        */
      }
    }

    public string Type
    {
      get
      {
        var pkg = Program.Package as Flutter.Package;
        var nullable = Value.Nullable;
        var type = "dynamic";
        if (this.Value.IsEnumType)
        {
          var e = pkg.FindEnum(this.Value.Type);
          type = e.ImportedName;
        }
        else if (Value.IsEdmType)
        {
          type = this.Structured.ToTypescriptType(Value.Type);
          type = Value.IsCollection ? $"List<{type}>" : type;
        }
        else if (Value.IsEntityType || Value.IsComplexType)
        {
          var entity = pkg.FindEntity(this.Value.Type);
          type = Value.IsCollection ? $"List<{entity.ImportedName}>" : entity.ImportedName;
        }
        else if (Value is NavigationProperty)
        {
          var nav = Value as NavigationProperty;
          var entity = pkg.FindEntity(nav.ToEntityType);
          type = nav.Many ? $"List<{entity.ImportedName}>" : entity.ImportedName;
        }
        var required = !(Value is NavigationProperty || Value.Nullable);
        type = type + (!required ? "?" : "");
        return type;
      }
    }
    public object ToLiquid()
    {
      return new
      {
        Name = this.Name,
        Type = this.Type
      };
    }
    public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
  }
  public class Entity : StructuredType
  {
    public Entity(Models.StructuredType type, ApiOptions options) : base(type, options) { }

    public override string FileName => this.EdmStructuredType.Name.ToLower() +
    ((this.EdmStructuredType is ComplexType) ? ".complex" : ".entity");
    public override string Name => Utils.ToDartName(this.EdmStructuredType.Name, DartElement.Class);
    // Exports

    public IEnumerable<Flutter.EntityProperty> Properties
    {
      get
      {
        var props = this.EdmStructuredType.Properties.ToList();
        if (this.EdmStructuredType is EntityType)
          props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
        return props.Select(prop => new Flutter.EntityProperty(prop, this));
      }
    }
    public IEnumerable<Flutter.EntityProperty> GeoProperties => this.Properties.Where(p => p.IsGeo);
    public bool HasGeoFields => this.Options.GeoJson && this.GeoProperties.Count() > 0;
    public override object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        Type = this.Type,
        EntityType = this.EdmStructuredType.FullName
      };
    }
  }
}