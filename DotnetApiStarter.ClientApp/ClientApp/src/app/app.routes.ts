import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";

export const APP_ROUTES: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'auth/login', redirectTo: '/auth/login', pathMatch: 'full' },
  { path: 'auth/register', redirectTo: '/auth/register', pathMatch: 'full' },
  { path: '**', redirectTo: '/' }
];
