  public $functionName$($argumentWithType$): Promise<$returnType$> {
    return this.Query()$bound$
      .functionCall({'$functionFullName$': $argument$})
      .get()
      .toPromise()
      $returnPromise$;
  }
