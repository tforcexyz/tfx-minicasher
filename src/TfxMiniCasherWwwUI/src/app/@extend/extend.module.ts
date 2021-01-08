import { NbButtonModule } from '@nebular/theme';
import { NbCardModule } from '@nebular/theme';
import { NbSpinnerModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { ConfirmDialogComponent } from './components/confirm-dialog.component';
import { ConfirmDialogService } from './services/confirm-dialog.service';
import { DataLoadingIndicatorComponent } from './components/data-loading-indicator.component';
import { PageHeaderComponent } from './components/page-header.component';
import { ReactiveValidationMessage } from './components/reactive-validation-message.component';
import { RemoteDataCardComponent } from './components/remote-data-card.component';
import { ThemeModule } from '../@ngx-admin/@theme/theme.module';

@NgModule({
  declarations: [
    DataLoadingIndicatorComponent,
    ConfirmDialogComponent,
    PageHeaderComponent,
    ReactiveValidationMessage,
    RemoteDataCardComponent,
  ],
  entryComponents: [
    ConfirmDialogComponent,
  ],
  exports: [
    DataLoadingIndicatorComponent,
    PageHeaderComponent,
    ReactiveValidationMessage,
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
