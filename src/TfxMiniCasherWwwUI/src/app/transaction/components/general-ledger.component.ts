import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbDialogService } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { TransactionCreateDialogComponent } from './shared/transaction-create-dialog.component';
import { TransactionCreateDialogResult } from './shared/transaction-create-dialog.component';
import { TransactionDataService } from '../../@data/services';
import { TransactionLite } from '../../@data/models'

@Component({
  selector: 'miana-general-ledger',
  templateUrl: './general-ledger.component.html',
})
export class GeneralLedgerComponent implements OnInit {

  createDialogRef: NbDialogRef<TransactionCreateDialogComponent>;
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

  searchTransactions() {
    this.isLoaded = false;
    this.transactionDataService.searchTransactions().subscribe(response => {
      this.transactions = response.transactions;
      this.isLoaded = true;
    }, error => {
      this.isLoaded = true;
      this.isError = true;
    });
  }
}
