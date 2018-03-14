  public $actionName$($argumentWithType$): Observable<ODataResponse> {
    return this.Query()$bound$
      .actionCall('$actionFullName$')
      .post($argument$);
  }
