  public $actionName$($argumentWithType$): Promise<$returnType$> {
    return this.Query({action: '$actionFullName$'})$bound$
      .post($argument$)
      .toPromise()
      $returnPromise$;
  }
