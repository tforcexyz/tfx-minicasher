import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AccountDataService } from './services/acccount-data.service';
import { AccountDataServiceImpl } from './services/acccount-data.service';

@NgModule({
  declarations: [
  ],
  imports: [
    HttpClientModule,
  ],
  providers: [
    { provide: AccountDataService, useClass: AccountDataServiceImpl },
  ]
})
export class DataModule {
}
