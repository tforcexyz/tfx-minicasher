import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { TransactionDataService } from '../../@data/services';
import { TransactionLite } from '../../@data/models'

@Component({
  selector: 'miana-general-ledger',
  templateUrl: './general-ledger.component.html',
})
export class GeneralLedgerComponent implements OnInit {

  transactions: TransactionLite[];

  constructor(private transactionDataService: TransactionDataService) {
  }

  ngOnInit(): void {
    this.searchTransactions();
  }

  searchTransactions() {
    this.transactionDataService.searchTransactions().subscribe(response => {
      this.transactions = response.transactions;
    });
  }
}
