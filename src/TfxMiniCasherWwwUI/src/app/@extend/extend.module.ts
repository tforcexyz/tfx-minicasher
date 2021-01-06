import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NbSpinnerModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { ConfirmDialogComponent } from './components/confirm-dialog.component';
import { ConfirmDialogService } from './services/confirm-dialog.service';
import { DataLoadingIndicatorComponent } from './components/data-loading-indicator.component';
import { PageHeaderComponent } from './components/page-header.component';
import { RemoteDataCardComponent } from './components/remote-data-card.component';
import { ThemeModule } from '../@ngx-admin/@theme/theme.module';

@NgModule({
  declarations: [
    DataLoadingIndicatorComponent,
    ConfirmDialogComponent,
    PageHeaderComponent,
    RemoteDataCardComponent,
  ],
  entryComponents: [
    ConfirmDialogComponent,
  ],
  exports: [
    DataLoadingIndicatorComponent,
    PageHeaderComponent,
    RemoteDataCardComponent,
  ],
  imports: [
    NbButtonModule,
    NbCardModule,
    NbSpinnerModule,
    ThemeModule,
  ],
  providers: [
    ConfirmDialogService,
  ]
})
export class ExtendModule {
}
