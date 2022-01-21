import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';

@Component({
  selector: 'app-with-data-service',
  templateUrl: './with-data-service.component.html',
  styleUrls: ['./with-data-service.component.css']
})
export class WithDataServiceComponent implements OnInit {
  constructor(private _dataService: DataService) { }

  ngOnInit(): void {
  }

  get pNumber():number | undefined | null {
    return this._dataService?.data?.pNumber;
  }
}
