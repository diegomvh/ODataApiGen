using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using DotLiquid;
using System.IO;
using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Flutter
{
  public class EntityKeyConfig : ILiquidizable
  {
    protected Models.PropertyRef Value { get; set; }
    protected Flutter.StructuredTypeConfig Config { get; set; }
    public EntityKeyConfig(Models.PropertyRef property, Flutter.StructuredTypeConfig config)
    {
      this.Value = property;
      this.Config = config;
    }

    public override string ToString()
    {
      var values = new Dictionary<string, string>();
      values.Add("name", $"'{Value.Name}'");
      if (!String.IsNullOrWhiteSpace(Value.Alias))
      {
        values.Add("alias", $"'{Value.Alias}'");
      }
      return $"{{{String.Join(", ", values.Select(p => $"{p.Key}: {p.Value}"))}}}";
    }
    public object ToLiquid()
    {
      return new
      {
        Value = this.ToString(),
      };
    }
  }
  public class EntityFieldConfig : ILiquidizable
  {
    protected Models.Property Value { get; set; }
    protected Flutter.StructuredTypeConfig Config { get; set; }
    public EntityFieldConfig(Models.Property property, Flutter.StructuredTypeConfig config)
    {
      this.Value = property;
      this.Config = config;
    }
    //public string Name => Flutter.ToTypescriptName(Value.Name, TypeScriptElement.Method);
    public string Name => Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";

    public string Type
    {
      get
      {
        var values = new Dictionary<string, string>();
        if (this.Name != this.Value.Name)
          values.Add("name", $"'{this.Value.Name}'");
        if (this.Value.Type != null)
        {
          values.Add("type", $"'{this.Value.Type}'");
        }
        else if (this.Value is NavigationProperty)
        {
          var nav = this.Value as NavigationProperty;
          values.Add("type", $"'{nav.ToEntityType}'");
        }
        if (!(this.Value is NavigationProperty) && !this.Value.Nullable)
          values.Add("nullable", "false");
        if (!String.IsNullOrEmpty(this.Value.MaxLength) && this.Value.MaxLength.ToLower() != "max")
          values.Add("maxLength", this.Value.MaxLength);
        if (!String.IsNullOrEmpty(this.Value.DefaultValue))
          values.Add("default", $"'{this.Value.DefaultValue}'");
        if (!String.IsNullOrEmpty(this.Value.SRID))
          values.Add("srid", $"'{this.Value.SRID}'");
        if (!String.IsNullOrEmpty(this.Value.Precision))
          values.Add("precition", this.Value.Precision);
        if (!String.IsNullOrEmpty(this.Value.Scale)) {
          var value = this.Value.Scale.ToLower();
          if (value == "variable")
            value = $"'variable'";
          values.Add("scale", value);
        }
        if (this.Value.IsCollection || this.Value is NavigationProperty && (this.Value as NavigationProperty).Many)
          values.Add("collection", "true");
        if (this.Value is NavigationProperty)
        {
          // Is Navigation
          values.Add("navigation", "true");
          var nav = this.Value as NavigationProperty;
          if (nav.Referentials.Count() > 0)
          {
            values.Add("referentials", $"[{String.Join(", ", nav.Referentials.Select(p => $"{{property: '{p.Property}', referencedProperty: '{p.ReferencedProperty}'}}"))}]");
          }
        }
        var annots = this.Value.Annotations;
        if (annots.Count > 0)
        {
          var json = JsonSerializer.Serialize(annots.Select(annot => annot.ToDictionary()));
          values.Add("annotations", $"{json}");
        }
        return $"{{{String.Join(", ", values.Select(p => $"{p.Key}: {p.Value}"))}}}";
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
  }
  public class StructuredTypeConfig : FlutterRenderable, DotLiquid.ILiquidizable
  {
    public Flutter.Entity Entity { get; private set; }
    public Flutter.Model Model { get; private set; }
    public Flutter.Collection Collection { get; private set; }
    public StructuredTypeConfig(Flutter.Entity entity, ApiOptions options) : base(options)
    {
      this.Entity = entity;
      this.AddDependency(entity);
    }
    public StructuredTypeConfig(Flutter.Entity entity, Flutter.Model model, Flutter.Collection collection, ApiOptions options) : this(entity, options)
    {
      this.Model = model;
      this.Collection = collection;
      this.AddDependency(model);
      this.AddDependency(collection);
    }
    public override string FileName => this.Entity.FileName + ".config";
    public override string Name => this.Entity.Name +
    ((this.Entity.EdmStructuredType is ComplexType) ? "ComplexConfig" : "EntityConfig");
    public string EntityType => this.Entity.EdmStructuredType.FullName;
    public string EdmEntityName => this.Entity.EdmStructuredType.Name;
    public string EntityName => this.Entity.Name;
    public bool OpenType => this.Entity.OpenType;

    public bool HasAnnotations => this.Entity.EdmStructuredType.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.Entity.EdmStructuredType.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public bool HasKey => this.Entity.EdmStructuredType is EntityType && (this.Entity.EdmStructuredType as EntityType).Keys.Count() > 0;
    public IEnumerable<Flutter.EntityKeyConfig> Keys
    {
      get
      {
        var keys = (this.Entity.EdmStructuredType is EntityType) ? (this.Entity.EdmStructuredType as EntityType).Keys : new List<PropertyRef>();
        return keys.Select(prop => new EntityKeyConfig(prop, this));
      }
    }
    public IEnumerable<Flutter.EntityFieldConfig> Properties
    {
      get
      {
        var props = this.Entity.EdmStructuredType.Properties.ToList();
        if (this.Entity.EdmStructuredType is EntityType)
          props.AddRange((this.Entity.EdmStructuredType as EntityType).NavigationProperties);
        return props.Select(prop => new EntityFieldConfig(prop, this));
      }
    }

    // Imports
    public override IEnumerable<string> ImportTypes => new List<string> { this.EntityType };
    public override string Namespace => this.Entity.EdmStructuredType.Namespace;
    public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public override IEnumerable<Import> Imports => GetImportRecords();

    public Flutter.StructuredType Base => this.Entity.Base;
    public object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        Type = this.Type,
        EntityName = this.EntityName
      };
    }
  }
}