import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbDialogService } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { AccountCreateDialogComponent } from './shared/account-create-dialog.component';
import { AccountCreateDialogResult } from './shared/account-create-dialog.component';
import { AccountDataService } from '../../@data/services';
import { AccountEditDialogComponent } from './shared/account-edit-dialog.component';
import { AccountEditDialogResult } from './shared/account-edit-dialog.component';
import { AccountLite } from '../../@data/models/account'
import { ConfirmDialogService } from '../../@extend/services/confirm-dialog.service';

@Component({
  selector: 'miana-account-manager',
  templateUrl: './account-manager.component.html',
})
export class AccountManagerComponent implements OnInit {

  accounts: AccountLite[];
  createDialogRef: NbDialogRef<AccountCreateDialogComponent>;
  editDialogRef: NbDialogRef<AccountEditDialogComponent>;

  constructor(private accountDataService: AccountDataService,
    private confirmDialogService: ConfirmDialogService,
    private dialogService: NbDialogService) {
  }

  onCreateClick() {
    this.createDialogRef = this.dialogService.open(AccountCreateDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      hasScroll: false,
    });
    this.createDialogRef.onClose.subscribe((result: AccountCreateDialogResult) => {
      if(result.refresh) {
        this.searchAccounts();
      }
    })
  }

  onItemEditClick(id: string) {
    this.editDialogRef = this.dialogService.open(AccountEditDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      context: {
        accountId: id,
      },
      hasScroll: false,
    });
    this.editDialogRef.onClose.subscribe((result: AccountEditDialogResult) => {
      if(result.refresh) {
        this.searchAccounts();
      }
    })
  }

  onItemDeleteClick(id: string) {
    this.confirmDialogService.confirm('Are you sure to delete this account?').subscribe(result => {
      if (result.confirmed) {
        this.accountDataService.deleteAccount(id).subscribe((response) => {
          if (response.isSuccess) {
            this.searchAccounts();
          }
        })
      }
    })
  }

  ngOnInit(): void {
    this.searchAccounts();
  }

  searchAccounts() {
    this.accountDataService.searchAccounts().subscribe(response => {
      this.accounts = response.accounts;
    });
  }
}
