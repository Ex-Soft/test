import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpHeaderInterceptorInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const corsRequest = request.clone({
      /*setHeaders: {
        'Access-Control-Request-Methods': 'GET,POST,PUT,DELETE,OPTIONS',
        'X-custom-value1': 'X-custom-value1',
        'X-custom-value2': 'X-custom-value2'
      }*/
      headers: request.headers
        .set('Access-Control-Request-Methods', 'GET,POST,PUT,DELETE,OPTIONS')
        .set('X-custom-header1', 'X-custom-header-value1')
        .set('X-custom-header2', 'X-custom-header-value2')
    });

    return next.handle(corsRequest);
  }
}
