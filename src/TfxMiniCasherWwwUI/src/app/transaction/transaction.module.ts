import { CommonModule } from '@angular/common';
import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NbIconModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { DataModule } from '../@data/data.module';
import { ExtendModule } from '../@extend/extend.module';
import { GeneralLedgerComponent } from './components/general-ledger.component';
import { TransactionComponent } from './transaction.component';
import { TransactionRoutingModule } from './transaction-routing.module';

@NgModule({
  declarations: [
    GeneralLedgerComponent,
    TransactionComponent,
  ],
  entryComponents: [
  ],
  imports: [
    CommonModule,
    DataModule,
    ExtendModule,
    TransactionRoutingModule,
    NbButtonModule,
    NbCardModule,
    NbIconModule,
  ],
})
export class TransactionModule {
}
