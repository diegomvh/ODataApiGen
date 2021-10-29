using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Models;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
  public class EntityProperty : ILiquidizable
  {
    protected Models.Property Value { get; set; }
    protected Angular.StructuredType Structured { get; set; }
    public EntityProperty(ODataApiGen.Models.Property prop, Angular.StructuredType structured)
    {
      this.Structured = structured;
      this.Value = prop;
    }

    public string Name
    {
      get
      {
        var required = !(Value is NavigationProperty || Value.Nullable);
        var name = Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        return name + (!required ? "?" : "");
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
        var pkg = Program.Package as Angular.Package;
        var nullable = Value.Nullable;
        var type = "any";
        if (this.Value.IsEnumType)
        {
          var e = pkg.FindEnum(this.Value.Type);
          type = e.ImportedName;
        }
        else if (Value.IsEdmType)
        {
          type = this.Structured.ToTypescriptType(Value.Type);
          type = type + (Value.IsCollection ? "[]" : "");
        }
        else if (Value.IsEntityType || Value.IsComplexType)
        {
          var entity = pkg.FindEntity(this.Value.Type);
          type = $"{entity.ImportedName}" + (Value.IsCollection ? "[]" : "");
        }
        else if (Value is NavigationProperty)
        {
          var nav = Value as NavigationProperty;
          var entity = pkg.FindEntity(nav.ToEntityType);
          type = $"{entity.ImportedName}" + (nav.Many ? "[]" : "");
        }
        /*
        if (nullable)
        {
          type = type + " | null";
        }
        */
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
    public override string Name => Utils.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class);
    // Exports

    public IEnumerable<Angular.EntityProperty> Properties
    {
      get
      {
        var props = this.EdmStructuredType.Properties.ToList();
        if (this.EdmStructuredType is EntityType)
          props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
        return props.Select(prop => new Angular.EntityProperty(prop, this));
      }
    }
    public IEnumerable<Angular.EntityProperty> GeoProperties => this.Properties.Where(p => p.IsGeo);
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