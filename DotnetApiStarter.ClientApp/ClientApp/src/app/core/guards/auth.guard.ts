import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import {NotificationService} from "../services/notification.service";
import {AuthService} from "../../auth/services/auth.service";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private notificationService: NotificationService, private authService: AuthService) {}

  canActivate(): Observable<boolean> {
    return this.authService.currentUser$.pipe(
      map((user: any) => {
        return !!user;
      })
    )
  }

}
