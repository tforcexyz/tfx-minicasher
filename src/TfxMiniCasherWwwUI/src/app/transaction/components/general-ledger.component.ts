import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbDialogService } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { TransactionCreateDialogComponent } from './shared/transaction-create-dialog.component';
import { TransactionCreateDialogResult } from './shared/transaction-create-dialog.component';
import { TransactionDataService } from '../../@data/services';
import { TransactionEditDialogComponent } from './shared/transaction-edit-dialog.component';
import { TransactionEditDialogResult } from './shared/transaction-edit-dialog.component';
import { TransactionLite } from '../../@data/models'

@Component({
  selector: 'miana-general-ledger',
  templateUrl: './general-ledger.component.html',
})
export class GeneralLedgerComponent implements OnInit {

  createDialogRef: NbDialogRef<TransactionCreateDialogComponent>;
  editDialogRef: NbDialogRef<TransactionEditDialogComponent>;
  isError: boolean;
  isLoaded: boolean;
  transactions: TransactionLite[];

  constructor(private dialogService: NbDialogService,
    private transactionDataService: TransactionDataService) {
  }

  ngOnInit(): void {
    this.searchTransactions();
  }

  onCreateClick() {
    this.createDialogRef = this.dialogService.open(TransactionCreateDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      hasScroll: false,
    });
    this.createDialogRef.onClose.subscribe((result: TransactionCreateDialogResult) => {
      if(result.refresh) {
        this.searchTransactions();
      }
    })
  }

  onItemEditClick(id: string) {
    this.editDialogRef = this.dialogService.open(TransactionEditDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      context: {
        transactionId: id,
      },
      hasScroll: false,
    });
    this.editDialogRef.onClose.subscribe((result: TransactionEditDialogResult) => {
      if(result.refresh) {
        this.searchTransactions();
      }
    })
  }

  onRetryClick() {
    this.isLoaded = false;
    this.isError = false;
    this.searchTransactions();
  }

  searchTransactions() {
    this.transactionDataService.searchTransactions().subscribe(response => {
      this.transactions = response.transactions;
      this.isLoaded = true;
    }, error => {
      this.isLoaded = true;
      this.isError = true;
    });
  }
}
