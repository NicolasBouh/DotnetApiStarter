import { Injectable } from '@angular/core';
import {AuthModule} from "../auth.module";
import {BehaviorSubject, Observable, ReplaySubject} from "rxjs";
import {User} from "../../model/user";
import {HttpClient} from "@angular/common/http";
import {API_URL} from "../../config/constants";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSource = new ReplaySubject<User | null>(1);
  readonly currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  register(input: any): Observable<any> {
    return this.http.post(`${API_URL}/user/register`, input);
  }

  login(input: any) {
    return this.http.post<User>(`${API_URL}/user/login`, input).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    )
  }

  private setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
