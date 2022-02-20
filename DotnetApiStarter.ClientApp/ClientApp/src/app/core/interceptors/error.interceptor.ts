// src/app/services/server-error.interceptor.service.ts
import {Inject, Injectable} from '@angular/core';
import {
  HttpInterceptor, HttpRequest,
  HttpHandler, HttpEvent, HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ServerErrorInterceptorService implements HttpInterceptor {
  constructor() { }

  handleError(error: HttpErrorResponse){
    if (error.status === 401) {
      // refresh token
      return throwError(error);
    } else {
      return throwError(error);
    }
  }

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>>{
    return next.handle(req)
      .pipe(
        catchError(this.handleError)
      )
  };
}
