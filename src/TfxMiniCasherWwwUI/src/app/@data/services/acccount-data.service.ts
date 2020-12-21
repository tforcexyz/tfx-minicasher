import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { AccountSearchResponse } from '../models/account-data';
import { ServiceHelper } from './data.service';

interface IAccountDataService {
  searchAccounts() : Observable<AccountSearchResponse>;
}

export abstract class AccountDataService implements IAccountDataService {
  abstract searchAccounts(): Observable<AccountSearchResponse>;
}

@Injectable()
export class AccountDataServiceImpl extends AccountDataService {
  constructor(private http: HttpClient) {
    super();
  }

  searchAccounts() : Observable<AccountSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountSearchResponse>(ServiceHelper.getUrl('api/accounting/account')));
  }
}
