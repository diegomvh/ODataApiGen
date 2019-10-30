{% for export in Exports %}{{export}}{% unless forloop.last %};
{% endunless %}{% endfor %}
export * from './{{Package.Endpoint}}.config';
export * from './{{Package.Endpoint}}.module';