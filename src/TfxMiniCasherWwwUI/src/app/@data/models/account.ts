import { DebitOrCredit } from '../types/debitOrCredit';

export interface Account {
  id: string;
  code: string;
  name: string;
  description: string;
  parentId: string;
  debitOrCredit: DebitOrCredit,
  isHidden: boolean,
}

export interface AccountHierarchy {
  id: string;
  code: string;
  name: string;
  children: AccountHierarchy[];
}

export interface AccountLite {
  id: string;
  code: string;
  name: string;
  parentId: string;
  debitOrCredit: DebitOrCredit,
}
