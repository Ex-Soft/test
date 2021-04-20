import { Component, OnInit, Pipe, PipeTransform, Input } from '@angular/core';
import { IView } from '../../models/IView';
import { IComplexObjectView } from '../../models/IComplexObjectView';

@Component({
  selector: 'app-test-pipe',
  templateUrl: './test-pipe.component.html',
  styleUrls: ['./test-pipe.component.css']
})
export class TestPipeComponent implements OnInit {
  constructor() { }

  @Input() items: IView[];
  @Input() complexObject: IComplexObjectView;

  ngOnInit(): void {
  }
}
