import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-custom-derived',
  templateUrl: './custom-derived.component.html',
  styleUrls: ['./custom-derived.component.css']
})
export class CustomDerivedComponent implements OnInit {
  public pBool = false;

  constructor() { }
  ngOnInit(): void { }

  onToggleClick(): void {
    this.pBool = !this.pBool;
  }
}
