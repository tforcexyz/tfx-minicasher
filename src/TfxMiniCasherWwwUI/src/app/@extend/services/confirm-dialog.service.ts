import { Injectable } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbDialogService } from '@nebular/theme';
import { Observable } from 'rxjs';

import { ConfirmDialogComponent } from '../components/confirm-dialog.component';
import { CommonDialogResult } from '../models/dialog';

@Injectable()
export class ConfirmDialogService {

  constructor(private nbDialogService: NbDialogService) {
  }

  confirm(message: string = null, title: string = null, callbackArgs: any = null): Observable<CommonDialogResult> {
    let dialogRef: NbDialogRef<ConfirmDialogComponent> = this.nbDialogService.open(ConfirmDialogComponent, {
      closeOnBackdropClick: false,
      closeOnEsc: true,
      context: {
        callbackArgs: callbackArgs,
        message: message,
        title: title,
      },
      hasScroll: false,
    });
    return new Observable<CommonDialogResult>((observable) => {
      dialogRef.onClose.subscribe((result: CommonDialogResult) => {
        observable.next(result);
        observable.complete();
      }, error => {
        observable.error(error);
      })
    })
  }
}
