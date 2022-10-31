//#region ODataApiGen ODataImports
import 'dart:typed_data';
import 'package:odata/odata.dart';
//#endregion

//#region ODataApiGen Imports
{% if HasGeoFields %}import { {% for p in GeoProperties %}{{p.Type}}{% unless forloop.last %},{% endunless %}{% endfor %} } from 'geojson';
{% endif %}{% for import in Imports %}import '{{import.Path}}';
{% endfor %}//#endregion

class {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  //#region ODataApiGen Properties
  {% for property in Properties %}{{property.Type}} {{property.Name}};
  {% endfor %}//#endregion

  {{Name}}({
    {% for property in Properties %}required this.{{property.Name}},
    {% endfor %}});

  factory {{Name}}.fromMap(Map<String, dynamic> data) {
    return {{Name}}(
    {% for property in Properties %}{{property.Name}}: data['{{property.Name}}'],
    {% endfor %});
  }

  static List<{{Name}}> fromMany(List<Map<String, dynamic>> datas) {
    return datas.map((data) => {{Name}}.fromMap(data)).toList();
  }
}