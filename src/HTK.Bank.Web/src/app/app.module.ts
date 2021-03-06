import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';

import { AlertComponent } from './_directives/index';
import { AuthGuard } from './_guards/index';
import { AlertService, AuthenticationService, UserService, PaymentService } from './_services/index';
import { HomeComponent } from './home/index';
import { LoginComponent } from './login/index';
import { PaymentComponent, PaymentConfirmComponent, CanvasComponent } from './payment/index'


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
    LoginComponent,
    PaymentComponent,
    PaymentConfirmComponent,
    CanvasComponent
  ],
  providers: [
    AuthGuard,
    AlertService,
    AuthenticationService,
    UserService,
    PaymentService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
