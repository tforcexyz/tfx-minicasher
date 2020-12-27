import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'management',
    loadChildren: () => import('./management/management.module')
      .then(x => x.ManagementModule),
  },
  {
    path: 'transaction',
    loadChildren: () => import('./transaction/transaction.module')
      .then(x => x.TransactionModule),
  },
  { path: '', redirectTo: 'management', pathMatch: 'full' },
  { path: '**', redirectTo: 'management' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
