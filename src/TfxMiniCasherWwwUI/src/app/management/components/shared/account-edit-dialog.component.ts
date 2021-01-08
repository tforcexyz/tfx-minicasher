import { Component } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { NbDialogRef } from "@nebular/theme";
import { OnInit } from "@angular/core";

import { Account } from '../../../@data/models/account';
import { AccountDataService } from "../../../@data/services";
import { AccountEditRequest } from '../../../@data/models/account-data';
import { AccountHierarchy } from '../../../@data/models/account';
import { KeyValuePair } from '../../../@extend/models/common';

@Component({
  selector: 'miana-account-edit',
  templateUrl: './account-edit-dialog.component.html',
})
export class AccountEditDialogComponent implements OnInit {

  account: Account;
  accountId: string;
  form: any;
  isDataLoaded: boolean;
  isDataSubmitting: boolean;
  parentAccountOptions: KeyValuePair<string, string>[];
  remoteDataCounter: number;

  constructor(private accountDataService: AccountDataService,
    private formBuilder: FormBuilder,
    protected ref: NbDialogRef<AccountEditDialogComponent>) {
      this.form = this.formBuilder.group({
        accountType: null,
        code: null,
        description: null,
        isHidden: null,
        name: null,
        parentId: null,
      })
  }

  getDetail(accountId: string) {
    this.accountDataService.getAccount(accountId).subscribe(response =>{
      this.account = response.account;
      this.setFormValues(response.account);
      this.onRemoteDataLoaded();
    })
  }

  initParentAccountOptions() {
    this.accountDataService.getAccountHierarchy({}).subscribe(response => {
      this.parentAccountOptions = this.createParentAccountOptions(response.accounts, 0);
      this.onRemoteDataLoaded();
    })
  }

  onCancelClick() {
    this.ref.close({
      refresh: false,
    } as AccountEditDialogResult);
  }

  onFormSubmit(formData) {
    let parentId: string = formData.parentId == '00000000-0000-0000-0000-000000000000' ? null : formData.parentId;
    let request: AccountEditRequest = {
      code: formData.code,
      debitOrCredit: formData.accountType,
      description: formData.description,
      isHidden: formData.isHidden,
      name: formData.name,
      parentId: parentId,
    }
    this.isDataSubmitting = true;
    this.accountDataService.editAccount(this.accountId, request).subscribe(response => {
      this.isDataSubmitting = false;
      if (response.isSuccess) {
        this.ref.close({
          refresh: response.isSuccess,
        } as AccountEditDialogResult);
      }
    }, error => {
      this.isDataSubmitting = false;
    })
  }

  ngOnInit(): void {
    this.remoteDataCounter = 0;
    this.initParentAccountOptions();
    this.getDetail(this.accountId);
  }

  onRemoteDataLoaded() {
    this.remoteDataCounter++;
    if (this.remoteDataCounter >= 2) {
      this.isDataLoaded = true;
    }
  }

  onSubmitClick() {
    this.onFormSubmit(this.form.value);
  }

  setFormValues(account: Account) {
    this.form.patchValue({
      accountType: account.debitOrCredit,
      code: account.code,
      description: account.description,
      isHidden: account.isHidden,
      name: account.name,
      parentId: account.parentId ?? '00000000-0000-0000-0000-000000000000',
    })
  }

  private createParentAccountOptions(accountHierarchies: AccountHierarchy[], level: number): KeyValuePair<string, string>[] {
    const prefix: string = Array(level * 2 + 1).join('-');
    let results: KeyValuePair<string, string>[] = accountHierarchies.reduce((total, accountHierarchy) => {
      let option: KeyValuePair<string, string> = {
        key: accountHierarchy.id,
        value: `${prefix} ${accountHierarchy.code}: ${accountHierarchy.name}`,
      }
      let subOptions = accountHierarchy.children == null
        ? []
        : this.createParentAccountOptions(accountHierarchy.children, level + 1);
      return [...total, option, ...subOptions];
    }, [])
    return results;
  }
}

export class AccountEditDialogResult {
  refresh: boolean;
}
