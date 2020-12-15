import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountManagerComponent } from './components/account-manager.component';
import { ManagementComponent } from './management.component';

const routes: Routes = [{
  path: '',
  component: ManagementComponent,
  children: [
    {
      path: 'account',
      component: AccountManagerComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagementRoutingModule {
}
