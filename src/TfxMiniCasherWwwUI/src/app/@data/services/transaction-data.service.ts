import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { ServiceHelper } from './data.service';
import { TransactionCreateRequest } from '../models/transaction-data';
import { TransactionCreateResponse } from '../models/transaction-data';
import { TransactionSearchResponse } from '../models/transaction-data';

interface ITransactionDataService {
  createTransaction(request: TransactionCreateRequest): Observable<TransactionCreateResponse>;
  searchTransactions(): Observable<TransactionSearchResponse>;
}

export abstract class TransactionDataService implements ITransactionDataService {
  abstract createTransaction(request: TransactionCreateRequest): Observable<TransactionCreateResponse>;
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

  searchTransactions(): Observable<TransactionSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<TransactionSearchResponse>(ServiceHelper.getUrl('api/accounting/transaction')));
  }
}
