  public $actionName$($argumentWithType$): Promise<$returnType$> {
    return this.Query()$bound$
      .actionCall('$actionFullName$')
      .post($argument$)
      .toPromise()
      $returnPromise$;
  }
