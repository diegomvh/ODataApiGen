  public $functionName$($argumentWithType$): Promise<$returnType$> {
    return this.Query({func: {'$functionFullName$': $argument$}})$bound$
      .get()
      .toPromise()
      $returnPromise$;
  }
