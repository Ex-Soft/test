// https://blog.angular-university.io/angular-http/
// https://medium.com/@swarnakishore/performing-multiple-http-requests-in-angular-4-5-with-forkjoin-74f3ac166d61
// https://coryrylan.com/blog/angular-multiple-http-requests-with-rxjs
// https://www.techiediaries.com/angular/angular-9-8-tutorial-by-example-rest-crud-apis-http-get-requests-with-httpclient/
// https://www.positronx.io/handle-angular-http-requests-with-observables/
// https://coryrylan.com/blog/subscribing-to-multiple-observables-in-angular-components
// https://codecraft.tv/courses/angular/http/http-with-observables/

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { combineLatest, Observable, UnaryFunction, forkJoin, of, throwError } from 'rxjs';
import { map, switchMap, mergeMap, flatMap, retry, catchError } from 'rxjs/operators';

import { TestHttpGet1Service } from '../../services/test-http-get-1.service';
import { TestHttpGet2Service } from '../../services/test-http-get-2.service';
import { TestHttpGet3Service } from '../../services/test-http-get-3.service';
import { TestHttpGetDtoObject1Service } from '../../services/test-http-get-dto-object-1.service';
import { TestHttpGetDtoObject2Service } from '../../services/test-http-get-dto-object-2.service';
import { TestHttpGetDtoObject3Service } from '../../services/test-http-get-dto-object-3.service';
import { DtoObject1, StatusCodeResponse } from 'src/app/models';

@Component({
  selector: 'app-test-http',
  templateUrl: './test-http.component.html',
  styleUrls: ['./test-http.component.css']
})
export class TestHttpComponent implements OnInit {
  baseUrl = 'http://localhost:51102/api/testhttp/';
  data: any;

  constructor(
    private http: HttpClient,
    private get1service: TestHttpGet1Service<any>,
    private get2service: TestHttpGet2Service<any>,
    private get3service: TestHttpGet3Service<any>,
    private getDtoObject1Service: TestHttpGetDtoObject1Service,
    private getDtoObject2Service: TestHttpGetDtoObject2Service,
    private getDtoObject3Service: TestHttpGetDtoObject3Service
  ) { }

  ngOnInit(): void {
  }

  onClickInspect(): void {
    console.log(this.data);
  }

  onClickTestOneSubscribe(): void {
    const result = this.get1service.getData(this.baseUrl)
      .subscribe(data => {
        console.log('subscribe() data = %o', data);
        this.data = data;
      });
    console.log('result=%o', result);
  }

  onClickTestOnePipe(): void {
    const result = this.get1service.getData(this.baseUrl)
      .pipe(obj => {
        console.log('pipe() obj = %o', obj);
        return obj;
      })
      .subscribe(data => {
        console.log('subscribe() data = %o', data);
        this.data = data;
      });
  }

  onClickTestThreeCombineLatest(): void {
    const result = combineLatest([
      this.get1service.getData(this.baseUrl),
      this.get2service.getData(this.baseUrl),
      this.get3service.getData(this.baseUrl)
    ])
    .pipe(
      map(([first, second, third]) => {
        console.log('pipe(map(%o))', arguments);
        return [ first, second, third ];
      })
    )
    .subscribe(data => {
      console.log('subscribe() data = %o', data);
      this.data = data.reduce((prev, curr) => {
        if (prev.length) {
          prev += ' ';
        }

        return prev + curr.name;
      }, '');
    });
  }

  onClickTestThreeForkJoin(): void {
    const result = forkJoin([
      this.get1service.getData(this.baseUrl),
      this.get2service.getData(this.baseUrl),
      this.get3service.getData(this.baseUrl)
    ])
    .pipe(
      map(([first, second, third]) => {
        console.log('pipe(map(%o))', arguments);
        return [ first, second, third ];
      })
    )
    .subscribe(data => {
      console.log('subscribe() data = %o', data);
      this.data = data.reduce((prev, curr) => {
        if (prev.length) {
          prev += ' ';
        }

        return prev + curr.name;
      }, '');
    });
  }

  onClickTestThreeSwitchMap(): void {
    this.getDtoObject1Service.getData(this.baseUrl)
      .pipe(switchMap(dtoObject => {
        console.log('switchMap() dtoObject = %o', dtoObject);
        if (dtoObject) {
          return this.getDtoObject2Service.getData(this.baseUrl);
        } else {
          return of(null);
        }
      }))
      .pipe(switchMap(dtoObject => {
        console.log('switchMap() dtoObject = %o', dtoObject);
        if (dtoObject) {
          return this.getDtoObject3Service.getData(this.baseUrl);
        } else {
          return of(null);
        }
      }))
      .subscribe(dtoObject => {
        console.log('subscribe() dtoObject = %o', dtoObject);
      });
  }

  onClickTestThreeMergeMap(): void {
    this.getDtoObject1Service.getData(this.baseUrl)
      .pipe(mergeMap(dtoObject => {
        console.log('mergeMap() dtoObject = %o', dtoObject);
        if (dtoObject) {
          return this.getDtoObject2Service.getData(this.baseUrl);
        } else {
          return of(null);
        }
      }))
      .pipe(mergeMap(dtoObject => {
        console.log('mergeMap() dtoObject = %o', dtoObject);
        if (dtoObject) {
          return this.getDtoObject3Service.getData(this.baseUrl);
        } else {
          return of(null);
        }
      }))
      .subscribe(dtoObject => {
        console.log('subscribe() dtoObject = %o', dtoObject);
      });
  }

  handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage) /* of() */;
  }

  onClickTestHandleError(): void {
    this.http.get(`${this.baseUrl}blah-blah-blah`)
    .pipe(catchError(this.handleError))
    .subscribe(() => {});
  }

  onClickTestRetry(): void {
    this.http.get(`${this.baseUrl}blah-blah-blah`)
    .pipe(retry(3), catchError(this.handleError))
    .subscribe(() => {});
  }

  onClickTestFullResponse(): void {
    this.http.get<DtoObject1>(`${this.baseUrl}getdtoobject1`, { observe: 'response' })
      .subscribe(resp => {
        console.log(resp.body);
      });
  }

  onClickXXX(e: Event): void {
    const btn = e.target as HTMLInputElement;
    this.http.get<StatusCodeResponse>(`${this.baseUrl}get${btn.value}`).subscribe(
      resp => {
        console.log('next(%o)', resp);
      },
      error => {
        console.log('error(%o)', error.error);
      },
      () => {
        console.log('complete()');
      }
    );
  }
}