import { Component } from "@angular/core";
import { NbDialogRef } from "@nebular/theme";

@Component({
  selector: 'miana-account-create',
  templateUrl: './account-create-dialog.component.html',
})
export class AccountCreateDialogComponent {

  constructor(protected ref: NbDialogRef<AccountCreateDialogComponent>) {
  }

  dismiss() {
    this.ref.close();
  }
}
