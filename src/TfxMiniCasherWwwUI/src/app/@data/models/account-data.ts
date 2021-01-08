import { AccountHierarchy } from './account';
import { Account } from './account';
import { AccountLite } from './account';
import { DebitOrCredit } from '../types';

export class AccountCreateRequest {
  code: string;
  name: string;
  description: string;
  parentId: string;
  debitOrCredit: DebitOrCredit;
  isHidden: boolean;
}

export class AccountCreateResponse {
  accountId: string;
  isSuccess: boolean;
}

export class AccountDeleteResponse {
  accountId: string;
  isSuccess: boolean;
}

export class AccountEditRequest {
  code: string;
  name: string;
  description: string;
  parentId: string;
  debitOrCredit: DebitOrCredit;
  isHidden: boolean;
}

export class AccountEditResponse {
  accountId: string;
  isSuccess: boolean;
}

export class AccountGetResponse {
  account: Account;
}

export class AccountGetHierarchyRequest {
}

export class AccountGetHierarchyResponse {
  accounts: AccountHierarchy[];
}

export class AccountSearchResponse {
  accounts: AccountLite[];
}
