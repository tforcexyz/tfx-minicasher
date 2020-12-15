import { NgModule } from '@angular/core';
import { NbLayoutModule } from '@nebular/theme';
import { NbMenuModule } from '@nebular/theme';

import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';
import { ThemeModule } from '../@theme/theme.module';
import { AccountManagerComponent } from './components/account-manager.component';

@NgModule({
  declarations: [
    AccountManagerComponent,
    ManagementComponent,
  ],
  imports: [
    ManagementRoutingModule,
    NbLayoutModule,
    NbMenuModule,
    ThemeModule,
  ],
})
export class ManagementModule {
}
