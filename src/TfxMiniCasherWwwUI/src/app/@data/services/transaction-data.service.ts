import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

import { ServiceHelper } from './data.service';
import { TransactionSearchResponse } from '../models/transaction-data';

interface ITransactionDataService {
  searchTransactions(): Observable<TransactionSearchResponse>;
}

export abstract class TransactionDataService implements ITransactionDataService {
  abstract searchTransactions(): Observable<TransactionSearchResponse>;
}

@Injectable()
export class TransactionDataServiceImpl extends TransactionDataService {
  constructor(private http: HttpClient) {
    super();
  }

  searchTransactions(): Observable<TransactionSearchResponse> {
    return ServiceHelper.createObservable(this.http.get<TransactionSearchResponse>(ServiceHelper.getUrl('api/accounting/transaction')));
  }
}
