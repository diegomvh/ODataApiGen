
type FilterArgs<T, K> = [K, string];
type FilterSegment<T> = ODataFilterExpression<T> | ODataFilterConnection<T>;

export class ODataFilterExpression<T>{

    private value: string = "";

    private getFilterValueSegment(value: any): string {
        let castedValue = value.toString();
        if (typeof value == "string" && !/^[0-9]*$/.test(castedValue)) {
            return `('${castedValue}')`;
        }

        return `(${castedValue})`;
    }

    constructor(public filterBuilderRef: ODataFilterBuilder<T>) { }

    private Finialize() {
        this.filterBuilderRef.filterSegments.push(this);
        return new ODataFilterConnection<T>(this.filterBuilderRef);
    }

    /**
     * Creates an instance of an Equals (~eq) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */

    public Equals<K extends keyof T>(field: K, value: any) {
        this.value = `${field} eq ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }

    /**
     * Creates an instance of an Not Equals (~ne) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public NotEquals<K extends keyof T>(field: K, value: any) {
        this.value = `${field} ne ${this.getFilterValueSegment(value)}'`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a Greater Than (~gt) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public GreaterThan<K extends keyof T>(field: K, value: any) {
        this.value = `${field} gt ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a Greater Than or Equals (~ge) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public GreaterThanOrEquals<K extends keyof T>(field: K, value: any) {
        this.value = `${field} ge ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a Lesser Than (~lt) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public LessThan<K extends keyof T>(field: K, value: any) {
        this.value = `${field} lt ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }


    /**
     * Creates an instance of a Lesser Than or equals (~le) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public LessThanOrEquals<K extends keyof T>(field: K, value: any) {
        this.value = `${field} le ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a HAS (~has) filter segment
     * @param field The name of the field to check (String literal)
     * @param value The value to check
     * @returns The next ODataFilterConnection (Fluent)
     */
    public Has<K extends keyof T>(field: K, value: any) {
        this.value = `${field} has ${this.getFilterValueSegment(value)}`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a nested negated (~not) FilterBuilder object
     * @param build The fluent chain for the filter expression
     * @returns The next ODataFilterConnection (Fluent)
     */
    public Not<K extends keyof T>(build: (b: ODataFilterExpression<T>) => void) {
        let builder = ODataFilterBuilder.Create<T>();
        build(ODataFilterBuilder.Create<T>());
        this.value = `not (${builder.toString()})`;
        return this.Finialize();
    }

    /**
     * Creates an instance of a nested FilterBuilder object
     * @param build The fluent chain for the filter expression
     * @returns The next ODataFilterConnection (Fluent)
     */
    public BuildFilter(build: (b: ODataFilterExpression<T>) => void) {
        let builder = ODataFilterBuilder.Create<T>();
        build(ODataFilterBuilder.Create<T>());
        this.value = `(${builder.toString()})`;
        return this.Finialize();
    }

    /**
     * Gets the evaluated OData filter segment
     * @returns The OData filter segment
     */
    public toString(): string {
        return this.value;
    }

}

export class ODataFilterConnection<T>{

    private type: string;
    constructor(public filterBuilderRef: ODataFilterBuilder<T>) { }

    /**
     * Sets the connection between OData Filter expression segments to 'AND' type
     * @returns The next ODataFilterExpression (Fluent)
     */
    public get And() {
        this.type = "and";
        this.filterBuilderRef.filterSegments.push(this);
        return new ODataFilterExpression<T>(this.filterBuilderRef);
    }

    /**
    * Sets the connection between OData Filter expression segments to 'OR' type
    * @returns The next ODataFilterExpression (Fluent)
    */
    public get Or() {
        this.type = "or";
        this.filterBuilderRef.filterSegments.push(this);
        return new ODataFilterExpression<T>(this.filterBuilderRef);
    }

    public toString() {
        return this.type;
    }
}

export class ODataFilterBuilder<T>{

    public filterSegments: FilterSegment<T>[] = [];


    /**
     * Factory method for creating ODataFilterBuilders
     * @returns The first ODataFilterExpression value for the ODataFilterBuilder
     */
    public static Create<T>(): ODataFilterExpression<T> {
        let builder = new ODataFilterBuilder();
        let firstSegment = new ODataFilterExpression(builder);
        return firstSegment;
    }


    /**
     * Evaluates the ODataFilterBuilder<T>'s segments into a parsed OData Filter expression
     * @returns The Filter query expression
     */
    public toString(): string {
        return this.filterSegments.map(s => s.toString()).join(' ');
    }
}