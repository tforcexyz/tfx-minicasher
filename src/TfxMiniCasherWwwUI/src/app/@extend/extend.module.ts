import { NbCardModule } from '@nebular/theme';
import { NgModule } from '@angular/core';

import { PageHeaderComponent } from './components/page-header.component';
import { ThemeModule } from '../@ngx-admin/@theme/theme.module';

@NgModule({
  declarations: [
    PageHeaderComponent,
  ],
  exports: [
    PageHeaderComponent,
  ],
  imports: [
    NbCardModule,
    ThemeModule,
  ],
  providers: [
  ]
})
export class ExtendModule {
}
