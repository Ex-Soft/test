import { TestBed } from '@angular/core/testing';

import { HttpHeaderInterceptorInterceptor } from './http-header-interceptor.interceptor';

describe('HttpHeaderInterceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      HttpHeaderInterceptorInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: HttpHeaderInterceptorInterceptor = TestBed.inject(HttpHeaderInterceptorInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
