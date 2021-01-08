import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { ServiceHelper } from './data.service';
import { TransactionCreateRequest } from '../models/transaction-data';
import { TransactionCreateResponse } from '../models/transaction-data';
import { TransactionDeleteResponse } from '../models/transaction-data';
import { TransactionEditRequest } from '../models/transaction-data';
import { TransactionEditResponse } from '../models/transaction-data';
import { TransactionGetResponse } from '../models/transaction-data';
import { TransactionSearchResponse } from '../models/transaction-data';

interface ITransactionDataService {
  createTransaction(request: TransactionCreateRequest): Observable<TransactionCreateResponse>;
  deleteTransaction(transactionId): Observable<TransactionDeleteResponse>;
  editTransaction(transactionId: string, request: TransactionEditRequest) : Observable<TransactionEditResponse>;
  getTransaction(transactionId: string): Observable<TransactionGetResponse>;
  searchTransactions(): Observable<TransactionSearchResponse>;
}

export abstract class TransactionDataService implements ITransactionDataService {
  abstract createTransaction(request: TransactionCreateRequest): Observable<TransactionCreateResponse>;
  abstract deleteTransaction(transactionId): Observable<TransactionDeleteResponse>;
  abstract editTransaction(transactionId: string, request: TransactionEditRequest) : Observable<TransactionEditResponse>;
  abstract getTransaction(transactionId: string): Observable<TransactionGetResponse>;
  abstract searchTransactions(): Observable<TransactionSearchResponse>;
}

@Injectable()
export class TransactionDataServiceImpl extends TransactionDataService {
  constructor(private http: HttpClient) {
    super();
  }

  createTransaction(request: TransactionCreateRequest): Observable<TransactionCreateResponse> {
    return ServiceHelper.createObservable(this.http.post<TransactionCreateResponse>(ServiceHelper.getUrl('api/accounting/transaction'), request));
  }

  deleteTransaction(transactionId): Observable<TransactionDeleteResponse> {
    return ServiceHelper.createObservable(this.http.delete<TransactionDeleteResponse>(ServiceHelper.getUrl(`api/accounting/transaction/${transactionId}`)));
  }

  editTransaction(transactionId: string, request: TransactionEditRequest) : Observable<TransactionEditResponse> {
    return ServiceHelper.createObservable(this.http.put<TransactionEditResponse>(ServiceHelper.getUrl(`api/accounting/transaction/${transactionId}`), request));
  }

  getTransaction(transactionId: string): Observable<TransactionGetResponse> {
    return ServiceHelper.createObservable(this.http.get<TransactionGetResponse>(ServiceHelper.getUrl(`api/accounting/transaction/${transactionId}`)));
  }

  searchTransactions(): Observable<TransactionSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<TransactionSearchResponse>(ServiceHelper.getUrl('api/accounting/transaction')));
  }
}
