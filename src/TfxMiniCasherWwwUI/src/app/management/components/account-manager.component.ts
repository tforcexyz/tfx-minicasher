import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbDialogService } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { AccountCreateDialogComponent } from './shared/account-create-dialog.component';
import { AccountDataService } from '../../@data/services';
import { AccountLite } from '../../@data/models/account';

@Component({
  selector: 'miana-account-manager',
  templateUrl: './account-manager.component.html',
})
export class AccountManagerComponent implements OnInit {

  accounts: AccountLite[];
  dialogRef: NbDialogRef<AccountCreateDialogComponent>;

  constructor(private accountDataService: AccountDataService,
    private dialogService: NbDialogService) {
  }

  onCreateClick() {
    this.dialogRef = this.dialogService.open(AccountCreateDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      hasScroll: false,
    });
  }

  ngOnInit(): void {
    this.accountDataService.searchAccounts().subscribe(response => {
      this.accounts = response.accounts;
    });
  }
}
