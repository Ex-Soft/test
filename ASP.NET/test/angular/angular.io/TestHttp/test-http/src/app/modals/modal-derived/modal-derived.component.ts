import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-derived',
  templateUrl: './modal-derived.component.html',
  styleUrls: ['./modal-derived.component.css']
})
export class ModalDerivedComponent implements OnInit {
  public title: string;
  public isLoading = true;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.title = data.title;
  }

  ngOnInit(): void {
    const timeoutId = setTimeout(() => {
      this.isLoading = false;
      clearTimeout(timeoutId);
    }, 5000);
  }
}
