import { Observable } from "rxjs";

export class ServiceHelper {

  public static getUrl(requestUrl: string): string  {
    if (window['SERVICE_ROOT']) {
      return `${window['SERVICE_ROOT']}/${requestUrl}`;
    }
    return requestUrl;
  }

  public static createObservable<T>(httpCall: Observable<T>): Observable<T> {
    return new Observable<T>(obs => {
      httpCall.subscribe(response => {
        obs.next(response);
        obs.complete();
      }, error => {
        obs.error(error);
      })
    });
  }
}
