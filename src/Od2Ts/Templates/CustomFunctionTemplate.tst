  public $functionName$($argumentWithType$): Observable<ODataResponse> {
    return this.Query()$bound$
      .functionCall({'$functionFullName$': $argument$})
      .get();
  }
