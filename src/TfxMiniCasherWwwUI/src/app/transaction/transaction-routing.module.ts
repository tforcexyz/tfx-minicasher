import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';

import { GeneralLedgerComponent } from './components/general-ledger.component';
import { TransactionComponent } from './transaction.component';

const routes: Routes = [{
  path: '',
  component: TransactionComponent,
  children: [
    {
      path: 'general-ledger',
      component: GeneralLedgerComponent
    },
  ]
}];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forChild(routes)],
})
export class TransactionRoutingModule {
}
