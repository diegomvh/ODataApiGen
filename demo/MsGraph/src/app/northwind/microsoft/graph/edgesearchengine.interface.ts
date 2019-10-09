import { edgeSearchEngineType } from './edgesearchenginetype.enum';
import { edgeSearchEngineBase } from './edgesearchenginebase.interface';

export interface edgeSearchEngine extends edgeSearchEngineBase {
  edgeSearchEngineType: edgeSearchEngineType
}
