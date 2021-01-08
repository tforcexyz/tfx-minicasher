import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NbDialogRef } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { AccountDataService } from "../../../@data/services";
import { AccountHierarchy } from '../../../@data/models';
import { KeyValuePair } from '../../../@extend/models';
import { Transaction } from '../../../@data/models';
import { TransactionEditRequest } from '../../../@data/models';
import { TransactionDataService } from "../../../@data/services";

@Component({
  selector: 'miana-transaction-edit',
  styleUrls: ['./transaction-edit-dialog.component.scss'],
  templateUrl: './transaction-edit-dialog.component.html',
})
export class TransactionEditDialogComponent implements OnInit {

  creditAccountOptions: KeyValuePair<string, string>[];
  debitAccountOptions: KeyValuePair<string, string>[];
  form: any;
  isDataLoaded: boolean;
  isDataSubmitting: boolean;
  remoteDataCounter: number;
  transaction: Transaction;
  transactionId: string;

  constructor(private accountDataService: AccountDataService,
    private formBuilder: FormBuilder,
    protected ref: NbDialogRef<TransactionEditDialogComponent>,
    private transactionDataService: TransactionDataService) {
      this.form = this.formBuilder.group({
        amount: null,
        creditAccountId: null,
        debitAccountId: null,
        issuedTime: null,
        name: null,
      })
  }

  getDetail(transactionId: string) {
    this.transactionDataService.getTransaction(transactionId).subscribe(response =>{
      this.transaction = response.transaction;
      this.setFormValues(response.transaction);
      this.onRemoteDataLoaded();
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
    this.setDefaultFormValues();
    this.getDetail(this.transactionId);
  }

  onCancelClick() {
    this.ref.close({
      refresh: false,
    } as TransactionEditDialogResult);
  }

  onFormSubmit(formData) {
    let request: TransactionEditRequest = {
      amount: formData.amount,
      creditAccountId: formData.creditAccountId,
      debitAccountId: formData.debitAccountId,
      issuedTime: formData.issuedTime,
      name: formData.name,
    }
    this.isDataSubmitting = true;
    this.transactionDataService.editTransaction(this.transactionId, request).subscribe(response => {
      this.isDataSubmitting = false;
      if (response.isSuccess) {
        this.ref.close({
          refresh: response.isSuccess,
        } as TransactionEditDialogResult);
      }
    }, error => {
      this.isDataSubmitting = false;
    })
  }

  onRemoteDataLoaded() {
    this.remoteDataCounter++;
    if (this.remoteDataCounter >= 1) {
      this.isDataLoaded = true;
    }
  }

  onSubmitClick() {
    this.onFormSubmit(this.form.value);
  }

  setDefaultFormValues() {
    this.form.patchValue({
      issuedTime: new Date(),
    })
  }

  setFormValues(transaction: Transaction) {
    this.form.patchValue({
      amount: transaction.amount,
      creditAccountId: transaction.creditAccount.id,
      debitAccountId: transaction.debitAccount.id,
      issuedTime: transaction.issuedTime,
      name: transaction.name,
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

export class TransactionEditDialogResult {
  refresh: boolean;
}
