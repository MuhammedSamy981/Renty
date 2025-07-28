import {HttpInterceptor,HttpRequest,HttpHandler,HttpEvent} from '@angular/common/http';
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from 'rxjs';
import { UsersService } from '../services/users.service';
import { Injectable } from '@angular/core';
  
  @Injectable()
  export class AuthInterceptor implements HttpInterceptor {
    constructor(private auth: UsersService) {}

     private isRefreshing = false;
  private refreshTokenSubject = new BehaviorSubject<string | null>(null);
  
    intercept(
      authReq: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
        const accessToken  = localStorage.getItem('access_token');
      if (accessToken ) {
        authReq = authReq.clone({
          setHeaders: {
            Authorization: `Bearer ${accessToken }`
          }
        });
      }
      
      return next.handle(authReq).pipe(
      catchError(error => {
        if (error.status === 401 && !authReq.url.includes('/refresh-token')) {
          return this.handle401Error(authReq, next);
        }
        return throwError(() => error);
      })
    );
  }


 private handle401Error(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.auth.refreshToken().pipe(
        switchMap((res: any) => {
          this.isRefreshing = false;
           localStorage.setItem('access_token', res.accessToken);
    localStorage.setItem('refresh_token', res.refreshToken);
          this.refreshTokenSubject.next(res.accessToken);

          return next.handle(req.clone({
            headers: req.headers.set('Authorization', `Bearer ${res.accessToken}`)
          }));
        }),
        catchError(err => {
          this.isRefreshing = false;
          this.auth.logout();
          return throwError(() => err);
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        filter(token => !!token),
        take(1),
        switchMap(token => next.handle(req.clone({
          headers: req.headers.set('Authorization', `Bearer ${token}`)
        })))
      );
    }
  }

  }