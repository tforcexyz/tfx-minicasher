import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NbCheckboxModule } from '@nebular/theme';
import { NbIconModule } from '@nebular/theme';
import { NbInputModule } from '@nebular/theme';
import { NbRadioModule } from '@nebular/theme';
import { NbSelectModule } from '@nebular/theme';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AccountCreateDialogComponent } from './components/shared/account-create-dialog.component';
import { AccountManagerComponent } from './components/account-manager.component';
import { DataModule } from '../@data/data.module';
import { ExtendModule } from '../@extend/extend.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';

@NgModule({
  declarations: [
    AccountCreateDialogComponent,
    AccountManagerComponent,
    ManagementComponent,
  ],
  entryComponents: [
    AccountCreateDialogComponent,
  ],
  imports: [
    CommonModule,
    DataModule,
    ExtendModule,
    FormsModule,
    ManagementRoutingModule,
    NbButtonModule,
    NbCardModule,
    NbCheckboxModule,
    NbIconModule,
    NbInputModule,
    NbRadioModule,
    NbSelectModule,
    ReactiveFormsModule,
  ],
})
export class ManagementModule {
}
