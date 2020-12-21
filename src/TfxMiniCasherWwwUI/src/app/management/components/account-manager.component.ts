import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { AccountDataService } from '../../@data/services';
import { AccountLite } from '../../@data/models/account';

@Component({
  selector: 'miana-account-manager',
  templateUrl: './account-manager.component.html',
})
export class AccountManagerComponent implements OnInit {

  private accounts: AccountLite[];

  constructor(private accountDataService: AccountDataService) {
  }

  ngOnInit(): void {
    this.accountDataService.searchAccounts().subscribe(response => {
      this.accounts = response.accounts;
    });
  }
}
