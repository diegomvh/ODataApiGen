//#region ODataApi Imports
{% for export in Exports %}{{export}};
{% endfor %}//#endregion
export * from './{{Package.Name}}.config';
export * from './{{Package.Name}}.module';