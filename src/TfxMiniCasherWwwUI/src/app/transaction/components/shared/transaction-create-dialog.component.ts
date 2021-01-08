import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { NbDialogRef } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { AccountDataService } from "../../../@data/services";
import { AccountHierarchy } from '../../../@data/models';
import { KeyValuePair } from '../../../@extend/models';
import { TransactionCreateRequest } from '../../../@data/models';
import { TransactionDataService } from "../../../@data/services";

@Component({
  selector: 'miana-transaction-create',
  styleUrls: ['./transaction-create-dialog.component.scss'],
  templateUrl: './transaction-create-dialog.component.html',
})
export class TransactionCreateDialogComponent implements OnInit {

  creditAccountOptions: KeyValuePair<string, string>[];
  debitAccountOptions: KeyValuePair<string, string>[];
  form: FormGroup;
  isDataLoaded: boolean;
  isDataSubmitting: boolean;
  remoteDataCounter: number;

  constructor(private accountDataService: AccountDataService,
    private formBuilder: FormBuilder,
    protected ref: NbDialogRef<TransactionCreateDialogComponent>,
    private transactionDataService: TransactionDataService) {
      this.form = this.formBuilder.group({
        amount: new FormControl(0, [Validators.required, Validators.min(0)]),
        creditAccountId: new FormControl(null, Validators.required),
        debitAccountId: new FormControl(null, Validators.required),
        issuedTime: new FormControl(new Date(), Validators.required),
        name: new FormControl(null, Validators.required),
      })
  }

  initParentAccountOptions() {
    this.accountDataService.getAccountHierarchy({}).subscribe(response => {
      this.creditAccountOptions = this.createParentAccountOptions(response.accounts, 0);
      this.debitAccountOptions = this.createParentAccountOptions(response.accounts, 0);
      this.onRemoteDataLoaded();
    })
  }

  ngOnInit(): void {
    this.remoteDataCounter = 0;
    this.initParentAccountOptions();
  }

  onCancelClick() {
    this.ref.close({
      refresh: false,
    } as TransactionCreateDialogResult);
  }

  onFormSubmit(formData) {
    let request: TransactionCreateRequest = {
      amount: formData.amount,
      creditAccountId: formData.creditAccountId,
      debitAccountId: formData.debitAccountId,
      issuedTime: formData.issuedTime,
      name: formData.name,
    }
    this.isDataSubmitting = true;
    this.transactionDataService.createTransaction(request).subscribe(response => {
      this.isDataSubmitting = false;
      if (response.isSuccess) {
        this.ref.close({
          refresh: response.isSuccess,
        } as TransactionCreateDialogResult);
      }
    }, error => {
      this.isDataSubmitting = false;
    })
  }

  onSubmitClick() {
    this.form.markAllAsTouched();
    if (this.form.invalid) {
      return;
    }
    this.onFormSubmit(this.form.value);
  }

  onRemoteDataLoaded() {
    this.remoteDataCounter++;
    if (this.remoteDataCounter >= 1) {
      this.isDataLoaded = true;
    }
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

export class TransactionCreateDialogResult {
  refresh: boolean;
}
