import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { HttpHeaderInterceptorInterceptor } from './http-header-interceptor.interceptor';

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: HttpHeaderInterceptorInterceptor, multi: true },
];
