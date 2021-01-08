import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { AccountCreateRequest } from '../models/account-data';
import { AccountCreateResponse } from '../models/account-data';
import { AccountDeleteResponse } from '../models/account-data';
import { AccountEditRequest } from '../models/account-data';
import { AccountEditResponse } from '../models/account-data';
import { AccountGetResponse } from '../models/account-data';
import { AccountGetHierarchyRequest } from '../models/account-data';
import { AccountGetHierarchyResponse } from '../models/account-data';
import { AccountSearchResponse } from '../models/account-data';
import { ServiceHelper } from './data.service';

interface IAccountDataService {
  createAccount(request: AccountCreateRequest): Observable<AccountCreateResponse>;
  deleteAccount(accountId): Observable<AccountDeleteResponse>;
  editAccount(accountId: string, request: AccountEditRequest): Observable<AccountEditResponse>;
  getAccount(accountId: string): Observable<AccountGetResponse>;
  getAccountHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse>;
  searchAccounts(): Observable<AccountSearchResponse>;
}

export abstract class AccountDataService implements IAccountDataService {
  abstract createAccount(request: AccountCreateRequest): Observable<AccountCreateResponse>;
  abstract deleteAccount(accountId): Observable<AccountDeleteResponse>;
  abstract editAccount(accountId: string, request: AccountEditRequest): Observable<AccountEditResponse>;
  abstract getAccount(accountId: string): Observable<AccountGetResponse>;
  abstract getAccountHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse>;
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

  deleteAccount(accountId): Observable<AccountDeleteResponse> {
    return ServiceHelper.createObservable(this.http.delete<AccountDeleteResponse>(ServiceHelper.getUrl(`api/accounting/account/${accountId}`)));
  }

  editAccount(accountId: string, request: AccountEditRequest): Observable<AccountEditResponse> {
    return ServiceHelper.createObservable(this.http.put<AccountEditResponse>(ServiceHelper.getUrl(`api/accounting/account/${accountId}`), request));
  }

  getAccount(accountId: string): Observable<AccountGetResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountGetResponse>(ServiceHelper.getUrl(`api/accounting/account/${accountId}`)));
  }

  getAccountHierarchy(request: AccountGetHierarchyRequest): Observable<AccountGetHierarchyResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountGetHierarchyResponse>(ServiceHelper.getUrl('api/accounting/account/hierarchy'), request));
  }

  searchAccounts() : Observable<AccountSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<AccountSearchResponse>(ServiceHelper.getUrl('api/accounting/account')));
  }
}
