import { CommonModule } from '@angular/common';
import { NbCardModule } from '@nebular/theme';
import { NbIconModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { AccountManagerComponent } from './components/account-manager.component';
import { DataModule } from '../@data/data.module';
import { ExtendModule } from '../@extend/extend.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';

@NgModule({
  declarations: [
    AccountManagerComponent,
    ManagementComponent,
  ],
  imports: [
    CommonModule,
    DataModule,
    ExtendModule,
    ManagementRoutingModule,
    NbCardModule,
    NbIconModule,
  ],
})
export class ManagementModule {
}
