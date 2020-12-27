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

export class TransactionSearchResponse {
  transactions: TransactionLite[];
}
