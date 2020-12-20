import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NbChatModule } from '@nebular/theme';
import { NbDatepickerModule } from '@nebular/theme';
import { NbDialogModule } from '@nebular/theme';
import { NbMenuModule } from '@nebular/theme';
import { NbSidebarModule } from '@nebular/theme';
import { NbToastrModule } from '@nebular/theme';
import { NbWindowModule } from '@nebular/theme';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './@ngx-admin/@core/core.module';
import { ManagementModule } from './management/management.module';
import { ThemeModule } from './@ngx-admin/@theme/theme.module';

@NgModule({
  bootstrap: [
    AppComponent
  ],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NbChatModule.forRoot({
      messageGoogleMapKey: 'AIzaSyA_wNuCzia92MAmdLRzmqitRGvCF7wCZPY',
    }),
    NbDatepickerModule.forRoot(),
    NbDialogModule.forRoot(),
    NbMenuModule.forRoot(),
    NbSidebarModule.forRoot(),
    NbWindowModule.forRoot(),
    NbToastrModule.forRoot(),
    CoreModule.forRoot(),
    ThemeModule.forRoot(),
    AppRoutingModule,
    ManagementModule,
  ],
})
export class AppModule { }
