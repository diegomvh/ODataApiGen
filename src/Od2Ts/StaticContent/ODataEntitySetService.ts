import { ODataContext } from "./ODataContext";
import { ODataService, ODataQuery } from "../odata";

export class ODataEntitySetService<T> {
  constructor(
    protected odataService: ODataService, 
    protected context: ODataContext, 
    protected entitySetName: string) {
  }

  public Query() {
    return new ODataQuery(this.odataService, this.context.ODataRootPath).entitySet(this.entitySetName);
  }
}