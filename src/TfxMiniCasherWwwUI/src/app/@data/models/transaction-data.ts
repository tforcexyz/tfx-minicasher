import { Transaction } from './transaction';
import { TransactionLite } from './transaction';

export class TransactionCreateRequest {
  amount: number;
  creditAccountId: string;
  debitAccountId: string;
  issuedTime: Date;
  name: string;
}

export class TransactionCreateResponse {
  isSuccess: boolean;
  transactionId: string;
}

export class TransactionDeleteResponse {
  isSuccess: boolean;
  transactionId: string;
}

export class TransactionEditRequest {
  amount: number;
  creditAccountId: string;
  debitAccountId: string;
  issuedTime: Date;
  name: string;
}

export class TransactionEditResponse {
  isSuccess: boolean;
  transactionId: string;
}

export class TransactionGetResponse {
  transaction: Transaction;
}

export class TransactionSearchResponse {
  transactions: TransactionLite[];
}
