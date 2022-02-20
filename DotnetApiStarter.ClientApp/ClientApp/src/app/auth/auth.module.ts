import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import {RouterModule} from "@angular/router";
import {AUTH_ROUTES} from "./auth.routes";
import {CustomTaigaModule} from "../custom-taiga.module";
import {ReactiveFormsModule} from "@angular/forms";
import {AuthService} from "./services/auth.service";



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    CustomTaigaModule,
    ReactiveFormsModule,
    RouterModule.forChild(AUTH_ROUTES),
  ]
})
export class AuthModule { }
