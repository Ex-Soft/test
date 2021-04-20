import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { TestHttpComponent } from './test-http.component';

interface Data {
  name: string;
}

const testUrl = '/data';

describe('TestHttpComponent', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  let component: TestHttpComponent;
  let fixture: ComponentFixture<TestHttpComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestHttpComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    fixture = TestBed.createComponent(TestHttpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('can test HttpClient.get', () => {
    const testData: Data = {name: 'Test Data'};

    // act
    httpClient.get<Data>(testUrl)
      .subscribe(data => expect(data).toEqual(testData));

    // assert
    const req = httpTestingController.expectOne('/data');
    expect(req.request.method).toEqual('GET');

    // act
    req.flush(testData);

    httpTestingController.verify();
  });

  it('can test HttpClient.get with matching header', () => {
    const testData: Data = {name: 'Test Data'};

    // act
    httpClient.get<Data>(testUrl, {
        headers: new HttpHeaders({Authorization: 'my-auth-token'})
      })
      .subscribe(data =>
        expect(data).toEqual(testData)
      );

    // assert
    const req = httpTestingController.expectOne(
      request => request.headers.has('Authorization')
    );

    // act
    req.flush(testData);
  });

  it('can test multiple requests', () => {
    const testData: Data[] = [
      { name: 'bob' }, { name: 'carol' },
      { name: 'ted' }, { name: 'alice' }
    ];

    httpClient.get<Data[]>(testUrl)
      .subscribe(d => expect(d.length).toEqual(0, 'should have no data'));

    httpClient.get<Data[]>(testUrl)
      .subscribe(d => expect(d).toEqual([testData[0]], 'should be one element array'));

    httpClient.get<Data[]>(testUrl)
      .subscribe(d => expect(d).toEqual(testData, 'should be expected data'));

    const requests = httpTestingController.match(testUrl);
    expect(requests.length).toEqual(3);

    requests[0].flush([]);
    requests[1].flush([testData[0]]);
    requests[2].flush(testData);
  });

  it('can test for 404 error', () => {
    const emsg = 'deliberate 404 error';

    httpClient.get<Data[]>(testUrl).subscribe(
      data => fail('should have failed with the 404 error'),
      (error: HttpErrorResponse) => {
        expect(error.status).toEqual(404, 'status');
        expect(error.error).toEqual(emsg, 'message');
      }
    );

    const req = httpTestingController.expectOne(testUrl);

    req.flush(emsg, { status: 404, statusText: 'Not Found' });
  });

  it('can test for network error', () => {
    const emsg = 'simulated network error';

    httpClient.get<Data[]>(testUrl).subscribe(
      data => fail('should have failed with the network error'),
      (error: HttpErrorResponse) => {
        expect(error.error.message).toEqual(emsg, 'message');
      }
    );

    const req = httpTestingController.expectOne(testUrl);

    const mockError = new ErrorEvent('Network error', {
      message: emsg,
      filename: 'HeroService.ts',
      lineno: 42,
      colno: 21
    });

    req.error(mockError);
  });

  it('httpTestingController.verify should fail if HTTP response not simulated', () => {
    httpClient.get('some/api').subscribe();

    expect(() => httpTestingController.verify()).toThrow();

    const req = httpTestingController.expectOne('some/api');
    req.flush(null);
  });

  // Proves that verify in afterEach() really would catch error
  // if test doesn't simulate the HTTP response.
  //
  // Must disable this test because can't catch an error in an afterEach().
  // Uncomment if you want to confirm that afterEach() does the job.
  // it('afterEach() should fail when HTTP response not simulated',() => {
  //   // Sends request which is never handled by this test
  //   httpClient.get('some/api').subscribe();
  // });
});
