import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { ConfirmDialogComponent } from './components/confirm-dialog.component';
import { ConfirmDialogService } from './services/confirm-dialog.service';
import { PageHeaderComponent } from './components/page-header.component';
import { ThemeModule } from '../@ngx-admin/@theme/theme.module';

@NgModule({
  declarations: [
    PageHeaderComponent,
    ConfirmDialogComponent,
  ],
  entryComponents: [
    ConfirmDialogComponent,
  ],
  exports: [
    PageHeaderComponent,
  ],
  imports: [
    NbButtonModule,
    NbCardModule,
    ThemeModule,
  ],
  providers: [
    ConfirmDialogService,
  ]
})
export class ExtendModule {
}
