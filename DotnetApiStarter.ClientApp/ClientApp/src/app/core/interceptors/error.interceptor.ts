// src/app/services/error.interceptor.ts
import {Inject, Injectable} from '@angular/core';
import {
  HttpInterceptor, HttpRequest,
  HttpHandler, HttpEvent, HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {NotificationService} from "../services/notification.service";

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private notificationService: NotificationService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>>{
    return next.handle(req)
      .pipe(
        catchError(error => {
          if (error) {
            switch (error.status) {
              case 409:
                console.log("error handler 409 - validations errors", error);
                if (error.error.errors) {
                  /*const errors = [];
                  for (const key in error.error.errors) {
                    if (error.error.errors[key]) {
                      errors.push(error.error.errors[key])
                    }
                  }*/

                  this.notificationService.showError(error.error.message);

                  // @ts-ignore
                  throw error.error.errors;
                } else if (typeof(error.error) === 'object') {
                  this.notificationService.showError(error.error.message);
                } else {
                  this.notificationService.showError(error.message);
                }
                break;
              case 401:
                this.notificationService.showError(error.error.message);
                break;
              case 404:
                //this.router.navigateByUrl('/not-found');
                this.notificationService.showError("Not found");
                break;
              case 500:
                this.notificationService.showError("Server error");
                break;
              default:
                this.notificationService.showError("Oups something went wrong");
                console.log(error);
                break;
            }
          }

          return throwError(error);
        })
      )
  };
}
