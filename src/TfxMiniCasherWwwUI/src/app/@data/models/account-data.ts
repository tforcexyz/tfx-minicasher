import { AccountHierarchy } from './account';
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

export class AccountGetHierarchyRequest {
}

export class AccountGetHierarchyResponse {
  accounts: AccountHierarchy[];
}

export class AccountCreateResponse {
  accountId: string;
  isSuccess: boolean;
}

export class AccountSearchResponse {
  accounts: AccountLite[];
}
