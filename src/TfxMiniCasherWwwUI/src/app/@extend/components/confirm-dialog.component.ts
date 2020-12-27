import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { OnInit } from '@angular/core';

import { CommonDialogResult } from '../models/dialog';

@Component({
  selector: 'confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
})
export class ConfirmDialogComponent implements OnInit {
  callbackArgs: any;
  cancelLabel: string;
  message: string;
  okLabel: string;
  title: string;

  constructor(private ref: NbDialogRef<ConfirmDialogComponent>) {
  }

  ngOnInit(): void {
    this.cancelLabel = this.cancelLabel ?? DefaultMessages.cancelLabel;
    this.message = this.message ?? DefaultMessages.message;
    this.okLabel = this.okLabel ?? DefaultMessages.okLabel;
    this.title = this.title ?? DefaultMessages.title;
  }

  onConfirm() {
    this.ref.close({
      callbackArgs: this.callbackArgs,
      confirmed: true,
    } as CommonDialogResult);
  }

  onDismiss() {
    this.ref.close({
      callbackArgs: null,
      confirmed: false,
    } as CommonDialogResult);
  }
}

class DefaultMessages {
  static readonly cancelLabel: string = 'Cancel';
  static readonly message: string = 'Are you sure?';
  static readonly okLabel: string = 'OK';
  static readonly title: string = 'Confirm';
}
