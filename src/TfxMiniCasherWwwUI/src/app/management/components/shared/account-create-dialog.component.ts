import { Component } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { NbDialogRef } from "@nebular/theme";
import { OnInit } from "@angular/core";

import { AccountCreateRequest } from '../../../@data/models/account-data';
import { AccountDataService } from "../../../@data/services";
import { AccountHierarchy } from '../../../@data/models/account';
import { KeyValuePair } from '../../../@extend/models/common';

@Component({
  selector: 'miana-account-create',
  templateUrl: './account-create-dialog.component.html',
})
export class AccountCreateDialogComponent implements OnInit {

  form: any;
  isDataLoaded: boolean;
  parentAccountOptions: KeyValuePair<string, string>[];
  remoteDataCounter: number;

  constructor(private accountDataService: AccountDataService,
    private formBuilder: FormBuilder,
    protected ref: NbDialogRef<AccountCreateDialogComponent>) {
      this.form = this.formBuilder.group({
        accountType: null,
        code: null,
        description: null,
        isHidden: null,
        name: null,
        parentId: null,
      })
  }

  dismiss() {
    this.ref.close({
      refresh: false,
    } as AccountCreateDialogResult);
  }

  initParentAccountOptions() {
    this.accountDataService.getAccountHierarchy({}).subscribe(response => {
      this.parentAccountOptions = this.createParentAccountOptions(response.accounts, 0);
      this.onRemoteDataLoaded();
    })
  }

  ngOnInit(): void {
    this.remoteDataCounter = 0;
    this.initParentAccountOptions();
    this.setDefaultFormValues();
  }

  onRemoteDataLoaded() {
    this.remoteDataCounter++;
    if (this.remoteDataCounter >= 1) {
      this.isDataLoaded = true;
    }
  }

  setDefaultFormValues() {
    this.form.patchValue({
      isHidden: false,
      parentId: '00000000-0000-0000-0000-000000000000',
    })
  }

  submit() {
    this.onSubmit(this.form.value);
  }

  onSubmit(formData) {
    console.log(formData);
    let parentId: string = formData.parentId == '00000000-0000-0000-0000-000000000000' ? null : formData.parentId;
    let request: AccountCreateRequest = {
      code: formData.code,
      debitOrCredit: formData.accountType,
      description: formData.description,
      isHidden: formData.isHidden,
      name: formData.name,
      parentId: parentId,
    }
    this.accountDataService.createAccount(request).subscribe(response => {
      if (response.isSuccess) {
        this.ref.close({
          refresh: response.isSuccess,
        } as AccountCreateDialogResult);
      }
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

export class AccountCreateDialogResult {
  refresh: boolean;
}