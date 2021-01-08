import { AccountLite } from './account';

export class Transaction {
  id: string;
  code: string;
  name: string;
  debitAccount: AccountLite;
  creditAccount: AccountLite;
  amount: number;
  issuedTime: Date;
}

export class TransactionLite {
  id: string;
  code: string;
  name: string;
  debitAccountId: string;
  debitAccountName: string;
  creditAccountId: string;
  creditAccountName: string;
  amount: number;
  issuedTime: Date;
}
