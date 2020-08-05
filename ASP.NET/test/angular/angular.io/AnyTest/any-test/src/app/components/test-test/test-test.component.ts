import { Component, OnInit } from '@angular/core';
import { TestHttpGetDtoObject1Service } from '../../services/test-http-get-dto-object-1.service';
import { DtoObject1 } from '../../models/dto-object1';

@Component({
  selector: 'app-test-test',
  templateUrl: './test-test.component.html',
  styleUrls: ['./test-test.component.css']
})
export class TestTestComponent implements OnInit {
  baseUrl = 'http://localhost:51102/api/testhttp/';
  value1: string;
  value2: string;
  dtoObject1: DtoObject1;

  constructor(private getDtoObject1Service: TestHttpGetDtoObject1Service) { }

  ngOnInit(): void {
    this.getDtoObject1Service.getData(this.baseUrl).subscribe(dtoObj => this.dtoObject1 = dtoObj);
  }

  onBtnSetValue1Click(): void {
    this.value1 = 'value1 (via onBtnSetValue1Click())';
  }
}
