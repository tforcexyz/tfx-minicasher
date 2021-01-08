import { CommonModule } from '@angular/common';
import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NbIconModule } from '@nebular/theme';
import { NbInputModule } from '@nebular/theme';
import { NbSelectModule } from '@nebular/theme';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { DataModule } from '../@data/data.module';
import { ExtendModule } from '../@extend/extend.module';
import { GeneralLedgerComponent } from './components/general-ledger.component';
import { TransactionComponent } from './transaction.component';
import { TransactionCreateDialogComponent } from './components/shared/transaction-create-dialog.component';
import { TransactionEditDialogComponent } from './components/shared/transaction-edit-dialog.component';
import { TransactionRoutingModule } from './transaction-routing.module';

@NgModule({
  declarations: [
    GeneralLedgerComponent,
    TransactionComponent,
    TransactionCreateDialogComponent,
    TransactionEditDialogComponent,
  ],
  entryComponents: [
    TransactionCreateDialogComponent,
    TransactionEditDialogComponent,
  ],
  imports: [
    CommonModule,
    DataModule,
    ExtendModule,
    TransactionRoutingModule,
    NbButtonModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    NbSelectModule,
    ReactiveFormsModule,
  ],
})
export class TransactionModule {
}
