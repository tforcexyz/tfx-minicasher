import { DebitOrCredit } from '../types/debitOrCredit';

export interface Account {
  id: string;
  code: string;
  name: string;
  parentId: string;
  debitOrCredit: DebitOrCredit,
  isHidden: boolean,
}

export interface AccountLite {
  id: string;
  code: string;
  name: string;
  parentId: string;
  debitOrCredit: DebitOrCredit,
}
