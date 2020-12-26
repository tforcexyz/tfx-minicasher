import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { AccountCreateRequest } from '../models/account-data';
import { AccountCreateResponse } from '../models/account-data';
import { AccountGetHierarchyRequest } from '../models/account-data';
import { AccountGetHierarchyResponse } from '../models/account-data';
import { AccountSearchResponse } from '../models/account-data';
import { ServiceHelper } from './data.service';

interface IAccountDataService {
  createAccount(request: AccountCreateRequest): Observable<AccountCreateResponse>;
  getHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse>;
  searchAccounts(): Observable<AccountSearchResponse>;
}

export abstract class AccountDataService implements IAccountDataService {
  abstract createAccount(request: AccountCreateRequest): Observable<AccountCreateResponse>;
  abstract getHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse>;
  abstract searchAccounts(): Observable<AccountSearchResponse>;
}

@Injectable()
export class AccountDataServiceImpl extends AccountDataService {
  constructor(private http: HttpClient) {
    super();
  }

  createAccount(request: AccountCreateRequest) : Observable<AccountCreateResponse> {
    return ServiceHelper.createObservable(this.http.post<AccountCreateResponse>(ServiceHelper.getUrl('api/accounting/account'), request));
  }

  getHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountGetHierarchyResponse>(ServiceHelper.getUrl('api/accounting/account/hierarchy'), request));
  }

  searchAccounts() : Observable<AccountSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountSearchResponse>(ServiceHelper.getUrl('api/accounting/account')));
  }
}
