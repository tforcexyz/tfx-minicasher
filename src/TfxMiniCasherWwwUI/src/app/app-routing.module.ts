import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'management',
    loadChildren: () => import('./management/management.module')
      .then(x => x.ManagementModule),
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
